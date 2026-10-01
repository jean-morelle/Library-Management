import { useState } from 'react'
import { api, type Client, type ClientSaisie } from '../api'
import { Alerte, Champ, FenetreFormulaire, Recherche } from '../composants'
import { contient, useDonnees } from '../outils'

const vide: ClientSaisie = { nom: '', numeroTelephone: '', email: '', quartier: '' }

export default function Clients() {
  const { donnees: clients, erreur, recharger } = useDonnees(api.clients.lister)
  const [erreurAction, setErreurAction] = useState<string | null>(null)
  const [recherche, setRecherche] = useState('')
  const [edition, setEdition] = useState<Client | null>(null)
  const [formulaireOuvert, setFormulaireOuvert] = useState(false)
  const [saisie, setSaisie] = useState<ClientSaisie>(vide)

  const ouvrir = (client: Client | null) => {
    setEdition(client)
    setSaisie(client ? { nom: client.nom, numeroTelephone: client.numeroTelephone, email: client.email, quartier: client.quartier } : vide)
    setFormulaireOuvert(true)
  }

  const enregistrer = async () => {
    if (edition) await api.clients.modifier(edition.id, saisie)
    else await api.clients.ajouter(saisie)
    await recharger()
  }

  const supprimer = async (client: Client) => {
    if (!confirm(`Supprimer le client « ${client.nom} » ?`)) return
    try {
      await api.clients.supprimer(client.id)
      setErreurAction(null)
      await recharger()
    } catch (e) {
      setErreurAction((e as Error).message)
    }
  }

  const filtres = (clients ?? []).filter((c) => contient(recherche, c.nom, c.email, c.quartier, c.numeroTelephone))

  return (
    <section>
      <header className="entete-page">
        <h1>Clients</h1>
        <button onClick={() => ouvrir(null)}>+ Ajouter un client</button>
      </header>
      <Alerte message={erreur ?? erreurAction} onFermer={erreurAction ? () => setErreurAction(null) : undefined} />
      <Recherche valeur={recherche} onChange={setRecherche} placeholder="Rechercher par nom, email, quartier…" />

      {clients && (
        <table>
          <thead>
            <tr>
              <th>Nom</th>
              <th>Téléphone</th>
              <th>Email</th>
              <th>Quartier</th>
              <th />
            </tr>
          </thead>
          <tbody>
            {filtres.map((client) => (
              <tr key={client.id}>
                <td data-label="Nom">{client.nom}</td>
                <td data-label="Téléphone">{client.numeroTelephone || '—'}</td>
                <td data-label="Email">{client.email}</td>
                <td data-label="Quartier">{client.quartier || '—'}</td>
                <td className="actions">
                  <button className="lien" onClick={() => ouvrir(client)}>Modifier</button>
                  <button className="lien danger" onClick={() => supprimer(client)}>Supprimer</button>
                </td>
              </tr>
            ))}
            {filtres.length === 0 && (
              <tr>
                <td colSpan={5} className="vide">Aucun client.</td>
              </tr>
            )}
          </tbody>
        </table>
      )}

      <FenetreFormulaire
        titre={edition ? 'Modifier le client' : 'Nouveau client'}
        ouverte={formulaireOuvert}
        onFermer={() => setFormulaireOuvert(false)}
        onValider={enregistrer}
      >
        <Champ libelle="Nom *">
          <input required autoFocus value={saisie.nom} onChange={(e) => setSaisie({ ...saisie, nom: e.target.value })} />
        </Champ>
        <Champ libelle="Email *">
          <input required type="email" value={saisie.email} onChange={(e) => setSaisie({ ...saisie, email: e.target.value })} />
        </Champ>
        <Champ libelle="Téléphone">
          <input type="tel" value={saisie.numeroTelephone} onChange={(e) => setSaisie({ ...saisie, numeroTelephone: e.target.value })} />
        </Champ>
        <Champ libelle="Quartier">
          <input value={saisie.quartier} onChange={(e) => setSaisie({ ...saisie, quartier: e.target.value })} />
        </Champ>
      </FenetreFormulaire>
    </section>
  )
}
