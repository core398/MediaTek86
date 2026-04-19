using System;
using MySql.Data.MySqlClient;

namespace MediaTek86.bddmanager
{
    /// <summary>
    /// Classe singleton de connexion à la base de données MySQL
    /// </summary>
    class BddManager
    {
        /// <summary>
        /// Instance unique de la classe
        /// </summary>
        private static BddManager instance = null;

        /// <summary>
        /// Objet de connexion MySQL
        /// </summary>
        private MySqlConnection connection = null;

        /// <summary>
        /// Chaîne de connexion à la base de données
        /// </summary>
        private static readonly string connectionString =
            "server=localhost;user id=mediatek86user;password=mdp123;database=mediatek86;";

        /// <summary>
        /// Constructeur privé
        /// </summary>
        private BddManager()
        {
            connection = new MySqlConnection(connectionString);
        }

        /// <summary>
        /// Retourne l'instance unique de BddManager
        /// </summary>
        public static BddManager GetInstance()
        {
            if (instance == null)
            {
                instance = new BddManager();
            }
            return instance;
        }

        /// <summary>
        /// Exécute une requête SELECT et retourne le résultat
        /// </summary>
        public MySqlDataReader ReqSelect(string req, MySqlParameter[] parameters = null)
        {
            MySqlCommand cmd = new MySqlCommand(req, connection);
            if (parameters != null)
            {
                cmd.Parameters.AddRange(parameters);
            }
            connection.Open();
            return cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
        }

        /// <summary>
        /// Exécute une requête INSERT, UPDATE ou DELETE
        /// </summary>
        public void ReqUpdate(string req, MySqlParameter[] parameters = null)
        {
            MySqlCommand cmd = new MySqlCommand(req, connection);
            if (parameters != null)
            {
                cmd.Parameters.AddRange(parameters);
            }
            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
        }
    }
}