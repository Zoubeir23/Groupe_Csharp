using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace web
{
    /// <summary>
    /// Programme pour s'initier en C Sharp
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Methode de depart
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            //Declaration des varibles
            string nom, prenom, email;

            //Recuperation du prenom
            Console.WriteLine("Donner votre nom : ");
            nom = Console.ReadLine();

            //Recuperation du prenom
            Console.WriteLine("Donner votre prenom : ");
            prenom = Console.ReadLine();

            //Recuperation de l'email
            Console.WriteLine("Donner votre email : ");
            email = Console.ReadLine();

            //Affichage du message de bienvenue
            Console.WriteLine("Bienvenue {0} {1}, votre email est {2} ", prenom, nom, email);

            Console.WriteLine("Ce programme nous souahaite la bienvenue");
        }
    }
}
