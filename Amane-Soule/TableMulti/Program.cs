// See https://aka.ms/new-console-template for more information
Console.WriteLine("Ce programme nous permet d'afficher la table de multiplication d'un nombre");

//Declaration des variables
int nbre;
int i = 1;
bool rep = false;
//Boucle DO WHILE pour repeter le programme
do
{
    //Recuperation du nombres
    Console.WriteLine("Veuillez saisir un nombre :");
    nbre = int.Parse(Console.ReadLine());


    //Afficher la table de multiplication avec la boucle FOR
    for (i = 1; i <= 10; i++)
    {
        Console.WriteLine("{0} x {1} = {2}", nbre, i, nbre * i);
    }

    Console.WriteLine("Voulez-vous recommencer ? (o/n) : ");
    rep = Console.ReadLine().ToLower() == "o";

} while(rep);