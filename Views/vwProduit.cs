// On importe les namespaces nécessaires pour utiliser les classes de base (System), 
// la gestion des collections (System.Collections.Generic) et la classe Produit dans PAPYRUS.Models.
using System;
using System.Collections.Generic;
using System.Linq;             // (Optionnel : utilisé si des opérations LINQ sont faites)
using System.Text;             // (Optionnel : pour manipuler des chaînes)
using System.Threading.Tasks;  // (Optionnel : pour la programmation asynchrone)
using PAPYRUS.Models;         // Permet d'utiliser la classe Produit définie dans le namespace PAPYRUS.Models

// Déclare le namespace PAPYRUS.Views, qui regroupe toutes les classes concernant l'affichage/interface.
namespace PAPYRUS.Views
{
    // Déclaration de la classe vwProduit qui gère l'affichage (la vue) pour les produits dans l'application console.
    public class vwProduit
    {
        // Méthode qui affiche le menu principal dans la console.
        public void AfficherMenu()
        {
            // Efface l'affichage précédent de la console pour repartir sur un écran clair.
            Console.Clear();
            // Affiche un message de bienvenue.
            Console.WriteLine("Bienvenue dans le gestionnaire de produits");
            Console.WriteLine();
            // Affiche le titre du menu.
            Console.WriteLine("=== Menu ===");
            // Liste des options disponibles pour l'utilisateur.
            Console.WriteLine("1. Ajouter un produit");
            Console.WriteLine("2. Supprimer un produit");
            Console.WriteLine("3. Modifier un produit");
            Console.WriteLine("4. Lister tous les produits");
            Console.WriteLine("5. Voir un produit par son code");
            Console.WriteLine("0. Quitter");
            // Affiche le message pour inviter l'utilisateur à entrer son choix sans passer à la ligne (Console.Write n'ajoute pas de saut de ligne).
            Console.Write("Votre choix : ");
        }

        // Méthode qui lit le choix de l'utilisateur au clavier et le retourne en tant que chaîne.
        // Le "?" indique que la chaîne retournée peut être null, si l'utilisateur ne saisit rien par exemple.
        public string? LireChoix()
        {
            return Console.ReadLine();
        }

        // Méthode qui demande à l'utilisateur de saisir les informations d'un produit et retourne un objet Produit créé avec ces informations.
        public Produit SaisirProduit()
        {
            // Demande la saisie du code article et lit la réponse depuis la console.
            Console.Write("Code article : ");
            // Si la réponse est null, on utilise une chaîne vide grâce à l'opérateur null-coalescent (??).
            string codeArticle = Console.ReadLine() ?? "";

            // Demande la saisie du libellé du produit.
            Console.Write("Libellé : ");
            string libelleArticle = Console.ReadLine() ?? "";

            // Demande la saisie du stock alloué et convertit la saisie en type short.
            Console.Write("Stock alloué : ");
            // Convertit la saisie en short ; si null, on utilise "0" par défaut.
            short stockAlloue = Convert.ToInt16(Console.ReadLine() ?? "0");

            // Demande la saisie du stock physique et convertit la saisie en type short.
            Console.Write("Stock physique : ");
            short stockPhysique = Convert.ToInt16(Console.ReadLine() ?? "0");

            // Demande la saisie de la quantité annuelle et convertit la saisie en type short.
            Console.Write("Quantité annuelle : ");
            short quantiteAnnuelle = Convert.ToInt16(Console.ReadLine() ?? "0");

            // Demande la saisie de l'unité de mesure et lit la réponse.
            Console.Write("Unité de mesure : ");
            string uniteMesure = Console.ReadLine() ?? "";

            // Crée et retourne un nouvel objet Produit en utilisant le constructeur de la classe Produit avec les données saisies.
            return new Produit(codeArticle, libelleArticle, stockAlloue, stockPhysique, quantiteAnnuelle, uniteMesure);
        }

        // Méthode qui affiche un message personnalisé pour demander la saisie d'un code produit.
        public string SaisirCodeProduit(string message)
        {
            // Affiche le message passé en paramètre (ex: "Entrez le code du produit : ").
            Console.Write(message);
            // Retourne la saisie de l'utilisateur (si null, retourne une chaîne vide grâce au null-coalescent).
            return Console.ReadLine() ?? "";
        }

        // Méthode qui affiche les détails d'un produit dans la console.
        public void AfficherProduit(Produit produit)
        {
            // Affiche une ligne vide et un titre indiquant qu'un produit a été trouvé.
            Console.WriteLine();
            Console.WriteLine("Produit trouvé :");
            // Affiche le code du produit en utilisant l'interpolation de chaîne.
            Console.WriteLine($"Code : {produit.Codart}");
            // Affiche le libellé du produit.
            Console.WriteLine($"Libellé : {produit.Libart}");
            // Affiche le stock alloué.
            Console.WriteLine($"Stock alloué : {produit.Stkale}");
            // Affiche le stock physique.
            Console.WriteLine($"Stock physique : {produit.Stkphy}");
            // Affiche la quantité annuelle.
            Console.WriteLine($"Quantité annuelle : {produit.Qteann}");
            // Affiche l'unité de mesure.
            Console.WriteLine($"Unité : {produit.Unimes}");
        }

        // Méthode qui affiche la liste de plusieurs produits dans la console.
        public void AfficherListeProduits(List<Produit> produits)
        {
            // Vérifie si la liste est vide.
            if (produits.Count == 0)
            {
                // Affiche un message indiquant qu'aucun produit n'a été trouvé.
                Console.WriteLine("Aucun produit trouvé.");
            }
            else
            {
                // Affiche un titre pour la liste des produits.
                Console.WriteLine();
                Console.WriteLine("Liste des produits :");
                // Parcourt chaque produit de la liste.
                foreach (Produit produit in produits)
                {
                    // Affiche le code et le libellé de chaque produit, séparés par un "|".
                    Console.WriteLine($"Code : {produit.Codart} | Libellé : {produit.Libart}");
                }
            }
        }

        // Méthode qui affiche un message générique et attend que l'utilisateur appuie sur une touche.
        public void AfficherMessage(string message)
        {
            // Affiche le message passé en paramètre.
            Console.WriteLine(message);
            // Affiche un message invitant l'utilisateur à appuyer sur une touche pour revenir au menu.
            Console.WriteLine();
            Console.WriteLine("Appuyez sur une touche pour revenir au menu...");
            // Attend que l'utilisateur appuie sur une touche (bloque l'exécution jusqu'à ce qu'une touche soit pressée).
            Console.ReadKey();
        }
    }
}