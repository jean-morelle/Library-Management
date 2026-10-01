# Library Management

Application de gestion de bibliothèque : livres, clients et emprunts.

- **Backend** : ASP.NET Core 6 (Web API), EF Core 7, SQL Server LocalDB, architecture Domain / Application / Infrastructure / Api.
- **Frontend** : React 19 + TypeScript (Vite), dossier `LibrairiemManagementApplication/`.

## Fonctionnalités

- Tableau de bord : nombre de livres, livres disponibles, clients, emprunts en cours et en retard.
- Livres : ajout, modification, suppression, recherche, statut disponible / emprunté.
- Clients : ajout, modification, suppression, recherche.
- Emprunts : création (seuls les livres disponibles sont proposés), modification, retour d'un livre, suppression, filtres *En cours / En retard / Rendus / Tous*.

Règles de gestion appliquées par l'API :

- un livre ne peut pas être emprunté deux fois en même temps ;
- la date de retour prévue doit être postérieure ou égale à la date d'emprunt ;
- on ne peut pas supprimer un livre emprunté ni un client qui a un emprunt en cours ;
- un emprunt est **en retard** quand il n'est pas rendu et que la date de retour prévue est passée.

## Prérequis

- SDK .NET 6
- SQL Server LocalDB (installé avec Visual Studio)
- Node.js 20+

## Lancer le projet

### 1. API

```bash
dotnet run --project "Library Management" --launch-profile Library_Management
```

La base `DBBibliotheque` est créée et migrée automatiquement au démarrage.
Swagger : http://localhost:5207/swagger

### 2. Frontend

```bash
cd LibrairiemManagementApplication
npm install
npm run dev
```

Ouvrir http://localhost:5173. Vite redirige les appels `/api` vers `http://localhost:5207`
(modifiable avec la variable d'environnement `API_URL`).

Depuis Visual Studio, on peut aussi démarrer les deux projets ensemble
(*Solution → Configurer les projets de démarrage → Plusieurs projets*).

## Endpoints

| Méthode | Route | Description |
|---|---|---|
| GET / POST | `/api/Livre` | Lister / ajouter des livres |
| GET / PUT / DELETE | `/api/Livre/{id}` | Lire / modifier / supprimer un livre |
| GET / POST | `/api/Client` | Lister / ajouter des clients |
| GET / PUT / DELETE | `/api/Client/{id}` | Lire / modifier / supprimer un client |
| GET / POST | `/api/LivreEmprunter` | Lister / créer des emprunts |
| GET / PUT / DELETE | `/api/LivreEmprunter/{id}` | Lire / modifier / supprimer un emprunt |
| PUT | `/api/LivreEmprunter/{id}/retour` | Marquer un emprunt comme rendu |

Les erreurs métier renvoient un `400` au format ProblemDetails, avec le message dans `detail`.

## Migrations EF Core

Le projet cible .NET 6 : utiliser l'outil local `dotnet-ef` 7 déclaré dans `dotnet-tools.json`.

```bash
dotnet tool restore
dotnet tool run dotnet-ef migrations add NomDeLaMigration --project Library-Management.Infrastructure --startup-project "Library Management"
```
