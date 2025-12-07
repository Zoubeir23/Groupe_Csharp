// Importation des espaces de noms nécessaires
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// Déclaration de l'espace de noms pour le projet
namespace CalculatricesInterface
{
    // Déclaration de la classe partielle Form1 qui hérite de Form
    public partial class Form1 : Form
    {
        // ====================================================================================================
        // Variables membres pour gérer l'état de la calculatrice
        // ====================================================================================================

        private double currentValue = 0;      // La valeur actuellement affichée ou en cours de saisie
        private double storedValue = 0;       // La valeur stockée après une opération
        private string currentOperation = ""; // L'opération en cours (+, -, ×, ÷, etc.)
        private bool operationPerformed = false; // Indique si une opération vient d'être effectuée
        private bool newCalculation = true;   // Indique si un nouveau calcul commence

        // ====================================================================================================
        // Constructeur du formulaire
        // ====================================================================================================

        public Form1()
        {
            // Initialise les composants de l'interface utilisateur (défini dans Form1.Designer.cs)
            InitializeComponent();
            // Définit le titre de la fenêtre
            this.Text = "Calculatrice Scientifique Moderne";
            // Initialise l'affichage à "0"
            txtDisplay.Text = "0";
        }

        // ====================================================================================================
        // Gestionnaires d'événements pour les boutons
        // ====================================================================================================

        /// <summary>
        /// Gère le clic sur les boutons numériques (0-9).
        /// </summary>
        private void BtnNumber_Click(object sender, EventArgs e)
        {
            // Récupère le bouton qui a déclenché l'événement
            Button btn = (Button)sender;
            
            // Si l'affichage est "0" ou si une opération vient d'être faite, on remplace le texte
            if (txtDisplay.Text == "0" || operationPerformed || newCalculation)
            {
                txtDisplay.Text = btn.Text;
                operationPerformed = false;
                newCalculation = false;
            }
            else // Sinon, on ajoute le chiffre à la suite
            {
                txtDisplay.Text += btn.Text;
            }
        }

        /// <summary>
        /// Gère le clic sur le bouton décimal (,).
        /// </summary>
        private void BtnDecimal_Click(object sender, EventArgs e)
        {
            // Si un nouveau calcul commence, on initialise l'affichage à "0,"
            if (operationPerformed || newCalculation)
            {
                txtDisplay.Text = "0,";
                operationPerformed = false;
                newCalculation = false;
            }
            // Sinon, si le texte ne contient pas déjà de virgule, on l'ajoute
            // Note : On vérifie la présence de "," et "." pour une meilleure robustesse
            else if (!txtDisplay.Text.Contains(",") && !txtDisplay.Text.Contains("."))
            {
                txtDisplay.Text += ",";
            }
        }

        /// <summary>
        /// Gère le clic sur les boutons d'opérateurs (+, -, ×, ÷, x^y).
        /// </summary>
        private void BtnOperator_Click(object sender, EventArgs e)
        {
            // Récupère le bouton qui a déclenché l'événement
            Button btn = (Button)sender;
            
            // Si une opération est déjà en cours, on calcule le résultat partiel d'abord
            if (currentOperation != "" && !operationPerformed)
            {
                BtnEquals_Click(sender, e);
            }

            // Stocke la valeur actuelle et l'opération
            storedValue = ParseDisplay();
            currentOperation = btn.Text;
            // Affiche l'opération en cours au-dessus de la zone d'affichage principale
            lblOperation.Text = $"{storedValue} {currentOperation}";
            operationPerformed = true;
            newCalculation = false;
        }

