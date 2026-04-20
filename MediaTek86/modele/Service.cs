namespace MediaTek86.modele
{
    /// <summary>
    /// Classe représentant un service de la médiathèque
    /// </summary>
    public class Service
    {
        /// <summary>
        /// Identifiant du service
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Nom du service
        /// </summary>
        public string Nom { get; set; }

        /// <summary>
        /// Constructeur de la classe Service
        /// </summary>
        public Service(int id, string nom)
        {
            Id = id;
            Nom = nom;
        }

        /// <summary>
        /// Retourne le nom du service (utile pour les listes déroulantes)
        /// </summary>
        public override string ToString()
        {
            return Nom;
        }
    }
}