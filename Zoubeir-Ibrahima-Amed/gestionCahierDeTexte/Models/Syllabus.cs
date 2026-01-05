using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppGestionCahierTexte.Models
{
    /// <summary>
    /// Classe représentant un syllabus (programme d'enseignement) dans le système
    /// </summary>
    public class Syllabus
    {
        /// <summary>
        /// Identifiant unique du syllabus (clé primaire)
        /// </summary>
        [Key]
        public int IdSyllabus { get; set; }

        /// <summary>
        /// Libellé (nom) du syllabus (obligatoire, maximum 150 caractères)
        /// </summary>
        [Required, MaxLength(150)]
        public string LibelleSyllabus { get; set; }

        /// <summary>
        /// Description du syllabus (obligatoire, maximum 250 caractères)
        /// </summary>
        [Required, MaxLength(250)]
        public string DescriptionSyllabus { get; set; }

        /// <summary>
        /// Volume horaire du syllabus en heures (optionnel)
        /// </summary>
		public int? VolumeHoraireSyllabus { get; set; }

        /// <summary>
        /// Niveau du syllabus (optionnel)
        /// Exemple: "L1", "L2", "L3", "Master", etc.
        /// </summary>
		public string NiveauSyllabus { get; set; }
    }
}
