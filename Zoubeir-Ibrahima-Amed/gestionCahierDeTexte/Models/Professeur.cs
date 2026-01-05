using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppGestionCahierTexte.Models
{
    /// <summary>
    /// Classe représentant un professeur dans le système
    /// Hérite de la classe Utilisateur et ajoute la spécialité du professeur
    /// </summary>
    public class Professeur : Utilisateur
    {
        /// <summary>
        /// Spécialité du professeur (obligatoire, maximum 80 caractères)
        /// Exemple: "Informatique", "Mathématiques", "Français", etc.
        /// </summary>
        [Required, MaxLength(80)]
        public string SpecialiteProfesseur { get; set; }
    }
}
