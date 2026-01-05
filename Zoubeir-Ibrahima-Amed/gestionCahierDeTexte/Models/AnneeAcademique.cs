using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppGestionCahierTexte.Models
{
    /// <summary>
    /// Classe représentant une année académique dans le système
    /// </summary>
    public class AnneeAcademique
    {
        /// <summary>
        /// Identifiant unique de l'année académique (clé primaire)
        /// </summary>
        [Key]
        public int IdAnneeAcademique { get; set; }

        /// <summary>
        /// Libellé de l'année académique (obligatoire, maximum 10 caractères)
        /// Exemple: "2024-2025", "2025-2026", etc.
        /// </summary>
        [Required, MaxLength(10)]
        public string LibelleAnneeAcademique { get; set; }

        /// <summary>
        /// Valeur numérique de l'année académique (obligatoire)
        /// Par défaut, prend l'année en cours
        /// Exemple: 2025, 2026, etc.
        /// </summary>
        [Required]
        public int ValueAnneeAcademique { get; set; } = DateTime.Now.Year;
    }
}
