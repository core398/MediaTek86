using System.Collections.Generic;
using MediaTek86.dal;
using MediaTek86.modele;

namespace MediaTek86.controleur
{
    /// <summary>
    /// Contrôleur principal de l'application
    /// </summary>
    class Controleur
    {
        /// <summary>
        /// Instance unique du contrôleur
        /// </summary>
        private static Controleur instance = null;

        /// <summary>
        /// Accès aux données
        /// </summary>
        private readonly PersonnelAccess personnelAccess;

        /// <summary>
        /// Constructeur privé
        /// </summary>
        private Controleur()
        {
            personnelAccess = new PersonnelAccess();
        }

        /// <summary>
        /// Retourne l'instance unique du contrôleur
        /// </summary>
        public static Controleur GetInstance()
        {
            if (instance == null)
            {
                instance = new Controleur();
            }
            return instance;
        }

        /// <summary>
        /// Vérifie les identifiants de connexion
        /// </summary>
        public bool VerifierConnexion(string login, string pwd)
        {
            return personnelAccess.VerifierConnexion(login, pwd);
        }

        /// <summary>
        /// Retourne la liste de tout le personnel
        /// </summary>
        public List<Personnel> GetAllPersonnel()
        {
            return personnelAccess.GetAllPersonnel();
        }

        /// <summary>
        /// Retourne la liste des services
        /// </summary>
        public List<Service> GetAllServices()
        {
            return personnelAccess.GetAllServices();
        }

        /// <summary>
        /// Ajoute un nouveau personnel
        /// </summary>
        public void AjouterPersonnel(string nom, string prenom, string tel, string mail, int idService)
        {
            personnelAccess.AjouterPersonnel(nom, prenom, tel, mail, idService);
        }

        /// <summary>
        /// Modifie un personnel existant
        /// </summary>
        public void ModifierPersonnel(int id, string nom, string prenom, string tel, string mail, int idService)
        {
            personnelAccess.ModifierPersonnel(id, nom, prenom, tel, mail, idService);
        }

        /// <summary>
        /// Supprime un personnel
        /// </summary>
        public void SupprimerPersonnel(int id)
        {
            personnelAccess.SupprimerPersonnel(id);
        }

        /// <summary>
        /// Retourne la liste des absences d'un personnel
        /// </summary>
        public List<Absence> GetAbsencesByPersonnel(int idPersonnel)
        {
            return personnelAccess.GetAbsencesByPersonnel(idPersonnel);
        }

        /// <summary>
        /// Retourne la liste des motifs
        /// </summary>
        public List<Motif> GetAllMotifs()
        {
            return personnelAccess.GetAllMotifs();
        }

        /// <summary>
        /// Ajoute une absence
        /// </summary>
        public bool AjouterAbsence(int idPersonnel, System.DateTime dateDebut, System.DateTime dateFin, int idMotif)
        {
            return personnelAccess.AjouterAbsence(idPersonnel, dateDebut, dateFin, idMotif);
        }

        /// <summary>
        /// Modifie une absence
        /// </summary>
        public bool ModifierAbsence(int id, int idPersonnel, System.DateTime dateDebut, System.DateTime dateFin, int idMotif)
        {
            return personnelAccess.ModifierAbsence(id, idPersonnel, dateDebut, dateFin, idMotif);
        }

        /// <summary>
        /// Supprime une absence
        /// </summary>
        public void SupprimerAbsence(int id)
        {
            personnelAccess.SupprimerAbsence(id);
        }
    }
}