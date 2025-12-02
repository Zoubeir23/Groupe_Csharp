// See https://aka.ms/new-console-template for more information
Console.WriteLine("Resolution d'une eqution du second degré");

//Declaration des variables
 float A, B, C, X1, X2, Delta;

//Recuperation des coefficients
Console.WriteLine("Donner le coefficient A : ");
A = float.Parse(Console.ReadLine());
    
Console.WriteLine("Donner le coefficient B : ");
B = float.Parse(Console.ReadLine());
    
Console.WriteLine("Donner le coefficient C : ");
C = float.Parse(Console.ReadLine());
//Affichage de la fonction

Console.WriteLine("L'equation est : f(x) = " + A + "x^2 + " + B +"x + " + C + " = 0");

//calcul du delta
Delta = B * B - 4 * A * C;
Console.WriteLine("Le delta est : " + Delta);
//Racine de Delta
if (Delta < 0)
{
    Console.WriteLine("L'equation n'admet pas de solution reelle");
}
else if (Delta == 0)
{
    X1 = -B / (2 * A);
    Console.WriteLine("L'equation admet une solution double : X1 = X2 = " + X1);
}
else
{
    X1 = (-B - MathF.Sqrt(Delta)) / (2 * A);
    X2 = (-B + MathF.Sqrt(Delta)) / (2 * A);
    Console.WriteLine("L'equation admet deux solutions reelles : X1 = " + X1 + " et X2 = " + X2);
}



Console.ReadLine();