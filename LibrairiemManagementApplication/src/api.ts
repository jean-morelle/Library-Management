// Client HTTP pour l'API Library Management

export interface Livre {
  id: string
  titre: string
  auteur: string
  genre: string
  disponible: boolean
}

export type LivreSaisie = Pick<Livre, 'titre' | 'auteur' | 'genre'>

export interface Client {
  id: string
  nom: string
  numeroTelephone: string
  email: string
  quartier: string
}

export type ClientSaisie = Omit<Client, 'id'>

export interface Emprunt {
  id: string
  dateEmprunt: string
  dateRetour: string
  dateRetourEffective: string | null
  estRendu: boolean
  enRetard: boolean
  livreId: string
  titleLivre: string
  auteurLivre: string
  genre: string
  clientId: string
  nomClient: string
  email: string
  quartier: string
}

export interface EmpruntSaisie {
  livreId: string
  clientId: string
  dateEmprunt: string
  dateRetour: string
}

export class ApiError extends Error {}

// Transforme une réponse d'erreur ASP.NET (ProblemDetails ou texte) en message lisible
async function lireErreur(response: Response): Promise<string> {
  const texte = await response.text()
  try {
    const probleme = JSON.parse(texte)
    if (probleme.errors) {
      return Object.values(probleme.errors as Record<string, string[]>).flat().join(' ')
    }
    return probleme.detail ?? probleme.title ?? texte
  } catch {
    return texte || `Erreur ${response.status}`
  }
}

async function requete<T>(url: string, init?: RequestInit): Promise<T> {
  let response: Response
  try {
    response = await fetch(`/api${url}`, {
      ...init,
      headers: init?.body ? { 'Content-Type': 'application/json' } : undefined,
    })
  } catch {
    throw new ApiError("Impossible de joindre l'API. Est-elle démarrée ?")
  }
  if (!response.ok) {
    throw new ApiError(await lireErreur(response))
  }
  return (response.status === 204 ? undefined : await response.json()) as T
}

const envoyer = <T>(methode: string, url: string, corps?: unknown) =>
  requete<T>(url, { method: methode, body: corps === undefined ? undefined : JSON.stringify(corps) })

export const api = {
  livres: {
    lister: () => requete<Livre[]>('/Livre'),
    ajouter: (livre: LivreSaisie) => envoyer<Livre>('POST', '/Livre', livre),
    modifier: (id: string, livre: LivreSaisie) => envoyer<void>('PUT', `/Livre/${id}`, livre),
    supprimer: (id: string) => envoyer<void>('DELETE', `/Livre/${id}`),
  },
  clients: {
    lister: () => requete<Client[]>('/Client'),
    ajouter: (client: ClientSaisie) => envoyer<Client>('POST', '/Client', client),
    modifier: (id: string, client: ClientSaisie) => envoyer<void>('PUT', `/Client/${id}`, client),
    supprimer: (id: string) => envoyer<void>('DELETE', `/Client/${id}`),
  },
  emprunts: {
    lister: () => requete<Emprunt[]>('/LivreEmprunter'),
    ajouter: (emprunt: EmpruntSaisie) => envoyer<Emprunt>('POST', '/LivreEmprunter', emprunt),
    modifier: (id: string, emprunt: EmpruntSaisie) => envoyer<void>('PUT', `/LivreEmprunter/${id}`, emprunt),
    retourner: (id: string) => envoyer<void>('PUT', `/LivreEmprunter/${id}/retour`),
    supprimer: (id: string) => envoyer<void>('DELETE', `/LivreEmprunter/${id}`),
  },
}

export const formaterDate = (iso: string | null) =>
  iso ? new Date(iso).toLocaleDateString('fr-FR') : '—'

// yyyy-MM-dd pour les <input type="date">
export const dateInput = (date: Date | string) => {
  const d = typeof date === 'string' ? new Date(date) : date
  const local = new Date(d.getTime() - d.getTimezoneOffset() * 60000)
  return local.toISOString().slice(0, 10)
}
