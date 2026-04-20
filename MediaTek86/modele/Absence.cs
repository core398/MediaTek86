using System;

namespace MediaTek86.modele
{
    /// <summary>
    /// Classe représentant une absence d'un personnel
    /// </summary>
    public class Absence
    {
        /// <summary>
        /// Identifiant de l'absence
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Date de début de l'absence
        /// </summary>
        public DateTime DateDebut { get; set; }

        /// <summary>
        /// Date de fin de l'absence
        /// </summary>
        public DateTime DateFin { get; set; }

        /// <summary>
        /// Identifiant du personnel concerné
        /// </summary>
        public int IdPersonnel { get; set; }

        /// <summary>
        /// Identifiant du motif de l'absence
        /// </summary>
        public int IdMotif { get; set; }

        /// <summary>
        /// Libellé du motif de l'absence
        /// </summary>
        public string LibelleMotif { get; set; }

        /// <summary>
        /// Constructeur de la classe Absence
        /// </summary>
        public Absence(int id, DateTime dateDebut, DateTime dateFin, int idPersonnel, int idMotif, string libelleMotif)
        {
            Id = id;
            DateDebut = dateDebut;
            DateFin = dateFin;
            IdPersonnel = idPersonnel;
            IdMotif = idMotif;
            LibelleMotif = libelleMotif;
        }
    }
}