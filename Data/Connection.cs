using System;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace PAPYRUS.Data
{
    // La classe Connection gère la création d'une connexion SQL.
    internal class Connection
    {
        // Champ pour stocker la chaîne de connexion récupérée depuis la configuration.
        private readonly string _connectionString;

        // Constructeur de la classe Connection.
        public Connection()
        {
            // On crée un ConfigurationBuilder qui lit d'abord appsettings.json, puis éventuellement les variables d'environnement.
            // Ici, nous utilisons AppContext.BaseDirectory pour définir le répertoire de base, afin d'être certain d'avoir le bon chemin vers appsettings.json.
            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)  // Utilise AppContext.BaseDirectory au lieu de Directory.GetCurrentDirectory().
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true) // Charge le fichier JSON.
                .AddEnvironmentVariables()  // Ajoute les variables d'environnement à la configuration.
                .Build();  // Construit l'objet de configuration.

            // Récupération de la chaîne de connexion nommée "PapyrusDb" depuis la section "ConnectionStrings".
            _connectionString = configuration.GetConnectionString("PapyrusDb");
        }

        // Méthode qui retourne une connexion SQL ouverte.
        public SqlConnection GetConnection()
        {
            // Crée une nouvelle instance de SqlConnection à partir de la chaîne de connexion lue.
            SqlConnection connection = new SqlConnection(_connectionString);
            // Ouvre la connexion.
            connection.Open();
            // Retourne la connexion ouverte.
            return connection;
        }
    }
}
