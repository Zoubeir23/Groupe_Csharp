using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AppGestionCahierTexte.Models;
using AppGestionCahierTexte.Utilities;

namespace AppGestionCahierTexte
{
    public partial class frmConnexion : Form
    {
        public frmConnexion()
        {
            InitializeComponent();
        }

        private void btnQuitter_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnSeConnecter_Click(object sender, EventArgs e)
        {
            // Vérifier que les champs sont remplis
            if (string.IsNullOrWhiteSpace(txtIdentifiant.Text))
            {
                MessageBox.Show("Veuillez saisir votre identifiant.", "Champ requis", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtIdentifiant.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtMotDePasse.Text))
            {
                MessageBox.Show("Veuillez saisir votre mot de passe.", "Champ requis", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMotDePasse.Focus();
                return;
            }

            try
            {
                // Connexion à la base de données
                using (BdCahierTexteContext db = new BdCahierTexteContext())
                {
                    // Rechercher l'utilisateur par identifiant et mot de passe
                    // Entity Framework utilise le polymorphisme (Table per Hierarchy)
                    // Donc on cherche dans Utilisateurs qui contient tous les types
                    Utilisateur utilisateur = db.Utilisateurs
                        .FirstOrDefault(u => u.IdentifiantUtilisateur == txtIdentifiant.Text.Trim()
                                        && u.MotDePasse == txtMotDePasse.Text.Trim());

                    if (utilisateur != null)
                    {
                        // Authentification réussie
                        // Stocker l'utilisateur dans la session
                        SessionManager.UtilisateurConnecte = utilisateur;

                        // Afficher un message de bienvenue
                        string role = SessionManager.GetRoleUtilisateur();
                        string nomComplet = $"{utilisateur.PrenomUtilisateur} {utilisateur.NomUtilisateur}";
                        MessageBox.Show($"Bienvenue {nomComplet} !\nRôle: {role}", 
                            "Connexion réussie", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Ouvrir le formulaire principal MDI
                        frmMDI f = new frmMDI();
                        f.Show();
                        this.Hide();
                    }
                    else
                    {
                        // Authentification échouée
                        MessageBox.Show("Identifiant ou mot de passe incorrect.\nVeuillez réessayer.", 
                            "Erreur d'authentification", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtMotDePasse.Clear();
                        txtIdentifiant.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Une erreur s'est produite lors de la connexion :\n{ex.Message}", 
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
