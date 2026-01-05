using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppGestionCahierTexte.Models
{
    /// <summary>
    /// Classe représentant un responsable de classe dans le système
    /// Hérite de la classe Utilisateur et ajoute le matricule du responsable
    /// </summary>
    public class ResponsableClasse : Utilisateur
    {
        /// <summary>
        /// Matricule unique du responsable de classe (optionnel)
        /// Exemple: "RESP-2026-001"
        /// </summary>
        public string MatriculeResponsable { get; set; }

    }
}
