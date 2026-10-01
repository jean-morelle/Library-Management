import { Link } from 'react-router-dom'
import { api, formaterDate } from '../api'
import { Alerte } from '../composants'
import { useDonnees } from '../outils'

const chargerTout = () => Promise.all([api.livres.lister(), api.clients.lister(), api.emprunts.lister()])

export default function TableauDeBord() {
  const { donnees, erreur } = useDonnees(chargerTout)
  const [livres, clients, emprunts] = donnees ?? [[], [], []]

  const enCours = emprunts.filter((e) => !e.estRendu)
  const enRetard = emprunts.filter((e) => e.enRetard)

  const indicateurs = [
    { libelle: 'Livres', valeur: livres.length, lien: '/livres' },
    { libelle: 'Disponibles', valeur: livres.filter((l) => l.disponible).length, lien: '/livres' },
    { libelle: 'Clients', valeur: clients.length, lien: '/clients' },
    { libelle: 'Emprunts en cours', valeur: enCours.length, lien: '/emprunts' },
    { libelle: 'En retard', valeur: enRetard.length, lien: '/emprunts', alerte: enRetard.length > 0 },
  ]

  return (
    <section>
      <header className="entete-page">
        <h1>Tableau de bord</h1>
      </header>
      <Alerte message={erreur} />

      <div className="indicateurs">
        {indicateurs.map((i) => (
          <Link key={i.libelle} to={i.lien} className={`indicateur ${i.alerte ? 'alerte-indicateur' : ''}`}>
            <span className="valeur">{donnees ? i.valeur : '…'}</span>
            <span className="libelle">{i.libelle}</span>
          </Link>
        ))}
      </div>

      <h2>Retours en retard</h2>
      {enRetard.length === 0 ? (
        <p className="vide">Aucun retard 🎉</p>
      ) : (
        <table>
          <thead>
            <tr>
              <th>Livre</th>
              <th>Client</th>
              <th>Retour prévu</th>
            </tr>
          </thead>
          <tbody>
            {enRetard.map((e) => (
              <tr key={e.id}>
                <td data-label="Livre">{e.titleLivre}</td>
                <td data-label="Client">{e.nomClient} — {e.email}</td>
                <td data-label="Retour prévu">{formaterDate(e.dateRetour)}</td>
              </tr>
            ))}
          </tbody>
        </table>
      )}
    </section>
  )
}
