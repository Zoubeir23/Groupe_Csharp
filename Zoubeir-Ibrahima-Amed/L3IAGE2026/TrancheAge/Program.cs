// See https://aka.ms/new-console-template for more information

bool continuer;

do
{
    //Declaration des variables
    int age = 0;
    bool saisieValide = false;

    //Saisie de l'age avec gestion des erreurs
    while (!saisieValide)
    {
        try
        {
            Console.Write("Veuillez saisir votre age : ");
            age = int.Parse(Console.ReadLine() ?? "");

            if (age < 0 || age > 150)
            {
                Console.WriteLine("Veuillez entrer un age valide (entre 0 et 150).");
                continue;
            }

            saisieValide = true;
        }
        catch (FormatException)
        {
            Console.WriteLine("Erreur : veuillez entrer un nombre valide.");
        }
    }

    //Definition de la tranche d'age
    if (age < 13)
    {
        Console.WriteLine("Vous etes un enfant.");
    }
    else if (age < 18)
    {
        Console.WriteLine("Vous etes adolescent.");
    }
    else if (age < 60)
    {
        Console.WriteLine("Vous etes un adulte.");
    }
    else
    {
        Console.WriteLine("Vous etes un senior.");
    }

    Console.Write("\nVoulez-vous recommencer ? (o/n) : ");
    continuer = (Console.ReadLine() ?? "").ToLower() == "o";
    Console.WriteLine();

} while (continuer);
