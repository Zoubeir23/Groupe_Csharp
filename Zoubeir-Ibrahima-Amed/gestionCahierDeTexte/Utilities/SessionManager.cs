using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppGestionCahierTexte.Models;

namespace AppGestionCahierTexte.Utilities
{
    /// <summary>
    /// Gère la session de l'utilisateur connecté
    /// </summary>
    public static class SessionManager
    {
        private static Utilisateur _utilisateurConnecte;

        /// <summary>
        /// L'utilisateur actuellement connecté
        /// </summary>
        public static Utilisateur UtilisateurConnecte
        {
            get { return _utilisateurConnecte; }
            set { _utilisateurConnecte = value; }
        }

        /// <summary>
        /// Détermine si un utilisateur est connecté
        /// </summary>
        public static bool EstConnecte
        {
            get { return _utilisateurConnecte != null; }
        }

        /// <summary>
        /// Détermine le type d'utilisateur (rôle)
        /// </summary>
        public static string GetRoleUtilisateur()
        {
            if (_utilisateurConnecte == null)
                return null;

            if (_utilisateurConnecte is Professeur)
                return "Professeur";
            else if (_utilisateurConnecte is ResponsableClasse)
                return "ResponsableClasse";
            else if (_utilisateurConnecte is CheffeDepartement)
                return "CheffeDepartement";
            else
                return "Utilisateur";
        }

        /// <summary>
        /// Déconnecte l'utilisateur
        /// </summary>
        public static void Deconnecter()
        {
            _utilisateurConnecte = null;
        }

        /// <summary>
        /// Vérifie si l'utilisateur est un Professeur
        /// </summary>
        public static bool EstProfesseur()
        {
            return _utilisateurConnecte is Professeur;
        }

        /// <summary>
        /// Vérifie si l'utilisateur est un ResponsableClasse
        /// </summary>
        public static bool EstResponsableClasse()
        {
            return _utilisateurConnecte is ResponsableClasse;
        }

        /// <summary>
        /// Vérifie si l'utilisateur est un CheffeDepartement
        /// </summary>
        public static bool EstCheffeDepartement()
        {
            return _utilisateurConnecte is CheffeDepartement;
        }
    }
}

