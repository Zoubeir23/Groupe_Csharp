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
    /// <summary>
    /// Formulaire de gestion des années académiques (CRUD complet)
    /// </summary>
    public partial class frmAnneeAcademique : Form
    {
        private BdCahierTexteContext dbContext;
        private AnneeAcademique anneeAcademiqueSelectionnee = null;

        /// <summary>
        /// Constructeur du formulaire
        /// </summary>
        public frmAnneeAcademique()
        {
            InitializeComponent();
            dbContext = new BdCahierTexteContext();
        }

        /// <summary>
        /// Événement déclenché au chargement du formulaire
        /// Applique le style moderne et charge les données
        /// </summary>
        private void frmAnneeAcademique_Load(object sender, EventArgs e)
        {
            // Appliquer le style moderne
            FormDesignHelper.ApplyModernStyle(this);
            FormDesignHelper.ApplyModernStyle(dgvAnneeAcademiques);
            
            // Appliquer le style aux boutons
            FormDesignHelper.ApplyModernStyle(btnAjouter, ButtonStyle.Success);
            FormDesignHelper.ApplyModernStyle(btnModifier, ButtonStyle.Primary);
            FormDesignHelper.ApplyModernStyle(btnSupprimer, ButtonStyle.Danger);
            FormDesignHelper.ApplyModernStyle(btnAnnuler, ButtonStyle.Warning);
            
            ChargerAnneeAcademiques();
            ReinitialiserFormulaire();
        }

        /// <summary>
        /// Charge toutes les années académiques depuis la base de données et les affiche dans la DataGridView
        /// </summary>
        private void ChargerAnneeAcademiques()
        {
            try
            {
                var annees = dbContext.AnneeAcademiques.ToList();
                dgvAnneeAcademiques.DataSource = annees.Select(a => new
                {
                    a.IdAnneeAcademique,
                    a.LibelleAnneeAcademique,
                    a.ValueAnneeAcademique
                }).ToList();

                dgvAnneeAcademiques.Columns["IdAnneeAcademique"].Visible = false;
                dgvAnneeAcademiques.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors du chargement des années académiques : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Événement déclenché lors du clic sur une cellule de la DataGridView
        /// Charge les données de l'année académique sélectionnée dans le formulaire
        /// </summary>
        private void dgvAnneeAcademiques_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int idAnnee = (int)dgvAnneeAcademiques.Rows[e.RowIndex].Cells["IdAnneeAcademique"].Value;
                anneeAcademiqueSelectionnee = dbContext.AnneeAcademiques.FirstOrDefault(a => a.IdAnneeAcademique == idAnnee);
                if (anneeAcademiqueSelectionnee != null)
                {
                    txtLibelle.Text = anneeAcademiqueSelectionnee.LibelleAnneeAcademique;
                    numValueAnnee.Value = anneeAcademiqueSelectionnee.ValueAnneeAcademique;
                }
            }
        }

        /// <summary>
        /// Événement déclenché lors du clic sur le bouton "Ajouter"
        /// Ajoute une nouvelle année académique dans la base de données
        /// </summary>
        private void btnAjouter_Click(object sender, EventArgs e)
        {
            if (ValiderFormulaire())
            {
                try
                {
                    AnneeAcademique nouvelleAnnee = new AnneeAcademique
                    {
                        LibelleAnneeAcademique = txtLibelle.Text.Trim(),
                        ValueAnneeAcademique = (int)numValueAnnee.Value
                    };

                    dbContext.AnneeAcademiques.Add(nouvelleAnnee);
                    dbContext.SaveChanges();
                    MessageBox.Show("Année académique ajoutée avec succès!", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ChargerAnneeAcademiques();
                    ReinitialiserFormulaire();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur lors de l'ajout : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Événement déclenché lors du clic sur le bouton "Modifier"
        /// Modifie l'année académique sélectionnée dans la base de données
        /// </summary>
        private void btnModifier_Click(object sender, EventArgs e)
        {
            if (anneeAcademiqueSelectionnee == null)
            {
                MessageBox.Show("Veuillez sélectionner une année académique à modifier", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (ValiderFormulaire())
            {
                try
                {
                    anneeAcademiqueSelectionnee.LibelleAnneeAcademique = txtLibelle.Text.Trim();
                    anneeAcademiqueSelectionnee.ValueAnneeAcademique = (int)numValueAnnee.Value;

                    dbContext.SaveChanges();
                    MessageBox.Show("Année académique modifiée avec succès!", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ChargerAnneeAcademiques();
                    ReinitialiserFormulaire();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur lors de la modification : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Événement déclenché lors du clic sur le bouton "Supprimer"
        /// Supprime l'année académique sélectionnée de la base de données après confirmation
        /// </summary>
        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            if (anneeAcademiqueSelectionnee == null)
            {
                MessageBox.Show("Veuillez sélectionner une année académique à supprimer", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult result = MessageBox.Show(
                $"Êtes-vous sûr de vouloir supprimer l'année académique \"{anneeAcademiqueSelectionnee.LibelleAnneeAcademique}\" ?",
                "Confirmation",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    dbContext.AnneeAcademiques.Remove(anneeAcademiqueSelectionnee);
                    dbContext.SaveChanges();
                    MessageBox.Show("Année académique supprimée avec succès!", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ChargerAnneeAcademiques();
                    ReinitialiserFormulaire();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur lors de la suppression : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Événement déclenché lors du clic sur le bouton "Annuler"
        /// Réinitialise le formulaire
        /// </summary>
        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            ReinitialiserFormulaire();
        }

        /// <summary>
        /// Valide les données saisies dans le formulaire
        /// </summary>
        /// <returns>True si les données sont valides, False sinon</returns>
        private bool ValiderFormulaire()
        {
            if (string.IsNullOrWhiteSpace(txtLibelle.Text))
            {
                MessageBox.Show("Le libellé de l'année académique est obligatoire", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLibelle.Focus();
                return false;
            }

            if (numValueAnnee.Value < 2000 || numValueAnnee.Value > 2100)
            {
                MessageBox.Show("La valeur de l'année doit être entre 2000 et 2100", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                numValueAnnee.Focus();
                return false;
            }

            return true;
        }

        /// <summary>
        /// Réinitialise le formulaire en vidant tous les champs et en désélectionnant l'année académique
        /// </summary>
        private void ReinitialiserFormulaire()
        {
            txtLibelle.Clear();
            numValueAnnee.Value = DateTime.Now.Year;
            anneeAcademiqueSelectionnee = null;
            if (dgvAnneeAcademiques.Rows.Count > 0)
            {
                dgvAnneeAcademiques.ClearSelection();
            }
        }

        /// <summary>
        /// Événement déclenché lors de la fermeture du formulaire
        /// Libère les ressources de la base de données
        /// </summary>
        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            dbContext?.Dispose();
        }
    }
}
