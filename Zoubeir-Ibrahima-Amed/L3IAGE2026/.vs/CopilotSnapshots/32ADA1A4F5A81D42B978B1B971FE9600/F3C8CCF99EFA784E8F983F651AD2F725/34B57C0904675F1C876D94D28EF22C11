using System;

namespace Calculatrice
{
    /// <summary>
    /// Programme principal de la calculatrice interactive
    /// Permet d'effectuer des opérations mathématiques de base
    /// </summary>
    class Program
    {
        /// <summary>
        /// Point d'entrée principal du programme
        /// </summary>
        /// <param name="args">Arguments de ligne de commande (non utilisés)</param>
        static void Main(string[] args)
        {
            // Variable pour contrôler la boucle principale du programme
            // Si true, le programme continue, si false, il s'arrête
            bool continuer = true;

            // Affichage de l'en-tête du programme
            Console.WriteLine("=================================");
            Console.WriteLine("   CALCULATRICE EN C#");
            Console.WriteLine("=================================\n");

            // Boucle principale : continue tant que l'utilisateur veut faire des calculs
            while (continuer)
            {
                try
                {
                    // ===== ÉTAPE 1: DEMANDER LE PREMIER NOMBRE =====
                    Console.Write("Entrez le premier nombre: ");
                    // Convert.ToDouble() convertit la chaîne de caractères en nombre décimal
                    double nombre1 = Convert.ToDouble(Console.ReadLine());

                    // ===== ÉTAPE 2: AFFICHER LE MENU DES OPÉRATIONS =====
                    Console.WriteLine("\nChoisissez une opération:");
                    Console.WriteLine("1. Addition (+)");
                    Console.WriteLine("2. Soustraction (-)");
                    Console.WriteLine("3. Multiplication (*)");
                    Console.WriteLine("4. Division (/)");
                    Console.WriteLine("5. Puissance (^)");
                    Console.WriteLine("6. Modulo (%)");
                    Console.Write("\nVotre choix (1-6): ");
                    // L'opérateur ?? "" gère le cas où ReadLine retourne null
                    string choix = Console.ReadLine() ?? "";

                    // ===== ÉTAPE 3: DEMANDER LE DEUXIÈME NOMBRE =====
                    Console.Write("Entrez le deuxième nombre: ");
                    double nombre2 = Convert.ToDouble(Console.ReadLine());

                    // ===== ÉTAPE 4: INITIALISER LES VARIABLES POUR LE CALCUL =====
                    // Variable pour stocker le résultat du calcul
                    double resultat = 0;
                    // Variable pour stocker le symbole de l'opération (pour l'affichage)
                    string operateur = "";
                    // Variable pour savoir si l'opération s'est bien déroulée
                    bool operationValide = true;

                    // ===== ÉTAPE 5: EFFECTUER L'OPÉRATION CHOISIE =====
                    // Structure switch pour gérer les différentes opérations
                    switch (choix)
                    {
                        case "1":
                            // ADDITION: additionne les deux nombres
                            resultat = nombre1 + nombre2;
                            operateur = "+";
                            break;

                        case "2":
                            // SOUSTRACTION: soustrait le deuxième nombre du premier
                            resultat = nombre1 - nombre2;
                            operateur = "-";
                            break;

                        case "3":
                            // MULTIPLICATION: multiplie les deux nombres
                            resultat = nombre1 * nombre2;
                            operateur = "*";
                            break;

                        case "4":
                            // DIVISION: divise le premier nombre par le deuxième
                            // Vérification importante: on ne peut pas diviser par zéro!
                            if (nombre2 == 0)
                            {
                                // Change la couleur du texte en rouge pour les erreurs
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("\n❌ Erreur: Division par zéro impossible!");
                                // Remet la couleur par défaut
                                Console.ResetColor();
                                // Marque l'opération comme invalide
                                operationValide = false;
                            }
                            else
                            {
                                // Si le diviseur n'est pas zéro, on effectue la division
                                resultat = nombre1 / nombre2;
                                operateur = "/";
                            }
                            break;

                        case "5":
                            // PUISSANCE: élève le premier nombre à la puissance du deuxième
                            // Math.Pow() est une fonction qui calcule nombre1^nombre2
                            resultat = Math.Pow(nombre1, nombre2);
                            operateur = "^";
                            break;

                        case "6":
                            // MODULO: calcule le reste de la division entière
                            // Exemple: 10 % 3 = 1 (car 10 = 3*3 + 1)
                            // Vérification: on ne peut pas faire de modulo par zéro!
                            if (nombre2 == 0)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("\n❌ Erreur: Modulo par zéro impossible!");
                                Console.ResetColor();
                                operationValide = false;
                            }
                            else
                            {
                                resultat = nombre1 % nombre2;
                                operateur = "%";
                            }
                            break;

                        default:
                            // Si l'utilisateur entre un choix autre que 1-6
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\n❌ Choix invalide!");
                            Console.ResetColor();
                            operationValide = false;
                            break;
                    }

                    // ===== ÉTAPE 6: AFFICHER LE RÉSULTAT =====
                    // On affiche le résultat seulement si l'opération est valide
                    if (operationValide)
                    {
                        // Change la couleur en vert pour les résultats réussis
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\n=================================");
                        // $"{variable}" permet d'insérer des variables dans une chaîne
                        Console.WriteLine($"   {nombre1} {operateur} {nombre2} = {resultat}");
                        Console.WriteLine("=================================");
                        // Remet la couleur par défaut
                        Console.ResetColor();
                    }
                }
                // ===== GESTION DES ERREURS =====
                catch (FormatException)
                {
                    // Cette erreur se produit si l'utilisateur entre quelque chose qui n'est pas un nombre
                    // Par exemple: "abc" au lieu de "123"
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n❌ Erreur: Veuillez entrer un nombre valide!");
                    Console.ResetColor();
                }
                catch (Exception ex)
                {
                    // Cette section attrape toutes les autres erreurs imprévues
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"\n❌ Erreur inattendue: {ex.Message}");
                    Console.ResetColor();
                }

                // ===== ÉTAPE 7: DEMANDER SI L'UTILISATEUR VEUT CONTINUER =====
                Console.WriteLine("\n---------------------------------");
                Console.Write("Voulez-vous effectuer un autre calcul? (o/n): ");
                // Lit la réponse et la convertit en minuscules pour faciliter la comparaison
                string reponse = (Console.ReadLine() ?? "").ToLower();
                // Si la réponse est "o" ou "oui", on continue la boucle
                continuer = (reponse == "o" || reponse == "oui");

                // Si l'utilisateur veut continuer, on efface l'écran et on réaffiche l'en-tête
                if (continuer)
                {
                    Console.Clear(); // Efface tout le texte de la console
                    Console.WriteLine("=================================");
                    Console.WriteLine("   CALCULATRICE EN C#");
                    Console.WriteLine("=================================\n");
                }
            }

            // ===== FIN DU PROGRAMME =====
            // Message de fin affiché quand l'utilisateur choisit de quitter
            Console.WriteLine("\n👋 Merci d'avoir utilisé la calculatrice!");
            Console.WriteLine("Appuyez sur une touche pour quitter...");
            // Attend que l'utilisateur appuie sur une touche avant de fermer
            Console.ReadKey();
        }
    }
}
