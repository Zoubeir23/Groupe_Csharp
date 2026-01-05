using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppGestionCahierTexte.Models
{
    /// <summary>
    /// Classe de base pour tous les utilisateurs du système
    /// Les classes Professeur, ResponsableClasse et CheffeDepartement héritent de cette classe
    /// </summary>
    public class Utilisateur
    {
        /// <summary>
        /// Identifiant unique de l'utilisateur (clé primaire)
        /// </summary>
        [Key]
        public int IdUtilisateur { get; set; }

        /// <summary>
        /// Nom de famille de l'utilisateur (obligatoire, maximum 89 caractères)
        /// </summary>
        [Required, MaxLength(89)]
        public string NomUtilisateur { get; set; }

        /// <summary>
        /// Prénom de l'utilisateur (obligatoire, maximum 80 caractères)
        /// </summary>
        [Required, MaxLength(80)]
        public string PrenomUtilisateur { get; set; }

        /// <summary>
        /// Adresse de l'utilisateur (optionnel, maximum 300 caractères)
        /// </summary>
        [MaxLength(300)]
        public string AdresseUtilisateur { get; set; }

        /// <summary>
        /// Adresse email de l'utilisateur (obligatoire, maximum 100 caractères)
        /// </summary>
        [Required, MaxLength(100)]
        public string EmailUtilisateur { get; set; }

        /// <summary>
        /// Numéro de téléphone de l'utilisateur (obligatoire, maximum 10 caractères)
        /// </summary>
        [Required, MaxLength(10)]
        public string TelephoneUtilisateur { get; set; }

        /// <summary>
        /// Identifiant de connexion de l'utilisateur (obligatoire, maximum 20 caractères)
        /// </summary>
        [Required, MaxLength(20)]
        public string IdentifiantUtilisateur { get; set; }

        /// <summary>
        /// Mot de passe de l'utilisateur (obligatoire, maximum 300 caractères)
        /// NOTE: En production, ce champ devrait contenir un hash du mot de passe, pas le mot de passe en clair
        /// </summary>
        [Required, MaxLength(300)]
        public string MotDePasse { get; set; }
    }
}