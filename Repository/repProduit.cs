using System;                      // Pour les types de base
using System.Collections.Generic;  // Pour List<>
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;    // Pour SqlConnection, SqlCommand, etc.
using PAPYRUS.Models;              // Pour utiliser la classe Produit


namespace PAPYRUS.Repository
{
    public class repProduit
    {
        //Connexion active à la base de données (ouverte via la classe Connection.cs)
        private SqlConnection _activeConnection;

        //Constructeur : crée la connexion quand on instancie la classe repProduit
        public repProduit()
        {
            Connection maConnection = new Connection();
            _activeConnection = maConnection.GetConnection(); // la connexion est ouverte ici
        }

        //CREATE : Ajouter un produit à la base
        public void AddProduit(Produit produit)
        {
            SqlCommand requestAddProduit = _activeConnection.CreateCommand();

            requestAddProduit.CommandText = @"INSERT INTO PRODUIT (CODART, LIBART, STKALE, STKPHY, QTEANN, UNIMES)
                                              VALUES (@codart, @libart, @stkale, @stkphy, @qteann, @unimes)";

            // Liaison des paramètres
            requestAddProduit.Parameters.AddWithValue("@codart", produit.Codart);
            requestAddProduit.Parameters.AddWithValue("@libart", produit.Libart);
            requestAddProduit.Parameters.AddWithValue("@stkale", produit.Stkale);
            requestAddProduit.Parameters.AddWithValue("@stkphy", produit.Stkphy);
            requestAddProduit.Parameters.AddWithValue("@qteann", produit.Qteann);
            requestAddProduit.Parameters.AddWithValue("@unimes", produit.Unimes);

            // Exécution de la commande INSERT
            requestAddProduit.ExecuteNonQuery();
        }

        //DELETE : Supprimer un produit par son code
        public void DeleteProduit(string codart)
        {
            SqlCommand requestDeleteProduit = _activeConnection.CreateCommand();
            requestDeleteProduit.CommandText = "DELETE FROM PRODUIT WHERE CODART = @codart";
            requestDeleteProduit.Parameters.AddWithValue("@codart", codart);
            requestDeleteProduit.ExecuteNonQuery();
        }

        //UPDATE : Modifier un produit existant
        public void UpdateProduit(Produit produit)
        {
            SqlCommand requestUpdateProduit = _activeConnection.CreateCommand();

            requestUpdateProduit.CommandText = @"UPDATE PRODUIT SET 
                                                    LIBART = @libart,
                                                    STKALE = @stkale,
                                                    STKPHY = @stkphy,
                                                    QTEANN = @qteann,
                                                    UNIMES = @unimes
                                                 WHERE CODART = @codart";

            requestUpdateProduit.Parameters.AddWithValue("@libart", produit.Libart);
            requestUpdateProduit.Parameters.AddWithValue("@stkale", produit.Stkale);
            requestUpdateProduit.Parameters.AddWithValue("@stkphy", produit.Stkphy);
            requestUpdateProduit.Parameters.AddWithValue("@qteann", produit.Qteann);
            requestUpdateProduit.Parameters.AddWithValue("@unimes", produit.Unimes);
            requestUpdateProduit.Parameters.AddWithValue("@codart", produit.Codart);

            requestUpdateProduit.ExecuteNonQuery();
        }

        //READ : Lire tous les produits
        public List<Produit> GetProduits()
        {
            List<Produit> listProduits = new List<Produit>();

            SqlCommand requestGetProduits = _activeConnection.CreateCommand();
            requestGetProduits.CommandText = "SELECT * FROM PRODUIT";

            SqlDataReader produits = requestGetProduits.ExecuteReader();

            while (produits.Read())
            {
                Produit oneProduit = new Produit
                {
                    Codart = produits["CODART"]?.ToString() ?? "",
                    Libart = produits["LIBART"]?.ToString() ?? "",
                    Stkale = Convert.ToInt16(produits["STKALE"]),
                    Stkphy = Convert.ToInt16(produits["STKPHY"]),
                    Qteann = Convert.ToInt16(produits["QTEANN"]),
                    Unimes = produits["UNIMES"]?.ToString() ?? ""
                };

                listProduits.Add(oneProduit);
            }

            produits.Close(); //on ferme le DataReader, mais pas la connexion SQL ici
            return listProduits;
        }

        //READ : Récupérer un produit spécifique par son code article
        public Produit GetProduitParCode(string codart)
        {
            Produit oneProduit = null;

            SqlCommand requestGetProduit = _activeConnection.CreateCommand();
            requestGetProduit.CommandText = "SELECT * FROM PRODUIT WHERE CODART = @codart";
            requestGetProduit.Parameters.AddWithValue("@codart", codart);

            SqlDataReader produits = requestGetProduit.ExecuteReader();

            if (produits.Read())
            {
                oneProduit = new Produit
                {
                    Codart = produits["CODART"]?.ToString() ?? "",
                    Libart = produits["LIBART"]?.ToString() ?? "",
                    Stkale = Convert.ToInt16(produits["STKALE"]),
                    Stkphy = Convert.ToInt16(produits["STKPHY"]),
                    Qteann = Convert.ToInt16(produits["QTEANN"]),
                    Unimes = produits["UNIMES"]?.ToString() ?? ""
                };
            }

            produits.Close();
            return oneProduit; // peut être null si rien trouvé
        }
    }
}
