namespace MediaTek86.modele
{
    /// <summary>
    /// Classe représentant un personnel de la médiathèque
    /// </summary>
    class Personnel
    {
        /// <summary>
        /// Identifiant du personnel
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Nom du personnel
        /// </summary>
        public string Nom { get; set; }

        /// <summary>
        /// Prénom du personnel
        /// </summary>
        public string Prenom { get; set; }

        /// <summary>
        /// Téléphone du personnel
        /// </summary>
        public string Tel { get; set; }

        /// <summary>
        /// Mail du personnel
        /// </summary>
        public string Mail { get; set; }

        /// <summary>
        /// Identifiant du service du personnel
        /// </summary>
        public int IdService { get; set; }

        /// <summary>
        /// Nom du service du personnel
        /// </summary>
        public string NomService { get; set; }

        /// <summary>
        /// Constructeur de la classe Personnel
        /// </summary>
        public Personnel(int id, string nom, string prenom, string tel, string mail, int idService, string nomService)
        {
            Id = id;
            Nom = nom;
            Prenom = prenom;
            Tel = tel;
            Mail = mail;
            IdService = idService;
            NomService = nomService;
        }
    }
}