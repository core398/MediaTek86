namespace MediaTek86.modele
{
    /// <summary>
    /// Classe représentant un motif d'absence
    /// </summary>
    public class Motif
    {
        /// <summary>
        /// Identifiant du motif
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Libellé du motif
        /// </summary>
        public string Libelle { get; set; }

        /// <summary>
        /// Constructeur de la classe Motif
        /// </summary>
        public Motif(int id, string libelle)
        {
            Id = id;
            Libelle = libelle;
        }

        /// <summary>
        /// Retourne le libellé du motif (utile pour les listes déroulantes)
        /// </summary>
        public override string ToString()
        {
            return Libelle;
        }
    }
}