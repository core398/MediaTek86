# MediaTek86 - Application de gestion du personnel

## Contexte
Application développée dans le cadre du BTS SIO option SLAM.
Le réseau MediaTek86 gère les médiathèques de la Vienne. 
L'ESN InfoTech Services 86 a été missionnée pour développer une application 
de gestion du personnel des médiathèques.

## But de l'application
Application de bureau en C# permettant au responsable de gérer :
- Le personnel de chaque médiathèque
- Les absences du personnel

## MCD
![MCD]<img width="467" height="451" alt="Capture d&#39;écran 2026-04-20 203509" src="https://github.com/user-attachments/assets/e1282903-24c9-4615-8f2c-5c65a4fb47fd" />


## Interfaces
![Connexion]<img width="242" height="237" alt="Capture d&#39;écran 2026-04-20 200724" src="https://github.com/user-attachments/assets/ab38a1dc-1045-4f55-b070-18737236d384" />
![Liste personnel]<img width="644" height="357" alt="Capture d&#39;écran 2026-04-20 200743" src="https://github.com/user-attachments/assets/350d46fd-d80c-4e16-a88d-f1b5137192e9" />
![Gestion absences]<img width="532" height="295" alt="Capture d&#39;écran 2026-04-20 200818" src="https://github.com/user-attachments/assets/47224825-80f7-4989-990f-161384767f64" />

## Diagramme de paquetages
![Diagramme paquetages]<img width="339" height="477" alt="Capture d&#39;écran 2026-04-20 200927" src="https://github.com/user-attachments/assets/4e8db41c-86a6-42cf-a04f-74ac730645cd" />


## Étapes de construction

### Étape 1 - Préparation environnement et BDD
- Installation WampServer
- Création BDD mediatek86 avec 5 tables
- Alimentation des tables

### Étape 2 - Structure MVC et interfaces visuelles
- Création projet C# Windows Forms
- Structure MVC (vue, modele, controleur, dal, bddmanager)
- Création des interfaces : FrmConnexion, FrmPrincipal, FrmAbsences

### Étape 3 - Modèle, DAL et contrôleur
- Classe BddManager (singleton)
- Classes métiers : Personnel, Absence, Service, Motif
- Classe PersonnelAccess (DAL)
- Classe Controleur

### Étape 4 - Fonctionnalités complètes
- Connexion sécurisée avec SHA2
- CRUD personnel
- CRUD absences avec vérification chevauchement
- FrmAjoutPersonnel et FrmAjoutAbsence

### Étape 5 - Vidéo démonstration
- Démonstration de toutes les fonctionnalités

### Étape 6 - Déploiement
- Création installeur
- Script SQL complet
- README
- Page portfolio

## Installation
1. Installer WampServer
2. Importer le script SQL `mediatek86.sql` dans phpMyAdmin
3. Lancer `MediaTek86Installeur.msi`
4. Login : `admin` / Mot de passe : `admin123`

## Documentation utilisateur
Voir la vidéo de démonstration sur la page portfolio.
