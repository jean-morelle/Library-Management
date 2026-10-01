import { useCallback, useEffect, useState } from 'react'

// Charge des données au montage et expose une fonction pour recharger.
// `charger` doit être une référence stable (fonction déclarée hors du composant).
export function useDonnees<T>(charger: () => Promise<T>) {
  const [donnees, setDonnees] = useState<T | null>(null)
  const [erreur, setErreur] = useState<string | null>(null)

  const recharger = useCallback(
    () =>
      charger().then(
        (resultat) => {
          setDonnees(resultat)
          setErreur(null)
        },
        (e: Error) => setErreur(e.message),
      ),
    [charger],
  )

  useEffect(() => {
    void recharger()
  }, [recharger])

  return { donnees, erreur, recharger }
}

export const contient = (recherche: string, ...valeurs: string[]) => {
  const r = recherche.trim().toLowerCase()
  return !r || valeurs.some((v) => v.toLowerCase().includes(r))
}
