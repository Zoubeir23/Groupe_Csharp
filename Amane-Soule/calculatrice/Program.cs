// See https://aka.ms/new-console-template for more information
Console.WriteLine("Calculatrice console");

//Declaration des variables
double a, b, resultat;
char operateur;
string choix;

do
{
    //Recuperation des nombres et de l'operateur
    Console.Write("Entrez le premier nombre : ");
    a = double.Parse(Console.ReadLine());

    Console.Write("Entrez le deuxième nombre : ");
    b = double.Parse(Console.ReadLine());

    Console.Write("Choisissez un opérateur (+, -, *, /) : ");
    operateur = char.Parse(Console.ReadLine());

    //Switch qui effectue l'operation (en fonction de l'operateur)
    switch (operateur)
    {
        case '+':
            resultat = a + b;
            Console.WriteLine($"Résultat : {a} + {b} = {resultat}");
            break;
        case '-':
            resultat = a - b;
            Console.WriteLine($"Résultat : {a} - {b} = {resultat}");
            break;
        case '*':
            resultat = a * b;
            Console.WriteLine($"Résultat : {a} * {b} = {resultat}");
            break;
        case '/':
            if (b != 0)
            {
                resultat = a / b;
                Console.WriteLine($"Résultat : {a} / {b} = {resultat}");
            }
            else
            {
                Console.WriteLine("Erreur : division par zéro !");
            }
            break;
        default:
            Console.WriteLine("Opérateur invalide !");
            break;
    }

    Console.Write("Voulez-vous recommencer ? (oui/non) : ");
    choix = Console.ReadLine().ToLower();

} while (choix == "oui");

Console.WriteLine("Merci d'avoir utilisé la calculatrice !");


Console.ReadLine();
