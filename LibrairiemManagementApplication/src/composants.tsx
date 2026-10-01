import { useState, type FormEvent, type ReactNode } from 'react'

export function Alerte({ message, onFermer }: { message: string | null; onFermer?: () => void }) {
  if (!message) return null
  return (
    <div className="alerte" role="alert">
      <span>{message}</span>
      {onFermer && (
        <button className="lien" onClick={onFermer} aria-label="Fermer">
          ✕
        </button>
      )}
    </div>
  )
}

interface FenetreFormulaireProps {
  titre: string
  ouverte: boolean
  onFermer: () => void
  onValider: () => Promise<void>
  children: ReactNode
}

// Modale contenant un formulaire ; affiche l'erreur renvoyée par l'API sans fermer.
// Le contenu est démonté à la fermeture, ce qui réinitialise l'erreur.
export function FenetreFormulaire({ ouverte, ...props }: FenetreFormulaireProps) {
  return ouverte ? <ContenuFormulaire {...props} /> : null
}

function ContenuFormulaire({ titre, onFermer, onValider, children }: Omit<FenetreFormulaireProps, 'ouverte'>) {
  const [erreur, setErreur] = useState<string | null>(null)
  const [envoi, setEnvoi] = useState(false)

  const soumettre = async (e: FormEvent) => {
    e.preventDefault()
    setEnvoi(true)
    try {
      await onValider()
      onFermer()
    } catch (err) {
      setErreur((err as Error).message)
    } finally {
      setEnvoi(false)
    }
  }

  return (
    <div className="fond-modale" onMouseDown={onFermer}>
      <form className="modale" onSubmit={soumettre} onMouseDown={(e) => e.stopPropagation()}>
        <h2>{titre}</h2>
        <Alerte message={erreur} />
        {children}
        <div className="actions-modale">
          <button type="button" className="secondaire" onClick={onFermer}>
            Annuler
          </button>
          <button type="submit" disabled={envoi}>
            {envoi ? 'Enregistrement…' : 'Enregistrer'}
          </button>
        </div>
      </form>
    </div>
  )
}

export function Champ({ libelle, children }: { libelle: string; children: ReactNode }) {
  return (
    <label className="champ">
      <span>{libelle}</span>
      {children}
    </label>
  )
}

export function Recherche({ valeur, onChange, placeholder }: { valeur: string; onChange: (v: string) => void; placeholder: string }) {
  return (
    <input
      type="search"
      className="recherche"
      value={valeur}
      onChange={(e) => onChange(e.target.value)}
      placeholder={placeholder}
    />
  )
}
