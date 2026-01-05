namespace AppGestionCahierTexte.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<AppGestionCahierTexte.Models.BdCahierTexteContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        /// <summary>
        /// Méthode appelée après la migration vers la dernière version
        /// Utilisée pour ajouter des données initiales (seed data) dans la base de données
        /// </summary>
        /// <param name="context">Contexte de base de données</param>
        protected override void Seed(AppGestionCahierTexte.Models.BdCahierTexteContext context)
        {
            // Cette méthode est appelée après la migration vers la dernière version

            // On peut utiliser la méthode d'extension DbSet<T>.AddOrUpdate() 
            // pour éviter de créer des données en double

            // Ajout d'utilisateurs de test
            // Vérifier si les utilisateurs existent déjà pour éviter les doublons
            if (!context.Utilisateurs.Any(u => u.IdentifiantUtilisateur == "admin"))
            {
                // Créer un Chef de Département (administrateur)
                var chefDept = new AppGestionCahierTexte.Models.CheffeDepartement
                {
                    NomUtilisateur = "Admin",
                    PrenomUtilisateur = "Système",
                    IdentifiantUtilisateur = "admin",
                    MotDePasse = "admin123",
                    EmailUtilisateur = "admin@cahiertexte.com",
                    TelephoneUtilisateur = "0123456789",
                    AdresseUtilisateur = "Adresse Admin"
                };
                context.CheffeDepartements.Add(chefDept);
            }

            if (!context.Utilisateurs.Any(u => u.IdentifiantUtilisateur == "prof001"))
            {
                // Créer un Professeur
                var professeur = new AppGestionCahierTexte.Models.Professeur
                {
                    NomUtilisateur = "Dupont",
                    PrenomUtilisateur = "Jean",
                    IdentifiantUtilisateur = "prof001",
                    MotDePasse = "prof123",
                    EmailUtilisateur = "jean.dupont@cahiertexte.com",
                    TelephoneUtilisateur = "0123456780",
                    AdresseUtilisateur = "123 Rue des Professeurs",
                    SpecialiteProfesseur = "Informatique"
                };
                context.Professeurs.Add(professeur);
            }

            if (!context.Utilisateurs.Any(u => u.IdentifiantUtilisateur == "resp001"))
            {
                // Créer un Responsable de Classe
                var responsableClasse = new AppGestionCahierTexte.Models.ResponsableClasse
                {
                    NomUtilisateur = "Martin",
                    PrenomUtilisateur = "Marie",
                    IdentifiantUtilisateur = "resp001",
                    MotDePasse = "resp123",
                    EmailUtilisateur = "marie.martin@cahiertexte.com",
                    TelephoneUtilisateur = "0123456781",
                    AdresseUtilisateur = "456 Rue des Responsables",
                    MatriculeResponsable = "RESP-2026-001"
                };
                context.ResponsableClasses.Add(responsableClasse);
            }

            // Ajout d'années académiques de test
            if (!context.AnneeAcademiques.Any(a => a.LibelleAnneeAcademique == "2024-2025"))
            {
                var annee2024 = new AppGestionCahierTexte.Models.AnneeAcademique
                {
                    LibelleAnneeAcademique = "2024-2025",
                    ValueAnneeAcademique = 2024
                };
                context.AnneeAcademiques.Add(annee2024);
            }

            if (!context.AnneeAcademiques.Any(a => a.LibelleAnneeAcademique == "2025-2026"))
            {
                var annee2025 = new AppGestionCahierTexte.Models.AnneeAcademique
                {
                    LibelleAnneeAcademique = "2025-2026",
                    ValueAnneeAcademique = 2025
                };
                context.AnneeAcademiques.Add(annee2025);
            }

            if (!context.AnneeAcademiques.Any(a => a.LibelleAnneeAcademique == "2026-2027"))
            {
                var annee2026 = new AppGestionCahierTexte.Models.AnneeAcademique
                {
                    LibelleAnneeAcademique = "2026-2027",
                    ValueAnneeAcademique = 2026
                };
                context.AnneeAcademiques.Add(annee2026);
            }

            // Ajout de matières de test (après avoir créé les années académiques)
            context.SaveChanges(); // Sauvegarder d'abord les années académiques pour avoir leurs IDs
            
            var anneeAcademique2025 = context.AnneeAcademiques.FirstOrDefault(a => a.LibelleAnneeAcademique == "2025-2026");
            
            if (!context.Matieres.Any(m => m.LibelleMatiere == "Mathématiques"))
            {
                var matiere1 = new AppGestionCahierTexte.Models.Matiere
                {
                    LibelleMatiere = "Mathématiques",
                    VolumeHoraireMatiere = 60,
                    Niveau = "L3"
                };
                context.Matieres.Add(matiere1);
            }

            if (!context.Matieres.Any(m => m.LibelleMatiere == "Informatique"))
            {
                var matiere2 = new AppGestionCahierTexte.Models.Matiere
                {
                    LibelleMatiere = "Informatique",
                    VolumeHoraireMatiere = 80,
                    Niveau = "L3"
                };
                context.Matieres.Add(matiere2);
            }

            if (!context.Matieres.Any(m => m.LibelleMatiere == "Français"))
            {
                var matiere3 = new AppGestionCahierTexte.Models.Matiere
                {
                    LibelleMatiere = "Français",
                    VolumeHoraireMatiere = 40,
                    Niveau = "L3"
                };
                context.Matieres.Add(matiere3);
            }

            // Ajout de classes de test (nécessite qu'une année académique existe)
            if (anneeAcademique2025 != null && !context.Classes.Any(c => c.LibelleClasse == "L3 IAGE"))
            {
                var classe1 = new AppGestionCahierTexte.Models.Classe
                {
                    LibelleClasse = "L3 IAGE",
                    IdAnneeAcademique = anneeAcademique2025.IdAnneeAcademique
                };
                context.Classes.Add(classe1);
            }

            if (anneeAcademique2025 != null && !context.Classes.Any(c => c.LibelleClasse == "L2 Informatique"))
            {
                var classe2 = new AppGestionCahierTexte.Models.Classe
                {
                    LibelleClasse = "L2 Informatique",
                    IdAnneeAcademique = anneeAcademique2025.IdAnneeAcademique
                };
                context.Classes.Add(classe2);
            }

            // Sauvegarder tous les changements dans la base de données
            context.SaveChanges();
        }
    }
}
