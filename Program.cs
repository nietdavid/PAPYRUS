// On importe le namespace "PAPYRUS.Controllers" qui contient la classe ctrlProduit
using PAPYRUS.Controllers;

// La classe Program est la classe principale de notre application console.
// C'est ici que le programme commence son exécution.
class Program
{
    // La méthode Main est la méthode principale.
    // Cette méthode est automatiquement appelée lors du lancement du programme.
    static void Main(string[] args)
    {
        // On crée une instance de la classe ctrlProduit.
        // ctrlProduit est le contrôleur qui gère la logique métier des produits.
        // Il fait la communication entre la vue et la couche business/repository.
        ctrlProduit controller = new ctrlProduit();

        // On appelle la méthode Demarrer() de notre contrôleur.
        // Cette méthode gère le menu principal de l'application et le flux de l'interaction avec l'utilisateur.
        // Elle va par exemple afficher le menu, lire le choix de l'utilisateur et appeler les fonctions appropriées.
        controller.Demarrer();
    }
}
