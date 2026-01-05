using MySql.Data.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppGestionCahierTexte.Models
{
    /// <summary>
    /// Contexte de base de données Entity Framework pour l'application de gestion de cahier de texte
    /// Utilise MySQL comme système de gestion de base de données
    /// </summary>
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class BdCahierTexteContext:DbContext
    {
        /// <summary>
        /// Constructeur du contexte de base de données
        /// Utilise la chaîne de connexion "connCahiertexte" définie dans App.config
        /// </summary>
        public BdCahierTexteContext():base("connCahiertexte")
        {
        }

        /// <summary>
        /// Collection des matières (sujets d'enseignement)
        /// </summary>
        public DbSet<Matiere> Matieres { get; set; }
        
        /// <summary>
        /// Collection des années académiques
        /// </summary>
        public DbSet<AnneeAcademique>  AnneeAcademiques {  get; set; }

        /// <summary>
        /// Collection des classes
        /// </summary>
        public DbSet<Classe> Classes { get; set; }

        /// <summary>
        /// Collection de tous les utilisateurs (classe de base pour Professeur, ResponsableClasse, CheffeDepartement)
        /// Entity Framework utilise le polymorphisme (Table per Hierarchy)
        /// </summary>
        public DbSet<Utilisateur> Utilisateurs { get; set; }

        /// <summary>
        /// Collection des professeurs
        /// </summary>
        public DbSet<Professeur> Professeurs { get; set; }

        /// <summary>
        /// Collection des responsables de classe
        /// </summary>
        public DbSet<ResponsableClasse> ResponsableClasses { get; set; }

        /// <summary>
        /// Collection des chefs de département
        /// </summary>
        public DbSet<CheffeDepartement> CheffeDepartements { get; set; }

        /// <summary>
        /// Collection des cahiers de texte
        /// </summary>
        public DbSet<CahierTexte> CahierTextes { get; set; }

        /// <summary>
        /// Collection des syllabus (programmes d'enseignement)
        /// </summary>
        public DbSet<Syllabus> Syllabuses { get; set; }

        /// <summary>
        /// Collection des détails de syllabus
        /// </summary>
        public DbSet<DetailsSyllabus> DetailsSyllabuses { get; set; }

    }
}
