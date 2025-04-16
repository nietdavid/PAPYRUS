// On importe les namespaces nécessaires pour utiliser des classes de base (System),
// des collections génériques (List<T>), la classe de modèle Produit, la couche Business (bsProduit)
// et la Vue (vwProduit) pour l'interface utilisateur en console.
using System;
using System.Collections.Generic;
using PAPYRUS.Models;     // Contient la classe Produit.
using PAPYRUS.Business;   // Contient la logique métier (classe bsProduit).
using PAPYRUS.Views;      // Contient la vue (classe vwProduit).

// On déclare le namespace PAPYRUS.Controllers pour regrouper les classes de contrôleurs.
namespace PAPYRUS.Controllers
{
    // Déclaration de la classe ctrlProduit, qui constitue le contrôleur pour la gestion des produits.
    // Le contrôleur orchestre le flux d'information entre la vue (interface utilisateur) et la couche Business.
    public class ctrlProduit
    {
        // Champ privé qui contient l'instance de la vue.
        // Cet objet servira à afficher le menu, lire les saisies et afficher les résultats.
        private vwProduit _view;

        // Champ privé pour l'instance de la couche Business qui gère la logique métier.
        // On y trouve les méthodes permettant de valider et d'effectuer les opérations sur les produits.
        private bsProduit _business;

        // Constructeur de ctrlProduit.
        // Lorsqu'une instance de ctrlProduit est créée, on initialise la vue et la couche Business.
        public ctrlProduit()
        {
            // Crée une instance de la vue vwProduit pour interagir avec l'utilisateur via la console.
            _view = new vwProduit();
            // Crée une instance de la couche Business bsProduit qui contient la logique métier.
            _business = new bsProduit();
        }

        // Méthode principale qui démarre le contrôleur et gère le menu de l'application.
        // Elle s'exécute en boucle jusqu'à ce que l'utilisateur choisisse de quitter (choix "0").
        public void Demarrer()
        {
            // Déclare une variable "choix" qui contiendra le choix de l'utilisateur.
            // Le "?" indique que la variable peut être null.
            string? choix;

            // Boucle do...while permettant de répéter le menu jusqu'à ce que le choix soit "0".
            do
            {
                // Affiche le menu principal dans la console via la vue.
                _view.AfficherMenu();

                // Attend la saisie de l'utilisateur et la stocke dans la variable "choix".
                choix = _view.LireChoix();

                // Analyse la saisie de l'utilisateur pour déterminer l'action à effectuer.
                switch (choix)
                {
                    case "1":
                        // Appelle la méthode pour ajouter un produit.
                        AjouterProduit();
                        break;
                    case "2":
                        // Appelle la méthode pour supprimer un produit.
                        SupprimerProduit();
                        break;
                    case "3":
                        // Appelle la méthode pour modifier un produit existant.
                        ModifierProduit();
                        break;
                    case "4":
                        // Appelle la méthode pour lister tous les produits.
                        ListerProduits();
                        break;
                    case "5":
                        // Appelle la méthode pour afficher un produit spécifique en fonction de son code.
                        VoirProduitParCode();
                        break;
                    case "0":
                        // Si l'utilisateur choisit "0", affiche un message d'au revoir.
                        _view.AfficherMessage("Au revoir !");
                        break;
                    default:
                        // Pour toute autre saisie, affiche un message indiquant un choix invalide.
                        _view.AfficherMessage("Choix invalide. Veuillez réessayer.");
                        break;
                }
            }
            // La boucle continue tant que le choix de l'utilisateur n'est pas "0".
            while (choix != "0");
        }

        // Méthode pour ajouter un produit.
        // Elle récupère les données saisies via la vue, appelle la méthode business pour ajouter le produit, et affiche le résultat retourné à l'utilisateur.
        public void AjouterProduit()
        {
            // Demande à l'utilisateur de saisir les informations du produit et crée un objet Produit avec ces informations.
            Produit produit = _view.SaisirProduit();

            // Appelle la méthode AjouterProduit de la couche Business pour traiter l'ajout.
            // La méthode retourne un message de résultat (succès ou échec).
            string resultat = _business.AjouterProduit(produit);

            // Affiche le message résultat à l'utilisateur via la vue.
            _view.AfficherMessage(resultat);
        }

        // Méthode pour supprimer un produit.
        // Elle demande le code du produit à supprimer, appelle la méthode correspondante dans la couche Business, et affiche le message de résultat.
        public void SupprimerProduit()
        {
            // Demande à l'utilisateur de saisir le code du produit à supprimer.
            string code = _view.SaisirCodeProduit("Entrez le code du produit à supprimer : ");

            // Appelle la méthode SupprimerProduit dans la couche Business en transmettant le code du produit.
            string resultat = _business.SupprimerProduit(code);

            // Affiche le message de résultat à l'utilisateur.
            _view.AfficherMessage(resultat);
        }

        // Méthode pour modifier un produit existant.
        // Elle demande le code du produit à modifier, puis les nouvelles informations via la vue, et appelle le service Business pour réaliser la modification.
        public void ModifierProduit()
        {
            // Demande à l'utilisateur de saisir le code du produit à modifier.
            string code = _view.SaisirCodeProduit("Entrez le code du produit à modifier : ");

            // Affiche une instruction invitant l'utilisateur à saisir les nouvelles informations du produit.
            _view.AfficherMessage("Saisissez les nouvelles informations du produit :");

            // Récupère les informations mises à jour du produit via la vue et crée un objet Produit.
            Produit nouveauProduit = _view.SaisirProduit();

            // Appelle la méthode ModifierProduit de la couche Business en passant le nouveau produit et le code original.
            string resultat = _business.ModifierProduit(nouveauProduit, code);

            // Affiche le résultat de l'opération (succès ou échec) à l'utilisateur.
            _view.AfficherMessage(resultat);
        }

        // Méthode pour lister tous les produits.
        // Elle récupère la liste des produits via la couche Business et la fait afficher par la vue.
        public void ListerProduits()
        {
            // Récupère la liste complète des produits via la méthode ListerProduits de la couche Business.
            List<Produit> produits = _business.ListerProduits();

            // Affiche cette liste dans la console via la méthode AfficherListeProduits de la vue.
            _view.AfficherListeProduits(produits);

            // Affiche un message vide pour faire une pause, permettant à l'utilisateur de lire la liste.
            _view.AfficherMessage("");
        }

        // Méthode pour afficher un produit spécifique en fonction de son code.
        public void VoirProduitParCode()
        {
            // Demande à l'utilisateur de saisir le code du produit qu'il souhaite consulter.
            string code = _view.SaisirCodeProduit("Entrez le code du produit à consulter : ");

            // Récupère le produit correspondant via la méthode ObtenirProduitParCode de la couche Business.
            // Le résultat peut être null si aucun produit n'est trouvé.
            Produit? produit = _business.ObtenirProduitParCode(code);

            // Si aucun produit n'est trouvé, affiche un message d'erreur.
            if (produit == null)
            {
                _view.AfficherMessage("Produit non trouvé.");
            }
            else
            {
                // Sinon, affiche les détails du produit via la vue.
                _view.AfficherProduit(produit);
                // Affiche un message vide pour faire une pause après l'affichage.
                _view.AfficherMessage("");
            }
        }
    }
}