        /// <summary>
        /// Gère le clic sur le bouton égal (=).
        /// </summary>
        private void BtnEquals_Click(object sender, EventArgs e)
        {
            // Si aucune opération n'est en cours, on ne fait rien
            if (currentOperation == "")
                return;

            // Récupère la deuxième opérande
            currentValue = ParseDisplay();
            double result = 0;

            try
            {
                // Effectue le calcul en fonction de l'opération
                switch (currentOperation)
                {
                    case "+":
                        result = storedValue + currentValue;
                        break;
                    case "−":
                        result = storedValue - currentValue;
                        break;
                    case "×":
                        result = storedValue * currentValue;
                        break;
                    case "÷":
                        // Gère la division par zéro
                        if (currentValue != 0)
                            result = storedValue / currentValue;
                        else
                        {
                            MessageBox.Show("Division par zéro impossible!", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            Clear();
                            return;
                        }
                        break;
                    case "x^y":
                        result = Math.Pow(storedValue, currentValue);
                        break;
                }

                // Affiche le calcul complet et le résultat
                lblOperation.Text = $"{storedValue} {currentOperation} {currentValue} =";
                txtDisplay.Text = FormatResult(result);
                // Réinitialise l'état pour un nouveau calcul
                currentOperation = "";
                operationPerformed = true;
                newCalculation = true;
            }
            catch (Exception ex)
            {
                // Gère les erreurs de calcul inattendues
                MessageBox.Show($"Erreur: {ex.Message}", "Erreur de calcul", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Clear();
            }
        }

        /// <summary>
        /// Gère le clic sur les boutons de fonctions scientifiques (sin, cos, log, etc.).
        /// </summary>
        private void BtnScientific_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            double value = ParseDisplay();
            double result = 0;

            try
            {
                // Applique la fonction scientifique correspondante
                switch (btn.Text)
                {
                    case "sin":
                        result = Math.Sin(value * Math.PI / 180); // Conversion en radians
                        lblOperation.Text = $"sin({value})";
                        break;
                    case "cos":
                        result = Math.Cos(value * Math.PI / 180); // Conversion en radians
                        lblOperation.Text = $"cos({value})";
                        break;
                    case "tan":
                        result = Math.Tan(value * Math.PI / 180); // Conversion en radians
                        lblOperation.Text = $"tan({value})";
                        break;
                    case "log":
                        if (value > 0)
                        {
                            result = Math.Log10(value);
                            lblOperation.Text = $"log({value})";
                        }
                        else
                        {
                            MessageBox.Show("Le logarithme n'est défini que pour les nombres positifs!", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        break;
                    case "ln":
                        if (value > 0)
                        {
                            result = Math.Log(value);
                            lblOperation.Text = $"ln({value})";
                        }
                        else
                        {
                            MessageBox.Show("Le logarithme naturel n'est défini que pour les nombres positifs!", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        break;
                    case "√":
                        if (value >= 0)
                        {
                            result = Math.Sqrt(value);
                            lblOperation.Text = $"√({value})";
                        }
                        else
                        {
                            MessageBox.Show("La racine carrée n'est pas définie pour les nombres négatifs!", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        break;
                    case "x²":
                        result = Math.Pow(value, 2);
                        lblOperation.Text = $"({value})²";
                        break;
                    case "n!":
                        // La factorielle est définie pour les entiers positifs
                        if (value >= 0 && value <= 170 && value == Math.Floor(value))
                        {
                            result = Factorial((int)value);
                            lblOperation.Text = $"{value}!";
                        }
                        else
                        {
                            MessageBox.Show("La factorielle n'est définie que pour les entiers positifs ≤ 170!", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        break;
                }

                // Affiche le résultat et met à jour l'état
                txtDisplay.Text = FormatResult(result);
                operationPerformed = true;
                newCalculation = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur: {ex.Message}", "Erreur de calcul", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Clear();
            }
        }

        /// <summary>
        /// Gère le clic sur les boutons de constantes (π, e).
        /// </summary>
        private void BtnConstant_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            
            if (btn.Text == "π")
            {
                txtDisplay.Text = FormatResult(Math.PI);
                lblOperation.Text = "π";
            }
            else if (btn.Text == "e")
            {
                txtDisplay.Text = FormatResult(Math.E);
                lblOperation.Text = "e";
            }
            
            operationPerformed = true;
            newCalculation = true;
        }

        /// <summary>
        /// Gère le clic sur le bouton Clear (C).
        /// </summary>
        private void BtnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        /// <summary>
        /// Gère le clic sur le bouton Backspace (⌫).
        /// </summary>
        private void BtnBackspace_Click(object sender, EventArgs e)
        {
            // Si le texte a plus d'un caractère, on en supprime un
            if (txtDisplay.Text.Length > 1 && !operationPerformed)
            {
                txtDisplay.Text = txtDisplay.Text.Substring(0, txtDisplay.Text.Length - 1);
            }
            else // Sinon, on affiche "0"
            {
                txtDisplay.Text = "0";
            }
        }

        // ====================================================================================================
        // Méthodes utilitaires
        // ====================================================================================================

        /// <summary>
        /// Calcule la factorielle d'un nombre entier.
        /// </summary>
        private double Factorial(int n)
        {
            if (n == 0 || n == 1)
                return 1;
            
            double result = 1;
            for (int i = 2; i <= n; i++)
            {
                result *= i;
            }
            return result;
        }

        /// <summary>
        /// Réinitialise l'état de la calculatrice à ses valeurs par défaut.
        /// </summary>
        private void Clear()
        {
            txtDisplay.Text = "0";
            lblOperation.Text = "";
            currentValue = 0;
            storedValue = 0;
            currentOperation = "";
            operationPerformed = false;
            newCalculation = true;
        }

        /// <summary>
        /// Convertit le texte de l'affichage en une valeur de type double.
        /// </summary>
        private double ParseDisplay()
        {
            // Remplace la virgule par un point pour la conversion
            string text = txtDisplay.Text.Replace(",", ".");
            double result;
            // Utilise la culture invariante pour assurer une conversion correcte
            if (double.TryParse(text, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out result))
            {
                return result;
            }
            return 0;
        }

        /// <summary>
        /// Formate un nombre de type double pour l'affichage.
        /// </summary>
        private string FormatResult(double value)
        {
            // Gère les cas spéciaux comme l'infini et NaN (Not a Number)
            if (double.IsInfinity(value))
                return "∞";
            if (double.IsNaN(value))
                return "Erreur";

            // Formate le nombre avec une précision de 15 chiffres
            string result = value.ToString("G15", System.Globalization.CultureInfo.InvariantCulture);
            // Remplace le point par une virgule pour l'affichage
            result = result.Replace(".", ",");
            
            // Si le résultat est trop long, on passe en notation scientifique
            if (result.Length > 15)
            {
                result = value.ToString("E6", System.Globalization.CultureInfo.InvariantCulture).Replace(".", ",");
            }
            
            return result;
        }

        /// <summary>
        /// Maintenir cette méthode pour la compatibilité du concepteur de formulaires.
        /// </summary>
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // Cette méthode est requise par le concepteur et peut être laissée vide.
        }
    }
}
