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
    public partial class frmResponsableClasse : Form
    {
        private BdCahierTexteContext dbContext;
        private ResponsableClasse responsableClasseSelectionne = null;

        public frmResponsableClasse()
        {
            InitializeComponent();
            dbContext = new BdCahierTexteContext();
        }

        private void frmResponsableClasse_Load(object sender, EventArgs e)
        {
            // Appliquer le style moderne
            FormDesignHelper.ApplyModernStyle(this);
            FormDesignHelper.ApplyModernStyle(dgvResponsableClasses);
            
            // Appliquer le style aux boutons
            FormDesignHelper.ApplyModernStyle(btnAjouter, ButtonStyle.Success);
            FormDesignHelper.ApplyModernStyle(btnModifier, ButtonStyle.Primary);
            FormDesignHelper.ApplyModernStyle(btnSupprimer, ButtonStyle.Danger);
            FormDesignHelper.ApplyModernStyle(btnAnnuler, ButtonStyle.Warning);
            
            ChargerResponsableClasses();
            ReinitialiserFormulaire();
        }

        private void ChargerResponsableClasses()
        {
            try
            {
                var responsables = dbContext.ResponsableClasses.ToList();
                dgvResponsableClasses.DataSource = responsables.Select(r => new
                {
                    r.IdUtilisateur,
                    Nom = r.NomUtilisateur,
                    Prénom = r.PrenomUtilisateur,
                    Email = r.EmailUtilisateur,
                    Téléphone = r.TelephoneUtilisateur,
                    Adresse = r.AdresseUtilisateur,
                    Identifiant = r.IdentifiantUtilisateur,
                    Matricule = r.MatriculeResponsable
                }).ToList();

                // Masquer la colonne ID
                if (dgvResponsableClasses.Columns["IdUtilisateur"] != null)
                    dgvResponsableClasses.Columns["IdUtilisateur"].Visible = false;

                // Configurer le mode de redimensionnement automatique
                dgvResponsableClasses.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors du chargement des responsables de classe : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvResponsableClasses_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int idUtilisateur = (int)dgvResponsableClasses.Rows[e.RowIndex].Cells["IdUtilisateur"].Value;
                responsableClasseSelectionne = dbContext.ResponsableClasses.FirstOrDefault(r => r.IdUtilisateur == idUtilisateur);
                if (responsableClasseSelectionne != null)
                {
                    txtNom.Text = responsableClasseSelectionne.NomUtilisateur;
                    txtPrenom.Text = responsableClasseSelectionne.PrenomUtilisateur;
                    txtEmail.Text = responsableClasseSelectionne.EmailUtilisateur;
                    txtTelephone.Text = responsableClasseSelectionne.TelephoneUtilisateur;
                    txtAdresse.Text = responsableClasseSelectionne.AdresseUtilisateur ?? "";
                    txtIdentifiant.Text = responsableClasseSelectionne.IdentifiantUtilisateur;
                    txtMotDePasse.Text = responsableClasseSelectionne.MotDePasse;
                    txtMatricule.Text = responsableClasseSelectionne.MatriculeResponsable ?? "";
                }
            }
        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            if (ValiderFormulaire())
            {
                try
                {
                    ResponsableClasse nouveauResponsable = new ResponsableClasse
                    {
                        NomUtilisateur = txtNom.Text.Trim(),
                        PrenomUtilisateur = txtPrenom.Text.Trim(),
                        EmailUtilisateur = txtEmail.Text.Trim(),
                        TelephoneUtilisateur = txtTelephone.Text.Trim(),
                        AdresseUtilisateur = txtAdresse.Text.Trim(),
                        IdentifiantUtilisateur = txtIdentifiant.Text.Trim(),
                        MotDePasse = txtMotDePasse.Text.Trim(),
                        MatriculeResponsable = txtMatricule.Text.Trim()
                    };

                    dbContext.ResponsableClasses.Add(nouveauResponsable);
                    dbContext.SaveChanges();
                    MessageBox.Show("Responsable de classe ajouté avec succès!", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ChargerResponsableClasses();
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
            if (responsableClasseSelectionne == null)
            {
                MessageBox.Show("Veuillez sélectionner un responsable de classe à modifier", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (ValiderFormulaire())
            {
                try
                {
                    responsableClasseSelectionne.NomUtilisateur = txtNom.Text.Trim();
                    responsableClasseSelectionne.PrenomUtilisateur = txtPrenom.Text.Trim();
                    responsableClasseSelectionne.EmailUtilisateur = txtEmail.Text.Trim();
                    responsableClasseSelectionne.TelephoneUtilisateur = txtTelephone.Text.Trim();
                    responsableClasseSelectionne.AdresseUtilisateur = txtAdresse.Text.Trim();
                    responsableClasseSelectionne.IdentifiantUtilisateur = txtIdentifiant.Text.Trim();
                    responsableClasseSelectionne.MotDePasse = txtMotDePasse.Text.Trim();
                    responsableClasseSelectionne.MatriculeResponsable = txtMatricule.Text.Trim();

                    dbContext.SaveChanges();
                    MessageBox.Show("Responsable de classe modifié avec succès!", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ChargerResponsableClasses();
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
            if (responsableClasseSelectionne == null)
            {
                MessageBox.Show("Veuillez sélectionner un responsable de classe à supprimer", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult result = MessageBox.Show(
                $"Êtes-vous sûr de vouloir supprimer le responsable de classe \"{responsableClasseSelectionne.NomUtilisateur} {responsableClasseSelectionne.PrenomUtilisateur}\" ?",
                "Confirmation",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    dbContext.ResponsableClasses.Remove(responsableClasseSelectionne);
                    dbContext.SaveChanges();
                    MessageBox.Show("Responsable de classe supprimé avec succès!", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ChargerResponsableClasses();
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
            txtMatricule.Clear();
            responsableClasseSelectionne = null;
            if (dgvResponsableClasses.Rows.Count > 0)
            {
                dgvResponsableClasses.ClearSelection();
            }
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            dbContext?.Dispose();
        }
    }
}

