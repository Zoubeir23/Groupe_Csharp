using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace trancheAge
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Declaration des variables
            int age = 0;
            bool rep = false;

            do
            {
                // Recuperation de l'age
                Console.WriteLine("Donner votre age : ");
                age = int.Parse(Console.ReadLine());


                // Determination de la tranche d'age
                if (age < 15)
                {
                    Console.WriteLine("Vous etes mineur.");
                }
                else if (age < 35)
                {
                    Console.WriteLine("Vous etes adolescent ");
                }

                else
                {
                    Console.WriteLine("Vous etes adulte.");
                }
                Console.WriteLine("Voulez-vous recommencer ? (o/n) : ");
                rep = Console.ReadLine().ToLower() == "o";
            } while (rep);
            


        }
    }
}
