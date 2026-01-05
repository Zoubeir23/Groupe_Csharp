using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AppGestionCahierTexte.Models;

namespace AppGestionCahierTexte.Views.Parametre
{
    public partial class frmProfesseur : Form
    {
        private BdCahierTexteContext dbContext;
        private Professeur professeurSelectionne = null;

        public frmProfesseur()
        {
            InitializeComponent();
            dbContext = new BdCahierTexteContext();
        }

        private void frmProfesseur_Load(object sender, EventArgs e)
        {
            // Appliquer le style moderne
            FormDesignHelper.ApplyModernStyle(this);
            FormDesignHelper.ApplyModernStyle(dgvProfesseurs);
            
            // Appliquer le style aux boutons
            FormDesignHelper.ApplyModernStyle(btnAjouter, ButtonStyle.Success);
            FormDesignHelper.ApplyModernStyle(btnModifier, ButtonStyle.Primary);
            FormDesignHelper.ApplyModernStyle(btnSupprimer, ButtonStyle.Danger);
            FormDesignHelper.ApplyModernStyle(btnAnnuler, ButtonStyle.Warning);
            
            ChargerProfesseurs();
            ReinitialiserFormulaire();
        }

        private void ChargerProfesseurs()
        {
            try
            {
                var professeurs = dbContext.Professeurs.ToList();
                dgvProfesseurs.DataSource = professeurs.Select(p => new
                {
                    p.IdUtilisateur,
                    Nom = p.NomUtilisateur,
                    Prénom = p.PrenomUtilisateur,
                    Email = p.EmailUtilisateur,
                    Téléphone = p.TelephoneUtilisateur,
                    Adresse = p.AdresseUtilisateur,
                    Identifiant = p.IdentifiantUtilisateur,
                    Spécialité = p.SpecialiteProfesseur
                }).ToList();

                // Masquer la colonne ID
                if (dgvProfesseurs.Columns["IdUtilisateur"] != null)
                    dgvProfesseurs.Columns["IdUtilisateur"].Visible = false;

                // Configurer le mode de redimensionnement automatique
                dgvProfesseurs.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors du chargement des professeurs : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvProfesseurs_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int idUtilisateur = (int)dgvProfesseurs.Rows[e.RowIndex].Cells["IdUtilisateur"].Value;
                professeurSelectionne = dbContext.Professeurs.FirstOrDefault(p => p.IdUtilisateur == idUtilisateur);
                if (professeurSelectionne != null)
                {
                    txtNom.Text = professeurSelectionne.NomUtilisateur;
                    txtPrenom.Text = professeurSelectionne.PrenomUtilisateur;
                    txtEmail.Text = professeurSelectionne.EmailUtilisateur;
                    txtTelephone.Text = professeurSelectionne.TelephoneUtilisateur;
                    txtAdresse.Text = professeurSelectionne.AdresseUtilisateur ?? "";
                    txtIdentifiant.Text = professeurSelectionne.IdentifiantUtilisateur;
                    txtMotDePasse.Text = professeurSelectionne.MotDePasse;
                    txtSpecialite.Text = professeurSelectionne.SpecialiteProfesseur ?? "";
                }
            }
        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            if (ValiderFormulaire())
            {
                try
                {
                    Professeur nouveauProfesseur = new Professeur
                    {
                        NomUtilisateur = txtNom.Text.Trim(),
                        PrenomUtilisateur = txtPrenom.Text.Trim(),
                        EmailUtilisateur = txtEmail.Text.Trim(),
                        TelephoneUtilisateur = txtTelephone.Text.Trim(),
                        AdresseUtilisateur = txtAdresse.Text.Trim(),
                        IdentifiantUtilisateur = txtIdentifiant.Text.Trim(),
                        MotDePasse = txtMotDePasse.Text.Trim(),
                        SpecialiteProfesseur = txtSpecialite.Text.Trim()
                    };

                    dbContext.Professeurs.Add(nouveauProfesseur);
                    dbContext.SaveChanges();
                    MessageBox.Show("Professeur ajouté avec succès!", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ChargerProfesseurs();
                    ReinitialiserFormulaire();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur lors de l'ajout : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            if (professeurSelectionne == null)
            {
                MessageBox.Show("Veuillez sélectionner un professeur à modifier", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (ValiderFormulaire())
            {
                try
                {
                    professeurSelectionne.NomUtilisateur = txtNom.Text.Trim();
                    professeurSelectionne.PrenomUtilisateur = txtPrenom.Text.Trim();
                    professeurSelectionne.EmailUtilisateur = txtEmail.Text.Trim();
                    professeurSelectionne.TelephoneUtilisateur = txtTelephone.Text.Trim();
                    professeurSelectionne.AdresseUtilisateur = txtAdresse.Text.Trim();
                    professeurSelectionne.IdentifiantUtilisateur = txtIdentifiant.Text.Trim();
                    professeurSelectionne.MotDePasse = txtMotDePasse.Text.Trim();
                    professeurSelectionne.SpecialiteProfesseur = txtSpecialite.Text.Trim();

                    dbContext.SaveChanges();
                    MessageBox.Show("Professeur modifié avec succès!", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ChargerProfesseurs();
                    ReinitialiserFormulaire();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur lors de la modification : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            if (professeurSelectionne == null)
            {
                MessageBox.Show("Veuillez sélectionner un professeur à supprimer", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult result = MessageBox.Show(
                $"Êtes-vous sûr de vouloir supprimer le professeur \"{professeurSelectionne.NomUtilisateur} {professeurSelectionne.PrenomUtilisateur}\" ?",
                "Confirmation",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    dbContext.Professeurs.Remove(professeurSelectionne);
                    dbContext.SaveChanges();
                    MessageBox.Show("Professeur supprimé avec succès!", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ChargerProfesseurs();
                    ReinitialiserFormulaire();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur lors de la suppression : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            ReinitialiserFormulaire();
        }

        private bool ValiderFormulaire()
        {
            if (string.IsNullOrWhiteSpace(txtNom.Text))
            {
                MessageBox.Show("Le nom est obligatoire", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNom.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtPrenom.Text))
            {
                MessageBox.Show("Le prénom est obligatoire", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPrenom.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("L'email est obligatoire", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return false;
            }

            if (!txtEmail.Text.Contains("@") || !txtEmail.Text.Contains("."))
            {
                MessageBox.Show("L'email n'est pas valide", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtTelephone.Text))
            {
                MessageBox.Show("Le téléphone est obligatoire", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTelephone.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtIdentifiant.Text))
            {
                MessageBox.Show("L'identifiant est obligatoire", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtIdentifiant.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtMotDePasse.Text))
            {
                MessageBox.Show("Le mot de passe est obligatoire", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMotDePasse.Focus();
                return false;
            }

            if (txtMotDePasse.Text.Length < 6)
            {
                MessageBox.Show("Le mot de passe doit contenir au moins 6 caractères", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMotDePasse.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtSpecialite.Text))
            {
                MessageBox.Show("La spécialité est obligatoire", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSpecialite.Focus();
                return false;
            }

            return true;
        }

        private void ReinitialiserFormulaire()
        {
            txtNom.Clear();
            txtPrenom.Clear();
            txtEmail.Clear();
            txtTelephone.Clear();
            txtAdresse.Clear();
            txtIdentifiant.Clear();
            txtMotDePasse.Clear();
            txtSpecialite.Clear();
            professeurSelectionne = null;
            if (dgvProfesseurs.Rows.Count > 0)
            {
                dgvProfesseurs.ClearSelection();
            }
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            dbContext?.Dispose();
        }
    }
}

