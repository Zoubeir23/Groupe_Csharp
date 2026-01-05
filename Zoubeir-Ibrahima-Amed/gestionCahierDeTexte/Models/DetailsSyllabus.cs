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
    /// Classe représentant les détails d'un syllabus (contenu détaillé du programme)
    /// Un syllabus peut avoir plusieurs détails (séquences)
    /// </summary>
    public class DetailsSyllabus
    {
        /// <summary>
        /// Identifiant unique du détail de syllabus (clé primaire)
        /// </summary>
		[Key]
        public int IdDetailsSyllabus { get; set; }

        /// <summary>
        /// Séquence du syllabus (obligatoire, maximum 10 caractères)
        /// Exemple: "Séquence 1", "Semestre 1", etc.
        /// </summary>
		[Required, MaxLength(10)]
		public string SequenceSyllabus { get; set; }

        /// <summary>
        /// Contenu détaillé du syllabus (obligatoire, maximum 500 caractères)
        /// </summary>
		[Required, MaxLength(500)]
		public string ContenuSyllabus { get; set; }

        /// <summary>
        /// Identifiant du syllabus parent (clé étrangère, optionnel)
        /// </summary>
		public int? syllabusId { get; set; }

        /// <summary>
        /// Navigation vers le syllabus parent associé à ce détail
        /// </summary>
		[ForeignKey("syllabusId")]
		public virtual Syllabus Syllabus { get; set; }
    }
}