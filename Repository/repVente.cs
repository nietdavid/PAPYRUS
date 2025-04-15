using System;                      // Pour les types de base
using System.Collections.Generic;  // Pour List<>
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;    // Pour SqlConnection, SqlCommand, etc.
using PAPYRUS.Data;
using PAPYRUS.Models;              // Pour utiliser la classe Produit

namespace PAPYRUS.Repository
{
    public class repVente
    {
        private SqlConnection _activeConnection;

        public repVente()
        {
            Connection maConnection = new Connection();
            _activeConnection = maConnection.GetConnection();
        }
        public List<Vente> GetVentes()
        {
            List<Vente> listVentes = new List<Vente>();
            SqlCommand requestGetVentes = _activeConnection.CreateCommand();
            requestGetVentes.CommandText = "SELECT * FROM VENTE";

            SqlDataReader ventes = requestGetVentes.ExecuteReader();
            while (ventes.Read())
            {
                Vente oneVente = new Vente();
                oneVente.Codart = ventes["CODART"].ToString();
                oneVente.Qte1 = Convert.ToInt16(ventes["QTE1"]);
                //oneVente.Prix1 = Convert.ToDecimal(Ventes["PRIX1"]);
                listVentes.Add(oneVente);
            }
            _activeConnection.Close();
            return listVentes;
        }
    }
}