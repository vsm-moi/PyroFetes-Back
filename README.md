# PyroFêtes — Système de gestion des stocks et des documents

> Application web de gestion des stocks, fournisseurs, devis, bons de commande et bons de livraison pour l'entreprise **PyroFêtes**.


## Sommaire

- [Contexte](#contexte)
- [Fonctionnalités](#fonctionnalités)
- [Stack technique](#stack-technique)
- [Équipe](#équipe)


## Contexte

PyroFêtes cherchait à remplacer ses processus manuels de gestion des stocks et de génération de documents commerciaux par un outil centralisé. Les objectifs principaux sont :

- Automatiser le réapprovisionnement
- Gérer les fournisseurs et leurs conditions
- Éditer et exporter les documents commerciaux (devis, bons de commande, bons de livraison)
- Assurer un suivi fiable des livraisons et des réceptions


## Fonctionnalités

### Gestion des stocks
- Définition de seuils minimaux par produit
- Visualisation en temps réel du stock courant
- Alertes automatiques en cas de stock sous le seuil
- Génération automatique de bons de commande

### Gestion des fournisseurs
- Enregistrement des fournisseurs (nom, adresse, coordonnées, conditions)
- Gestion des délais de livraison par produit
- Association de plusieurs fournisseurs à un produit (prix + délai)
- Suggestion automatique du fournisseur le plus pertinent

### Devis & Bons de commande
- Création de devis et bons de commande (produits, quantités, prix, remises)
- Personnalisation des documents (logo, message, conditions)
- Export au format **PDF**

### Bons de livraison & Réceptions
- Transformation d'un bon de commande validé en bon de livraison
- Enregistrement des informations de livraison (transporteur, numéro de suivi, dates)
- Alertes en cas de retard de livraison
- Gestion des réceptions avec mise à jour automatique des stocks


## Stack technique

| Couche | Technologie |
|---|---|
| **Front-end** | Angular + NG-ZORRO + Tailwind CSS |
| **Back-end** | C# / .NET |
| **API** | REST (C#) |
| **Base de données** | SQL Server |
| **Gestion des tâches** | YouTrack |
| **Versioning** | Gitea |
| **Communication** | Discord + Présentiel |


## Équipe

| Membre | Rôle |
|---|---|
| Mathys Sanchez-Vendé | Développeur |
| Enzo Norguet | Développeur |
| Cristiano Henrique Gaspar | Développeur |
| Arsène | Développeur |

**Clients :** Mr Thibault Ferrand, Mr Douguet


## Sécurité

- Authentification sécurisée
- Gestion des accès et des permissions par rôle (Commercial / Administrateur)
- Protection des données utilisateurs
