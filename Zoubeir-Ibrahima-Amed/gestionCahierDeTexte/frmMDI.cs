using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
// appelé pour accéder au formulaire Matiere
using AppGestionCahierTexte.Views.Parametre;
using AppGestionCahierTexte.Utilities;
using Microsoft.VisualBasic.Devices;

namespace AppGestionCahierTexte
{
    public partial class frmMDI : Form
    {
        public frmMDI()
        {
            InitializeComponent();
        }

        private void matiereToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fermer();
            //instancier le formulaire Matiere
            frmMatiere f = new frmMatiere();

            //Specifier le formulaire parent
            f.MdiParent = this;

            //Afficher le formulaire
            f.Show();
            //Afficher le formulaire en mode maximisé (prendre l'entiereté de l'espace disponible)

            f.WindowState = FormWindowState.Maximized;

        }

        private void classeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fermer();
            frmClasse f = new frmClasse();
            f.MdiParent = this;
            f.Show();
            f.WindowState = FormWindowState.Maximized;
        }

        private void anneeAcademiqueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fermer();
            frmAnneeAcademique f = new frmAnneeAcademique();
            f.MdiParent = this;
            f.Show();
            f.WindowState = FormWindowState.Maximized;
        }

        private void cheffeDepartementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fermer();
            frmCheffeDepartement f = new frmCheffeDepartement();
            f.MdiParent = this;
            f.Show();
            f.WindowState = FormWindowState.Maximized;
        }

        private void professeurToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fermer();
            frmProfesseur f = new frmProfesseur();
            f.MdiParent = this;
            f.Show();
            f.WindowState = FormWindowState.Maximized;
        }

        private void responsableClasseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fermer();
            frmResponsableClasse f = new frmResponsableClasse();
            f.MdiParent = this;
            f.Show();
            f.WindowState = FormWindowState.Maximized;
        }

        private void seDeconnecterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Déconnecter l'utilisateur
            AppGestionCahierTexte.Utilities.SessionManager.Deconnecter();
            
            // Afficher le formulaire de connexion
            frmConnexion f = new frmConnexion();
            f.Show();
            this.Close();
        }

        private void quitterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Ferme tous les formulaires enfants ouverts dans le conteneur MDI
        /// </summary>
        private void fermer()
        {
            // Récupérer tous les formulaires enfants
            Form[] charr = this.MdiChildren;

            // Pour chaque formulaire enfant, le fermer
            foreach (Form chform in charr)
            {
                chform.Close();
            }
        }

        private void frmMDI_Load(object sender, EventArgs e)
        {
            Computer myComputer = new Computer();
            this.Width = myComputer.Screen.Bounds.Width;
            this.Height = myComputer.Screen.Bounds.Height;
            this.Location = new Point(0, 0);

            // Gérer les permissions selon le rôle de l'utilisateur connecté
            GererPermissionsSelonRole();

            // Afficher le nom de l'utilisateur dans le titre
            if (SessionManager.EstConnecte)
            {
                var utilisateur = SessionManager.UtilisateurConnecte;
                string nomComplet = $"{utilisateur.PrenomUtilisateur} {utilisateur.NomUtilisateur}";
                string role = SessionManager.GetRoleUtilisateur();
                this.Text = $"Gestion Cahier de Texte - {nomComplet} ({role})";
            }
        }

        /// <summary>
        /// Gère les permissions d'accès aux menus selon le rôle de l'utilisateur
        /// </summary>
        private void GererPermissionsSelonRole()
        {
            if (!SessionManager.EstConnecte)
            {
                // Si aucun utilisateur n'est connecté, masquer tous les menus
                parametreToolStripMenuItem.Visible = false;
                return;
            }

            // CheffeDepartement : Accès complet (tous les menus)
            if (SessionManager.EstCheffeDepartement())
            {
                // Tous les menus sont visibles par défaut
                matiereToolStripMenuItem.Visible = true;
                classeToolStripMenuItem.Visible = true;
                anneeAcademiqueToolStripMenuItem.Visible = true;
                cheffeDepartementToolStripMenuItem.Visible = true;
                professeurToolStripMenuItem.Visible = true;
                responsableClasseToolStripMenuItem.Visible = true;
            }
            // Professeur : Accès limité
            else if (SessionManager.EstProfesseur())
            {
                // Le professeur peut accéder à : Matière, Classe, Année Académique
                matiereToolStripMenuItem.Visible = true;
                classeToolStripMenuItem.Visible = true;
                anneeAcademiqueToolStripMenuItem.Visible = true;
                // Le professeur ne peut pas gérer les utilisateurs
                cheffeDepartementToolStripMenuItem.Visible = false;
                professeurToolStripMenuItem.Visible = false;
                responsableClasseToolStripMenuItem.Visible = false;
            }
            // ResponsableClasse : Accès limité
            else if (SessionManager.EstResponsableClasse())
            {
                // Le responsable de classe peut accéder à : Classe, Année Académique, ResponsableClasse (son propre profil)
                matiereToolStripMenuItem.Visible = false;
                classeToolStripMenuItem.Visible = true;
                anneeAcademiqueToolStripMenuItem.Visible = true;
                cheffeDepartementToolStripMenuItem.Visible = false;
                professeurToolStripMenuItem.Visible = false;
                responsableClasseToolStripMenuItem.Visible = true; // Peut voir la liste des responsables
            }
            else
            {
                // Utilisateur générique : accès très limité
                matiereToolStripMenuItem.Visible = false;
                classeToolStripMenuItem.Visible = false;
                anneeAcademiqueToolStripMenuItem.Visible = false;
                cheffeDepartementToolStripMenuItem.Visible = false;
                professeurToolStripMenuItem.Visible = false;
                responsableClasseToolStripMenuItem.Visible = false;
            }
        }
    }
}
