using System.Collections.Generic;
using MySql.Data.MySqlClient;
using MediaTek86.bddmanager;
using MediaTek86.modele;

namespace MediaTek86.dal
{
    /// <summary>
    /// Classe d'accès aux données pour le personnel et les absences
    /// </summary>
    class PersonnelAccess
    {
        /// <summary>
        /// Instance unique de BddManager
        /// </summary>
        private readonly BddManager bddManager;

        /// <summary>
        /// Constructeur : récupère l'instance de BddManager
        /// </summary>
        public PersonnelAccess()
        {
            bddManager = BddManager.GetInstance();
        }

        /// <summary>
        /// Vérifie les identifiants de connexion
        /// </summary>
        public bool VerifierConnexion(string login, string pwd)
        {
            string req = "SELECT COUNT(*) FROM responsable WHERE login=@login AND pwd=SHA2(@pwd, 256)";
            MySqlParameter[] parameters = {
                new MySqlParameter("@login", login),
                new MySqlParameter("@pwd", pwd)
            };
            MySqlDataReader reader = bddManager.ReqSelect(req, parameters);
            reader.Read();
            int count = reader.GetInt32(0);
            reader.Close();
            return count > 0;
        }

        /// <summary>
        /// Retourne la liste de tout le personnel
        /// </summary>
        public List<Personnel> GetAllPersonnel()
        {
            List<Personnel> listePersonnel = new List<Personnel>();
            string req = "SELECT p.id, p.nom, p.prenom, p.tel, p.mail, p.idService, s.nom as nomService " +
                        "FROM personnel p JOIN service s ON p.idService = s.id " +
                        "ORDER BY p.nom, p.prenom";
            MySqlDataReader reader = bddManager.ReqSelect(req);
            while (reader.Read())
            {
                Personnel personnel = new Personnel(
                    reader.GetInt32("id"),
                    reader.GetString("nom"),
                    reader.GetString("prenom"),
                    reader.GetString("tel"),
                    reader.GetString("mail"),
                    reader.GetInt32("idService"),
                    reader.GetString("nomService")
                );
                listePersonnel.Add(personnel);
            }
            reader.Close();
            return listePersonnel;
        }

        /// <summary>
        /// Retourne la liste des services
        /// </summary>
        public List<Service> GetAllServices()
        {
            List<Service> listeServices = new List<Service>();
            string req = "SELECT id, nom FROM service ORDER BY nom";
            MySqlDataReader reader = bddManager.ReqSelect(req);
            while (reader.Read())
            {
                Service service = new Service(
                    reader.GetInt32("id"),
                    reader.GetString("nom")
                );
                listeServices.Add(service);
            }
            reader.Close();
            return listeServices;
        }

        /// <summary>
        /// Ajoute un nouveau personnel
        /// </summary>
        public void AjouterPersonnel(string nom, string prenom, string tel, string mail, int idService)
        {
            string req = "INSERT INTO personnel (nom, prenom, tel, mail, idService) " +
                        "VALUES (@nom, @prenom, @tel, @mail, @idService)";
            MySqlParameter[] parameters = {
                new MySqlParameter("@nom", nom),
                new MySqlParameter("@prenom", prenom),
                new MySqlParameter("@tel", tel),
                new MySqlParameter("@mail", mail),
                new MySqlParameter("@idService", idService)
            };
            bddManager.ReqUpdate(req, parameters);
        }

        /// <summary>
        /// Modifie un personnel existant
        /// </summary>
        public void ModifierPersonnel(int id, string nom, string prenom, string tel, string mail, int idService)
        {
            string req = "UPDATE personnel SET nom=@nom, prenom=@prenom, tel=@tel, mail=@mail, idService=@idService " +
                        "WHERE id=@id";
            MySqlParameter[] parameters = {
                new MySqlParameter("@nom", nom),
                new MySqlParameter("@prenom", prenom),
                new MySqlParameter("@tel", tel),
                new MySqlParameter("@mail", mail),
                new MySqlParameter("@idService", idService),
                new MySqlParameter("@id", id)
            };
            bddManager.ReqUpdate(req, parameters);
        }

        /// <summary>
        /// Supprime un personnel
        /// </summary>
        public void SupprimerPersonnel(int id)
        {
            string req = "DELETE FROM personnel WHERE id=@id";
            MySqlParameter[] parameters = {
                new MySqlParameter("@id", id)
            };
            bddManager.ReqUpdate(req, parameters);
        }

