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
    /// Classe représentant une matière (sujet d'enseignement) dans le système
    /// </summary>
    public class Matiere
    {
        /// <summary>
        /// Identifiant unique de la matière (clé primaire)
        /// </summary>
        [Key]
        public int IdMatiere { get; set; }

        /// <summary>
        /// Libellé (nom) de la matière (obligatoire, maximum 200 caractères)
        /// Exemple: "Mathématiques", "Français", "Informatique", etc.
        /// </summary>
        [Required, MaxLength(200)]
        public string LibelleMatiere { get; set; }

        /// <summary>
        /// Volume horaire de la matière en heures (obligatoire)
        /// </summary>
        [Required]
        public int? VolumeHoraireMatiere { get; set; }

        /// <summary>
        /// Niveau de la matière (obligatoire, maximum 80 caractères)
        /// Exemple: "L1", "L2", "L3", "Master", etc.
        /// </summary>
        [Required, MaxLength(80)]
        public string Niveau { get; set; }

        /// <summary>
        /// Identifiant du détail de syllabus associé (clé étrangère, optionnel)
        /// </summary>
        public int? DetailsMatiereId { get; set; }

        /// <summary>
        /// Navigation vers le détail de syllabus associé à cette matière
        /// </summary>
        [ForeignKey("DetailsMatiereId")]
        public virtual DetailsSyllabus DetailsSyllabus { get; set; }
    }
}
