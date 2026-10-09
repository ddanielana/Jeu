bool continuer = true;
string[] produits = new string[5];

Console.WriteLine("Bienvenue ! Que souhaitez-vous faire ?");

while (continuer)
{
    Console.WriteLine("1. Afficher les produits disponibles");
    Console.WriteLine("2. Ajouter des produits");
    Console.WriteLine("3. Retirer des produits");
    Console.WriteLine("4. Rechercher un produit");
    Console.WriteLine("0. Quitter le marché");

    string input = Console.ReadLine()!;

    switch (input)
    {
        case "1":
            AfficherProduitsDisponibles(produits);
            break;
        case "2":
            AjouterProduits(produits);
            break;
        case "3":
            RetirerProduits(produits);
            break;
        case "4":
            RechercherProduit(produits);
            break;
        case "0":
            continuer = false;
            Console.WriteLine("Merci d'avoir visité le marché !");
            break;
        default:
            Console.WriteLine("Option invalide, veuillez réessayer.");
            break;
    }
}

void AfficherProduitsDisponibles(string[] produits)
{
    int compteur = 0;
    foreach (var produit in produits)
    {
        if (!string.IsNullOrEmpty(produit))
        {
            if (compteur == 0)
            {
                Console.WriteLine("Produits disponibles :");
            }
            Console.WriteLine(produit);
            compteur++;
        }
    }
    if (compteur == 0)
    {
        Console.WriteLine("Panier vide. Ajoutez des produits.");
    }
}


void AjouterProduits(string[] produits)
{
    Console.WriteLine("Entrez le nom du produit que vous souhaitez ajouter :");
    string nomProduit = Console.ReadLine()!;

    if (string.IsNullOrWhiteSpace(nomProduit))
    {
        Console.WriteLine("Le nom du produit ne peut pas être vide.");
        return;
    }

    foreach (var produit in produits)
    {
        if (string.Equals(produit, nomProduit, StringComparison.OrdinalIgnoreCase))
        {
            Console.WriteLine($"Vous avez déjà ajouté : {nomProduit}");
            return;
        }
    }
    for (int i = 0; i < produits.Length; i++)
    {
        if (string.IsNullOrEmpty(produits[i]))
        {
            produits[i] = nomProduit;
            Console.WriteLine($"Vous avez ajouté : {nomProduit}");
            return;
        }
    }
    Console.WriteLine("Plus de place disponible dans le panier.");
}

void RetirerProduits(string[] produits)
{
    Console.WriteLine("Entrez le nom du produit que vous souhaitez retirer :");
    string nomProduit = Console.ReadLine()!;

    if (string.IsNullOrWhiteSpace(nomProduit))
    {
        Console.WriteLine("Le nom du produit ne peut pas être vide.");
        return;
    }

    for (int i = 0; i < produits.Length; i++)
    {
        if (string.Equals(produits[i], nomProduit, StringComparison.OrdinalIgnoreCase))
        {
            produits[i] = "";
            Console.WriteLine($"Vous avez retiré : {nomProduit}");
            return;
        }
    }
    Console.WriteLine("Produit non trouvé.");
}

void RechercherProduit(string[] produits)
{
    Console.WriteLine("Entrez le nom du produit que vous souhaitez rechercher :");
    string nomProduit = Console.ReadLine()!;

    if (string.IsNullOrWhiteSpace(nomProduit))
    {
        Console.WriteLine("Le nom du produit ne peut pas être vide.");
        return;
    }

    foreach (var produit in produits)
    {
        if (string.Equals(produit, nomProduit, StringComparison.OrdinalIgnoreCase))
        {
            Console.WriteLine($"Produit trouvé : {nomProduit}");
            return;
        }
    }
    Console.WriteLine("Produit non trouvé.");
}