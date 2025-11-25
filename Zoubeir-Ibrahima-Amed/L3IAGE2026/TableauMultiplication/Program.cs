// See https://aka.ms/new-console-template for more information

//Un tableau de multiplication avec la boucle for

// saisie du nombre
int nombre;
bool rep = true;
do
{
    Console.Write("Veuillez saisir un nombre pour afficher sa table de multiplication : ");
    nombre = int.Parse(Console.ReadLine() ?? "");

    for (int i = 1; i <= 10; i++)
    {
        int resultat = nombre * i;
        Console.WriteLine($"{nombre} x {i} = {resultat}");
    }
    Console.WriteLine("Voulez-vous saisir un autre nombre ? (o/n) : ");
    Console.WriteLine("Voulez-vous recommencer ? (o/n) : ");
    rep = (Console.ReadLine() ?? "").ToLower() == "o";
} while (rep);

////Un tableau de multiplication avec la boucle while
//int j = 1;
//while (j <= 10)
//{
//    int resultat = nombre * j;
//    Console.WriteLine($"{nombre} x {j} = {resultat}");
//    j++;
//}

////Un tableau de multiplication avec la boucle do while
//int k = 1;
//do
//{
//    int resultat = nombre * k;
//    Console.WriteLine($"{nombre} x {k} = {resultat}");
//    k++;
//} while (k <= 10);