        /// <summary>
        /// Retourne la liste des absences d'un personnel
        /// </summary>
        public List<Absence> GetAbsencesByPersonnel(int idPersonnel)
        {
            List<Absence> listeAbsences = new List<Absence>();
            string req = "SELECT a.id, a.dateDebut, a.dateFin, a.idPersonnel, a.idMotif, m.libelle " +
                        "FROM absence a JOIN motif m ON a.idMotif = m.id " +
                        "WHERE a.idPersonnel=@idPersonnel " +
                        "ORDER BY a.dateDebut DESC";
            MySqlParameter[] parameters = {
                new MySqlParameter("@idPersonnel", idPersonnel)
            };
            MySqlDataReader reader = bddManager.ReqSelect(req, parameters);
            while (reader.Read())
            {
                Absence absence = new Absence(
                    reader.GetInt32("id"),
                    reader.GetDateTime("dateDebut"),
                    reader.GetDateTime("dateFin"),
                    reader.GetInt32("idPersonnel"),
                    reader.GetInt32("idMotif"),
                    reader.GetString("libelle")
                );
                listeAbsences.Add(absence);
            }
            reader.Close();
            return listeAbsences;
        }

        /// <summary>
        /// Retourne la liste des motifs
        /// </summary>
        public List<Motif> GetAllMotifs()
        {
            List<Motif> listeMotifs = new List<Motif>();
            string req = "SELECT id, libelle FROM motif ORDER BY libelle";
            MySqlDataReader reader = bddManager.ReqSelect(req);
            while (reader.Read())
            {
                Motif motif = new Motif(
                    reader.GetInt32("id"),
                    reader.GetString("libelle")
                );
                listeMotifs.Add(motif);
            }
            reader.Close();
            return listeMotifs;
        }

        /// <summary>
        /// Ajoute une absence en vérifiant le chevauchement
        /// </summary>
        public bool AjouterAbsence(int idPersonnel, System.DateTime dateDebut, System.DateTime dateFin, int idMotif)
        {
            // Vérifier le chevauchement
            if (VerifierChevauchement(idPersonnel, dateDebut, dateFin, -1))
            {
                return false;
            }
            string req = "INSERT INTO absence (dateDebut, dateFin, idPersonnel, idMotif) " +
                        "VALUES (@dateDebut, @dateFin, @idPersonnel, @idMotif)";
            MySqlParameter[] parameters = {
                new MySqlParameter("@dateDebut", dateDebut),
                new MySqlParameter("@dateFin", dateFin),
                new MySqlParameter("@idPersonnel", idPersonnel),
                new MySqlParameter("@idMotif", idMotif)
            };
            bddManager.ReqUpdate(req, parameters);
            return true;
        }

        /// <summary>
        /// Modifie une absence en vérifiant le chevauchement
        /// </summary>
        public bool ModifierAbsence(int id, int idPersonnel, System.DateTime dateDebut, System.DateTime dateFin, int idMotif)
        {
            if (VerifierChevauchement(idPersonnel, dateDebut, dateFin, id))
            {
                return false;
            }
            string req = "UPDATE absence SET dateDebut=@dateDebut, dateFin=@dateFin, idMotif=@idMotif " +
                        "WHERE id=@id";
            MySqlParameter[] parameters = {
                new MySqlParameter("@dateDebut", dateDebut),
                new MySqlParameter("@dateFin", dateFin),
                new MySqlParameter("@idMotif", idMotif),
                new MySqlParameter("@id", id)
            };
            bddManager.ReqUpdate(req, parameters);
            return true;
        }

        /// <summary>
        /// Supprime une absence
        /// </summary>
        public void SupprimerAbsence(int id)
        {
            string req = "DELETE FROM absence WHERE id=@id";
            MySqlParameter[] parameters = {
                new MySqlParameter("@id", id)
            };
            bddManager.ReqUpdate(req, parameters);
        }

        /// <summary>
        /// Vérifie si une absence chevauche une absence existante
        /// </summary>
        private bool VerifierChevauchement(int idPersonnel, System.DateTime dateDebut, System.DateTime dateFin, int idAbsenceExclue)
        {
            string req = "SELECT COUNT(*) FROM absence " +
                        "WHERE idPersonnel=@idPersonnel " +
                        "AND id != @idAbsenceExclue " +
                        "AND dateDebut <= @dateFin " +
                        "AND dateFin >= @dateDebut";
            MySqlParameter[] parameters = {
                new MySqlParameter("@idPersonnel", idPersonnel),
                new MySqlParameter("@idAbsenceExclue", idAbsenceExclue),
                new MySqlParameter("@dateFin", dateFin),
                new MySqlParameter("@dateDebut", dateDebut)
            };
            MySqlDataReader reader = bddManager.ReqSelect(req, parameters);
            reader.Read();
            int count = reader.GetInt32(0);
            reader.Close();
            return count > 0;
        }
    }
}