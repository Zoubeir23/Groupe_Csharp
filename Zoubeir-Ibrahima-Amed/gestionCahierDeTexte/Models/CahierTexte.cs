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
    /// Classe représentant un cahier de texte dans le système
    /// Le cahier de texte contient les notes et activités d'une classe
    /// </summary>
    public class CahierTexte
    {
        /// <summary>
        /// Identifiant unique du cahier de texte (clé primaire)
        /// </summary>
		[Key]
        public int IdCahierTexte { get; set; }

        /// <summary>
        /// Titre du cahier de texte (obligatoire, maximum 150 caractères)
        /// </summary>
		[Required, MaxLength(150)]
        public string TitreCahierTexte { get; set; }

        /// <summary>
        /// Description du contenu du cahier de texte (obligatoire, maximum 250 caractères)
        /// </summary>
		[Required, MaxLength(250)]
        public string DescriptionCahierTexte { get; set; }

        /// <summary>
        /// Date de création du cahier de texte (par défaut, date actuelle)
        /// </summary>
		public DateTime DateCahierTexte { get; set; }= DateTime.Now;

        /// <summary>
        /// Année du cahier de texte (optionnel)
        /// </summary>
        public int? Annee { get; set; }

        /// <summary>
        /// Identifiant du responsable de classe associé (clé étrangère, optionnel)
        /// </summary>
		public int? IdResponsableClasse { get; set; }

        /// <summary>
        /// Navigation vers le responsable de classe associé à ce cahier de texte
        /// </summary>
		[ForeignKey("IdResponsableClasse")]
		public virtual ResponsableClasse ResponsableClasse { get; set; }
    }
}