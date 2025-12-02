// See https://aka.ms/new-console-template for more information

Console.WriteLine("Ce prgramme permet de calculer la moyenne arithmetique et gemotrique de deux valeurs puis la difference entre les deux");

//declaration des variables
float a, b, moyA, moyG, diff;

//Recupération des valeurs
Console.WriteLine("Entrer la valeur de a : ");
a = float.Parse(Console.ReadLine());

Console.WriteLine("Entrer la valeur de b : ");
b = float.Parse(Console.ReadLine());

//Calcul des moyennes
moyA = (a + b) / 2;
//Moyenne Geometrique
moyG = (float)Math.Sqrt(a * b);

//Affichage des resultats
Console.WriteLine("La moyenne arithmetique de " + a + " et " + b + " est egale a : " + moyA);


Console.WriteLine("La moyenne geometrique de " + a + " et " + b + " est egale a : " + moyG);

//Difference entre les deux moyennes  
Console.WriteLine("Difference des deux moyenne");

diff = moyA - moyG;
Console.WriteLine("{0} - {1} = {2}", moyA, moyG, diff.ToString());








Console.ReadLine();
