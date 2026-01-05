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
    public partial class frmCheffeDepartement : Form
    {
        private BdCahierTexteContext dbContext;
        private CheffeDepartement cheffeDepartementSelectionne = null;

        public frmCheffeDepartement()
        {
            InitializeComponent();
            dbContext = new BdCahierTexteContext();
        }

        private void frmCheffeDepartement_Load(object sender, EventArgs e)
        {
            // Appliquer le style moderne
            FormDesignHelper.ApplyModernStyle(this);
            FormDesignHelper.ApplyModernStyle(dgvCheffeDepartements);
            
            // Appliquer le style aux boutons
            FormDesignHelper.ApplyModernStyle(btnAjouter, ButtonStyle.Success);
            FormDesignHelper.ApplyModernStyle(btnModifier, ButtonStyle.Primary);
            FormDesignHelper.ApplyModernStyle(btnSupprimer, ButtonStyle.Danger);
            FormDesignHelper.ApplyModernStyle(btnAnnuler, ButtonStyle.Warning);
            
            ChargerCheffeDepartements();
            ReinitialiserFormulaire();
        }

        private void ChargerCheffeDepartements()
        {
            try
            {
                var chefs = dbContext.CheffeDepartements.ToList();
                dgvCheffeDepartements.DataSource = chefs.Select(c => new
                {
                    c.IdUtilisateur,
                    Nom = c.NomUtilisateur,
                    Prénom = c.PrenomUtilisateur,
                    Email = c.EmailUtilisateur,
                    Téléphone = c.TelephoneUtilisateur,
                    Adresse = c.AdresseUtilisateur,
                    Identifiant = c.IdentifiantUtilisateur
                }).ToList();

                // Masquer la colonne ID
                if (dgvCheffeDepartements.Columns["IdUtilisateur"] != null)
                    dgvCheffeDepartements.Columns["IdUtilisateur"].Visible = false;

                // Configurer le mode de redimensionnement automatique
                dgvCheffeDepartements.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors du chargement des chefs de département : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvCheffeDepartements_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int idUtilisateur = (int)dgvCheffeDepartements.Rows[e.RowIndex].Cells["IdUtilisateur"].Value;
                cheffeDepartementSelectionne = dbContext.CheffeDepartements.FirstOrDefault(c => c.IdUtilisateur == idUtilisateur);
                if (cheffeDepartementSelectionne != null)
                {
                    txtNom.Text = cheffeDepartementSelectionne.NomUtilisateur;
                    txtPrenom.Text = cheffeDepartementSelectionne.PrenomUtilisateur;
                    txtEmail.Text = cheffeDepartementSelectionne.EmailUtilisateur;
                    txtTelephone.Text = cheffeDepartementSelectionne.TelephoneUtilisateur;
                    txtAdresse.Text = cheffeDepartementSelectionne.AdresseUtilisateur ?? "";
                    txtIdentifiant.Text = cheffeDepartementSelectionne.IdentifiantUtilisateur;
                    txtMotDePasse.Text = cheffeDepartementSelectionne.MotDePasse;
                }
            }
        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            if (ValiderFormulaire())
            {
                try
                {
                    CheffeDepartement nouveauChef = new CheffeDepartement
                    {
                        NomUtilisateur = txtNom.Text.Trim(),
                        PrenomUtilisateur = txtPrenom.Text.Trim(),
                        EmailUtilisateur = txtEmail.Text.Trim(),
                        TelephoneUtilisateur = txtTelephone.Text.Trim(),
                        AdresseUtilisateur = txtAdresse.Text.Trim(),
                        IdentifiantUtilisateur = txtIdentifiant.Text.Trim(),
                        MotDePasse = txtMotDePasse.Text.Trim()
                    };

                    dbContext.CheffeDepartements.Add(nouveauChef);
                    dbContext.SaveChanges();
                    MessageBox.Show("Chef de département ajouté avec succès!", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ChargerCheffeDepartements();
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
            if (cheffeDepartementSelectionne == null)
            {
                MessageBox.Show("Veuillez sélectionner un chef de département à modifier", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (ValiderFormulaire())
            {
                try
                {
                    cheffeDepartementSelectionne.NomUtilisateur = txtNom.Text.Trim();
                    cheffeDepartementSelectionne.PrenomUtilisateur = txtPrenom.Text.Trim();
                    cheffeDepartementSelectionne.EmailUtilisateur = txtEmail.Text.Trim();
                    cheffeDepartementSelectionne.TelephoneUtilisateur = txtTelephone.Text.Trim();
                    cheffeDepartementSelectionne.AdresseUtilisateur = txtAdresse.Text.Trim();
                    cheffeDepartementSelectionne.IdentifiantUtilisateur = txtIdentifiant.Text.Trim();
                    cheffeDepartementSelectionne.MotDePasse = txtMotDePasse.Text.Trim();

                    dbContext.SaveChanges();
                    MessageBox.Show("Chef de département modifié avec succès!", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ChargerCheffeDepartements();
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
            if (cheffeDepartementSelectionne == null)
            {
                MessageBox.Show("Veuillez sélectionner un chef de département à supprimer", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult result = MessageBox.Show(
                $"Êtes-vous sûr de vouloir supprimer le chef de département \"{cheffeDepartementSelectionne.NomUtilisateur} {cheffeDepartementSelectionne.PrenomUtilisateur}\" ?",
                "Confirmation",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    dbContext.CheffeDepartements.Remove(cheffeDepartementSelectionne);
                    dbContext.SaveChanges();
                    MessageBox.Show("Chef de département supprimé avec succès!", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ChargerCheffeDepartements();
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
            cheffeDepartementSelectionne = null;
            if (dgvCheffeDepartements.Rows.Count > 0)
            {
                dgvCheffeDepartements.ClearSelection();
            }
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            dbContext?.Dispose();
        }
    }
}

