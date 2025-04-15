using PAPYRUS.Models;
using PAPYRUS.Repository;

repProduit repo = new repProduit();
bool continuer = true;

while (continuer)
{
    Console.Clear(); // Nettoyage de l'écran à chaque itération

    Console.WriteLine("Bienvenue dans le gestionnaire de produits\n");
    Console.WriteLine("=== Menu ===");
    Console.WriteLine("1. Ajouter un produit");
    Console.WriteLine("2. Supprimer un produit");
    Console.WriteLine("3. Modifier un produit");
    Console.WriteLine("4. Lister tous les produits");
    Console.WriteLine("5. Voir un produit par son code");
    Console.WriteLine("0. Quitter");










    Console.Write("Votre choix : ");
    string? choix = Console.ReadLine();

    if (choix == "1")
    {
        Console.Write("Code article : ");
        string codart = Console.ReadLine() ?? "";

        Console.Write("Libellé : ");
        string libart = Console.ReadLine() ?? "";

        Console.Write("Stock alloué : ");
        short stkale = Convert.ToInt16(Console.ReadLine() ?? "0");

        Console.Write("Stock physique : ");
        short stkphy = Convert.ToInt16(Console.ReadLine() ?? "0");

        Console.Write("Quantité annuelle : ");
        short qteann = Convert.ToInt16(Console.ReadLine() ?? "0");

        Console.Write("Unité de mesure : ");
        string unimes = Console.ReadLine() ?? "";

        Produit nouveauProduit = new Produit(codart, libart, stkale, stkphy, qteann, unimes);
        repo.AddProduit(nouveauProduit);

        Console.WriteLine("Produit ajouté.");
        Console.WriteLine("\nAppuyez sur une touche pour revenir au menu...");
        Console.ReadKey();
    }
    else if (choix == "2")
    {
        Console.Write("Code article à supprimer : ");
        string codeASupprimer = Console.ReadLine() ?? "";
        repo.DeleteProduit(codeASupprimer);

        Console.WriteLine("Produit supprimé.");
        Console.WriteLine("\nAppuyez sur une touche pour revenir au menu...");
        Console.ReadKey();
    }
    else if (choix == "3")
    {
        Console.Write("Code article à modifier : ");
        string codeAModifier = Console.ReadLine() ?? "";

        Console.Write("Nouveau libellé : ");
        string nouveauLibelle = Console.ReadLine() ?? "";

        Console.Write("Nouveau stock alloué : ");
        short nouveauStkale = Convert.ToInt16(Console.ReadLine() ?? "0");

        Console.Write("Nouveau stock physique : ");
        short nouveauStkphy = Convert.ToInt16(Console.ReadLine() ?? "0");

        Console.Write("Nouvelle quantité annuelle : ");
        short nouvelleQteAnn = Convert.ToInt16(Console.ReadLine() ?? "0");

        Console.Write("Nouvelle unité de mesure : ");
        string nouvelleUnite = Console.ReadLine() ?? "";

        Produit produitModifie = new Produit(codeAModifier, nouveauLibelle, nouveauStkale, nouveauStkphy, nouvelleQteAnn, nouvelleUnite);
        repo.UpdateProduit(produitModifie);

        Console.WriteLine("Produit modifié.");
        Console.WriteLine("\nAppuyez sur une touche pour revenir au menu...");
        Console.ReadKey();
    }
    else if (choix == "4")
    {
        List<Produit> listeProduits = repo.GetProduits();

        if (listeProduits.Count == 0)
        {
            Console.WriteLine("Aucun produit trouvé.");
        }
        else
        {
            Console.WriteLine("\nListe des produits :");
            foreach (Produit produit in listeProduits)
            {
                Console.WriteLine($"Code : {produit.Codart} | Libellé : {produit.Libart}");
            }
        }
        Console.WriteLine("\nAppuyez sur une touche pour revenir au menu...");
        Console.ReadKey();
    }
    else if (choix == "5")
    {
        Console.Write("Code article à rechercher : ");
        string codeRecherche = Console.ReadLine() ?? "";

        Produit? produitRecherche = repo.GetProduitParCode(codeRecherche);

        if (produitRecherche != null)
        {
            Console.WriteLine("\nProduit trouvé :");
            Console.WriteLine($"Code : {produitRecherche.Codart}");
            Console.WriteLine($"Libellé : {produitRecherche.Libart}");
            Console.WriteLine($"Stock alloué : {produitRecherche.Stkale}");
            Console.WriteLine($"Stock physique : {produitRecherche.Stkphy}");
            Console.WriteLine($"Quantité annuelle : {produitRecherche.Qteann}");
            Console.WriteLine($"Unité : {produitRecherche.Unimes}");
        }
        else
        {
            Console.WriteLine("Produit introuvable.");
        }
        Console.WriteLine("\nAppuyez sur une touche pour revenir au menu...");
        Console.ReadKey();
    }
    else if (choix == "0")
    {
        continuer = false;
        Console.WriteLine("Merci et au revoir.");
    }
    else
    {
        Console.WriteLine("Choix invalide.");
        Console.ReadKey();
    }
}
