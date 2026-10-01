import { useState } from 'react'
import { api, dateInput, formaterDate, type Emprunt, type EmpruntSaisie } from '../api'
import { Alerte, Champ, FenetreFormulaire, Recherche } from '../composants'
import { contient, useDonnees } from '../outils'

type Filtre = 'tous' | 'enCours' | 'enRetard' | 'rendus'

const DUREE_PRET_JOURS = 14

const nouvelleSaisie = (): EmpruntSaisie => {
  const aujourdhui = new Date()
  const retour = new Date(aujourdhui)
  retour.setDate(retour.getDate() + DUREE_PRET_JOURS)
  return { livreId: '', clientId: '', dateEmprunt: dateInput(aujourdhui), dateRetour: dateInput(retour) }
}

const chargerTout = () => Promise.all([api.emprunts.lister(), api.livres.lister(), api.clients.lister()])

export default function Emprunts() {
  const { donnees, erreur, recharger } = useDonnees(chargerTout)
  const [emprunts, livres, clients] = donnees ?? [[], [], []]
  const [erreurAction, setErreurAction] = useState<string | null>(null)
  const [recherche, setRecherche] = useState('')
  const [filtre, setFiltre] = useState<Filtre>('enCours')
  const [edition, setEdition] = useState<Emprunt | null>(null)
  const [formulaireOuvert, setFormulaireOuvert] = useState(false)
  const [saisie, setSaisie] = useState<EmpruntSaisie>(nouvelleSaisie)

  const ouvrir = (emprunt: Emprunt | null) => {
    setEdition(emprunt)
    setSaisie(
      emprunt
        ? {
            livreId: emprunt.livreId,
            clientId: emprunt.clientId,
            dateEmprunt: dateInput(emprunt.dateEmprunt),
            dateRetour: dateInput(emprunt.dateRetour),
          }
        : nouvelleSaisie(),
    )
    setFormulaireOuvert(true)
  }

  const enregistrer = async () => {
    if (edition) await api.emprunts.modifier(edition.id, saisie)
    else await api.emprunts.ajouter(saisie)
    await recharger()
  }

  const executer = async (action: () => Promise<void>) => {
    try {
      await action()
      setErreurAction(null)
      await recharger()
    } catch (e) {
      setErreurAction((e as Error).message)
    }
  }

  const retourner = (emprunt: Emprunt) => executer(() => api.emprunts.retourner(emprunt.id))

  const supprimer = (emprunt: Emprunt) => {
    if (!confirm(`Supprimer l'emprunt de « ${emprunt.titleLivre} » par ${emprunt.nomClient} ?`)) return
    void executer(() => api.emprunts.supprimer(emprunt.id))
  }

  const correspondAuFiltre = (e: Emprunt) =>
    filtre === 'tous' ||
    (filtre === 'enCours' && !e.estRendu) ||
    (filtre === 'enRetard' && e.enRetard) ||
    (filtre === 'rendus' && e.estRendu)

  const filtres = emprunts.filter(
    (e) => correspondAuFiltre(e) && contient(recherche, e.titleLivre, e.auteurLivre, e.nomClient, e.email),
  )

  // On peut choisir un livre disponible, ou celui déjà associé à l'emprunt modifié
  const livresSelectionnables = livres.filter((l) => l.disponible || l.id === edition?.livreId)

  const compteurs: Record<Filtre, number> = {
    tous: emprunts.length,
    enCours: emprunts.filter((e) => !e.estRendu).length,
    enRetard: emprunts.filter((e) => e.enRetard).length,
    rendus: emprunts.filter((e) => e.estRendu).length,
  }
  const libelles: Record<Filtre, string> = { enCours: 'En cours', enRetard: 'En retard', rendus: 'Rendus', tous: 'Tous' }

  return (
    <section>
      <header className="entete-page">
        <h1>Emprunts</h1>
        <button onClick={() => ouvrir(null)}>+ Nouvel emprunt</button>
      </header>
      <Alerte message={erreur ?? erreurAction} onFermer={erreurAction ? () => setErreurAction(null) : undefined} />

      <div className="filtres">
        {(Object.keys(libelles) as Filtre[]).map((f) => (
          <button key={f} className={`puce ${filtre === f ? 'active' : ''}`} onClick={() => setFiltre(f)}>
            {libelles[f]} <span className="compteur">{compteurs[f]}</span>
          </button>
        ))}
      </div>
      <Recherche valeur={recherche} onChange={setRecherche} placeholder="Rechercher par livre ou client…" />

      {donnees && (
        <table>
          <thead>
            <tr>
              <th>Livre</th>
              <th>Client</th>
              <th>Emprunté le</th>
              <th>Retour prévu</th>
              <th>Statut</th>
              <th />
            </tr>
          </thead>
          <tbody>
            {filtres.map((e) => (
              <tr key={e.id}>
                <td data-label="Livre">
                  <strong>{e.titleLivre}</strong>
                  <div className="secondaire-texte">{e.auteurLivre}</div>
                </td>
                <td data-label="Client">
                  {e.nomClient}
                  <div className="secondaire-texte">{e.email}</div>
                </td>
                <td data-label="Emprunté le">{formaterDate(e.dateEmprunt)}</td>
                <td data-label="Retour prévu">{formaterDate(e.dateRetour)}</td>
                <td data-label="Statut">
                  {e.estRendu ? (
                    <span className="badge ok">Rendu le {formaterDate(e.dateRetourEffective)}</span>
                  ) : e.enRetard ? (
                    <span className="badge danger">En retard</span>
                  ) : (
                    <span className="badge attention">En cours</span>
                  )}
                </td>
                <td className="actions">
                  {!e.estRendu && (
                    <>
                      <button className="lien" onClick={() => retourner(e)}>Marquer rendu</button>
                      <button className="lien" onClick={() => ouvrir(e)}>Modifier</button>
                    </>
                  )}
                  <button className="lien danger" onClick={() => supprimer(e)}>Supprimer</button>
                </td>
              </tr>
            ))}
            {filtres.length === 0 && (
              <tr>
                <td colSpan={6} className="vide">Aucun emprunt.</td>
              </tr>
            )}
          </tbody>
        </table>
      )}

      <FenetreFormulaire
        titre={edition ? "Modifier l'emprunt" : 'Nouvel emprunt'}
        ouverte={formulaireOuvert}
        onFermer={() => setFormulaireOuvert(false)}
        onValider={enregistrer}
      >
        <Champ libelle="Livre *">
          <select required value={saisie.livreId} onChange={(e) => setSaisie({ ...saisie, livreId: e.target.value })}>
            <option value="">— Choisir un livre disponible —</option>
            {livresSelectionnables.map((l) => (
              <option key={l.id} value={l.id}>
                {l.titre} — {l.auteur}
              </option>
            ))}
          </select>
        </Champ>
        <Champ libelle="Client *">
          <select required value={saisie.clientId} onChange={(e) => setSaisie({ ...saisie, clientId: e.target.value })}>
            <option value="">— Choisir un client —</option>
            {clients.map((c) => (
              <option key={c.id} value={c.id}>
                {c.nom} ({c.email})
              </option>
            ))}
          </select>
        </Champ>
        <div className="ligne">
          <Champ libelle="Date d'emprunt *">
            <input required type="date" value={saisie.dateEmprunt} onChange={(e) => setSaisie({ ...saisie, dateEmprunt: e.target.value })} />
          </Champ>
          <Champ libelle="Retour prévu *">
            <input
              required
              type="date"
              min={saisie.dateEmprunt}
              value={saisie.dateRetour}
              onChange={(e) => setSaisie({ ...saisie, dateRetour: e.target.value })}
            />
          </Champ>
        </div>
      </FenetreFormulaire>
    </section>
  )
}
