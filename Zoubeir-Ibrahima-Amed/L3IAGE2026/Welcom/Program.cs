using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Welcom
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool rep = false;
            do
            {
                // Déclaration des variables pour stocker les informations saisies
                string nom, prenom, email;

                // Demande et saisie du nom
                Console.Write("Entrez votre nom: ");
                nom = Console.ReadLine() ?? ""; // L'opérateur ?? gère le cas où ReadLine retourne null

                // Demande et saisie du prénom
                Console.Write("Entrez votre prénom: ");
                prenom = Console.ReadLine() ?? "";

                // Demande et saisie de l'email
                Console.Write("Entrez votre email: ");
                email = Console.ReadLine() ?? "";

                // Affichage des informations saisies
                Console.WriteLine("Nom: " + nom);
                Console.WriteLine("Prénom: " + prenom);
                Console.WriteLine("Email: " + email);

                //Affichage du  ot mot bienvenu
                Console.WriteLine("Bonjour {0} {1}, votre email est {2}", prenom, nom, email);

                Console.WriteLine("Voulez-vous recommencer ? (o/n) : ");
                rep=(Console.ReadLine() ?? "").ToLower() == "o";

            } while (rep);
        }
    }
}
