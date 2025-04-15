// On importe les namespaces nécessaires :
// - System : pour les types de base (par exemple, bool, string, etc.).
// - System.Collections.Generic : pour utiliser des collections génériques (comme List<T>).
// - System.Text.RegularExpressions : pour utiliser les expressions régulières pour la validation.
// - PAPYRUS.Models : pour accéder à la classe Produit.
// - PAPYRUS.Repository : pour accéder à la classe repProduit qui gère les accès aux données.
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using PAPYRUS.Models;
using PAPYRUS.Repository;

namespace PAPYRUS.Business
{
    // La classe bsProduit centralise la logique métier liée aux produits.
    // Elle se charge de valider les produits et d'orchestrer les opérations (ajout, suppression, modification, etc.)
    // via le repository qui gère l'accès aux données.
    public class bsProduit
    {
        // Déclaration d'un champ privé "repositoryProduit" de type repProduit.
        // Ce champ stocke l'instance du repository qui sera utilisée pour effectuer les opérations CRUD (Create, Read, Update, Delete).
        private repProduit repositoryProduit;

        // Constructeur de la classe bsProduit.
        // Lorsqu'une instance de bsProduit est créée, on instancie aussi le repository pour pouvoir l'utiliser plus tard.
        public bsProduit()
        {
            // Crée une nouvelle instance de repProduit et l'affecte à repositoryProduit.
            repositoryProduit = new repProduit();
        }

        // Méthode de validation de la logique métier sur un objet Produit.
        // Cette méthode vérifie que les propriétés du produit respectent certaines règles (par exemple : le code doit être non vide et suivre un format précis).
        public bool ValiderProduit(Produit produit)
        {
            // Vérifie d'abord que la propriété Codart (le code du produit) n'est pas vide ou composée uniquement d'espaces.
            // Ensuite, vérifie que le code correspond bien à un format spécifique (lettres majuscules et chiffres).
            // Regex.IsMatch retourne true si le format est bon, donc on vérifie que le résultat n'est pas false.
            if (string.IsNullOrWhiteSpace(produit.Codart) || Regex.IsMatch(produit.Codart, @"^[A-Z0-9]+$") == false)
                return false; // Si le code est invalide, la méthode retourne false.

            // Vérifie que le libellé du produit (Libart) n'est pas vide.
            if (string.IsNullOrWhiteSpace(produit.Libart))
                return false; // Retourne false si le libellé est manquant.

            // Vérifie que les valeurs numériques du produit (Stock alloué, Stock physique, Quantité annuelle) ne sont pas négatives.
            // Si l'une de ces valeurs est inférieure à zéro, retourne false.
            if (produit.Stkale < 0 || produit.Stkphy < 0 || produit.Qteann < 0)
                return false;

            // Si toutes les vérifications sont correctes, retourne true pour indiquer que le produit est valide.
            return true;
        }

        // Méthode pour ajouter un produit après validation.
        // Elle prend en paramètre un objet Produit, vérifie sa validité et, le cas échéant, utilise le repository pour l'ajouter dans la base.
        public string AjouterProduit(Produit produit)
        {
            // Appelle la méthode ValiderProduit pour vérifier si le produit respecte les règles attendues.
            if (ValiderProduit(produit))
            {
                // Si la validation renvoie true, le produit est ajouté à la base de données via la méthode AddProduit du repository.
                repositoryProduit.AddProduit(produit);
                // Retourne un message de succès.
                return "Produit ajouté avec succès.";
            }
            else
            {
                // Si la validation échoue, retourne un message d'erreur.
                return "Produit invalide. Vérifiez vos saisies.";
            }
        }

        // Méthode pour supprimer un produit dont le code est fourni.
        // Elle prend en paramètre une chaîne qui représente le code du produit à supprimer.
        public string SupprimerProduit(string codeProduit)
        {
            // Recherche dans la base le produit correspondant au code fourni en utilisant le repository.
            Produit? produitTrouve = repositoryProduit.GetProduitParCode(codeProduit);
            // Si aucun produit n'est trouvé (produitTrouve est null), retourne un message d'erreur.
            if (produitTrouve == null)
            {
                return "Produit non trouvé.";
            }
            // Si le produit existe, appelle la méthode DeleteProduit du repository pour le supprimer.
            repositoryProduit.DeleteProduit(codeProduit);
            // Retourne un message indiquant que la suppression a été effectuée avec succès.
            return "Produit supprimé avec succès.";
        }

        // Méthode pour modifier un produit existant.
        // Elle prend en paramètres un nouvel objet Produit contenant les nouvelles données
        // et une chaîne codeProduit qui est le code d'origine servant à identifier le produit à modifier.
        public string ModifierProduit(Produit nouveauProduit, string codeProduit)
        {
            // Recherche le produit existant dans la base en utilisant le code fourni.
            Produit? produitExistant = repositoryProduit.GetProduitParCode(codeProduit);
            if (produitExistant == null)
            {
                // Si aucun produit n'est trouvé, retourne un message d'erreur.
                return "Produit non trouvé.";
            }

            // Conserve le code d'origine du produit pour assurer l'identification.
            nouveauProduit.Codart = codeProduit;

            // Valide le nouvel objet produit avec les nouvelles données.
            if (ValiderProduit(nouveauProduit))
            {
                // Si le produit est valide, appelle la méthode UpdateProduit du repository pour mettre à jour le produit dans la base.
                repositoryProduit.UpdateProduit(nouveauProduit);
                // Retourne un message de succès.
                return "Produit modifié avec succès.";
            }
            else
            {
                // Si la validation échoue, retourne un message indiquant que la modification est annulée.
                return "Données invalides. Modification annulée.";
            }
        }

        // Méthode qui retourne la liste complète des produits présents dans la base de données.
        // Elle utilise le repository pour récupérer la liste.
        public List<Produit> ListerProduits()
        {
            return repositoryProduit.GetProduits();
        }

        // Méthode qui retourne un produit spécifique en fonction de son code.
        // Elle utilise le repository pour rechercher le produit.
        public Produit? ObtenirProduitParCode(string codeProduit)
        {
            return repositoryProduit.GetProduitParCode(codeProduit);
        }
    }
}
