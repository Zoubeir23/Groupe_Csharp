using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppGestionCahierTexte.Models
{
    /// <summary>
    /// Classe représentant une classe (groupe d'étudiants) dans le système
    /// </summary>
    public class Classe
    {
        /// <summary>
        /// Identifiant unique de la classe (clé primaire)
        /// </summary>
        [Key]
        public int IdClasse { get; set; }

        /// <summary>
        /// Libellé (nom) de la classe (obligatoire, maximum 100 caractères)
        /// Exemple: "L3 IAGE", "L2 Informatique", etc.
        /// </summary>
        [Required , MaxLength(100)]
        public string LibelleClasse { get; set; }

        /// <summary>
        /// Identifiant de l'année académique associée (clé étrangère, obligatoire)
        /// </summary>
        public int IdAnneeAcademique { get; set; }

        /// <summary>
        /// Navigation vers l'année académique associée à cette classe
        /// </summary>
        [ForeignKey("IdAnneeAcademique")]
        public virtual AnneeAcademique AnneeAcademique { get; set; }
    }
}
