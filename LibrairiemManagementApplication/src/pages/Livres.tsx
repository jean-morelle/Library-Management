import { useState } from 'react'
import { api, type Livre, type LivreSaisie } from '../api'
import { Alerte, Champ, FenetreFormulaire, Recherche } from '../composants'
import { contient, useDonnees } from '../outils'

const vide: LivreSaisie = { titre: '', auteur: '', genre: '' }

export default function Livres() {
  const { donnees: livres, erreur, recharger } = useDonnees(api.livres.lister)
  const [erreurAction, setErreurAction] = useState<string | null>(null)
  const [recherche, setRecherche] = useState('')
  const [edition, setEdition] = useState<Livre | null>(null)
  const [formulaireOuvert, setFormulaireOuvert] = useState(false)
  const [saisie, setSaisie] = useState<LivreSaisie>(vide)

  const ouvrir = (livre: Livre | null) => {
    setEdition(livre)
    setSaisie(livre ? { titre: livre.titre, auteur: livre.auteur, genre: livre.genre } : vide)
    setFormulaireOuvert(true)
  }

  const enregistrer = async () => {
    if (edition) await api.livres.modifier(edition.id, saisie)
    else await api.livres.ajouter(saisie)
    await recharger()
  }

  const supprimer = async (livre: Livre) => {
    if (!confirm(`Supprimer « ${livre.titre} » ?`)) return
    try {
      await api.livres.supprimer(livre.id)
      setErreurAction(null)
      await recharger()
    } catch (e) {
      setErreurAction((e as Error).message)
    }
  }

  const filtres = (livres ?? []).filter((l) => contient(recherche, l.titre, l.auteur, l.genre))

  return (
    <section>
      <header className="entete-page">
        <h1>Livres</h1>
        <button onClick={() => ouvrir(null)}>+ Ajouter un livre</button>
      </header>
      <Alerte message={erreur ?? erreurAction} onFermer={erreurAction ? () => setErreurAction(null) : undefined} />
      <Recherche valeur={recherche} onChange={setRecherche} placeholder="Rechercher par titre, auteur ou genre…" />

      {livres && (
        <table>
          <thead>
            <tr>
              <th>Titre</th>
              <th>Auteur</th>
              <th>Genre</th>
              <th>Statut</th>
              <th />
            </tr>
          </thead>
          <tbody>
            {filtres.map((livre) => (
              <tr key={livre.id}>
                <td data-label="Titre">{livre.titre}</td>
                <td data-label="Auteur">{livre.auteur}</td>
                <td data-label="Genre">{livre.genre || '—'}</td>
                <td data-label="Statut">
                  <span className={`badge ${livre.disponible ? 'ok' : 'attention'}`}>
                    {livre.disponible ? 'Disponible' : 'Emprunté'}
                  </span>
                </td>
                <td className="actions">
                  <button className="lien" onClick={() => ouvrir(livre)}>Modifier</button>
                  <button className="lien danger" onClick={() => supprimer(livre)}>Supprimer</button>
                </td>
              </tr>
            ))}
            {filtres.length === 0 && (
              <tr>
                <td colSpan={5} className="vide">Aucun livre.</td>
              </tr>
            )}
          </tbody>
        </table>
      )}

      <FenetreFormulaire
        titre={edition ? 'Modifier le livre' : 'Nouveau livre'}
        ouverte={formulaireOuvert}
        onFermer={() => setFormulaireOuvert(false)}
        onValider={enregistrer}
      >
        <Champ libelle="Titre *">
          <input required autoFocus value={saisie.titre} onChange={(e) => setSaisie({ ...saisie, titre: e.target.value })} />
        </Champ>
        <Champ libelle="Auteur *">
          <input required value={saisie.auteur} onChange={(e) => setSaisie({ ...saisie, auteur: e.target.value })} />
        </Champ>
        <Champ libelle="Genre">
          <input value={saisie.genre} onChange={(e) => setSaisie({ ...saisie, genre: e.target.value })} />
        </Champ>
      </FenetreFormulaire>
    </section>
  )
}
