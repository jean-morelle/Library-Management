import { BrowserRouter, NavLink, Navigate, Route, Routes } from 'react-router-dom'
import Clients from './pages/Clients'
import Emprunts from './pages/Emprunts'
import Livres from './pages/Livres'
import TableauDeBord from './pages/TableauDeBord'

const liens = [
  { chemin: '/', libelle: 'Tableau de bord' },
  { chemin: '/livres', libelle: 'Livres' },
  { chemin: '/clients', libelle: 'Clients' },
  { chemin: '/emprunts', libelle: 'Emprunts' },
]

export default function App() {
  return (
    <BrowserRouter>
      <div className="app">
        <nav className="barre">
          <span className="marque">📚 Bibliothèque</span>
          <div className="liens">
            {liens.map((l) => (
              <NavLink key={l.chemin} to={l.chemin} end>
                {l.libelle}
              </NavLink>
            ))}
          </div>
        </nav>
        <main>
          <Routes>
            <Route path="/" element={<TableauDeBord />} />
            <Route path="/livres" element={<Livres />} />
            <Route path="/clients" element={<Clients />} />
            <Route path="/emprunts" element={<Emprunts />} />
            <Route path="*" element={<Navigate to="/" replace />} />
          </Routes>
        </main>
      </div>
    </BrowserRouter>
  )
}
