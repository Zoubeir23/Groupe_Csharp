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
    /// Formulaire de gestion des classes (CRUD complet)
    /// </summary>
    public partial class frmClasse : Form
    {
        private BdCahierTexteContext dbContext;
        private Classe classeSelectionnee = null;

        /// <summary>
        /// Constructeur du formulaire
        /// </summary>
        public frmClasse()
        {
            InitializeComponent();
            dbContext = new BdCahierTexteContext();
        }

        /// <summary>
        /// Événement déclenché au chargement du formulaire
        /// Applique le style moderne et charge les données
        /// </summary>
        private void frmClasse_Load(object sender, EventArgs e)
        {
            // Appliquer le style moderne
            FormDesignHelper.ApplyModernStyle(this);
            FormDesignHelper.ApplyModernStyle(dgvClasses);
            
            // Appliquer le style aux boutons
            FormDesignHelper.ApplyModernStyle(btnAjouter, ButtonStyle.Success);
            FormDesignHelper.ApplyModernStyle(btnModifier, ButtonStyle.Primary);
            FormDesignHelper.ApplyModernStyle(btnSupprimer, ButtonStyle.Danger);
            FormDesignHelper.ApplyModernStyle(btnAnnuler, ButtonStyle.Warning);
            
            ChargerAnneeAcademiques();
            ChargerClasses();
            ReinitialiserFormulaire();
        }

        /// <summary>
        /// Charge toutes les années académiques dans le ComboBox
        /// </summary>
        private void ChargerAnneeAcademiques()
        {
            try
            {
                var annees = dbContext.AnneeAcademiques.ToList();
                cmbAnneeAcademique.DataSource = annees;
                cmbAnneeAcademique.DisplayMember = "LibelleAnneeAcademique";
                cmbAnneeAcademique.ValueMember = "IdAnneeAcademique";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors du chargement des années académiques : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Charge toutes les classes depuis la base de données et les affiche dans la DataGridView
        /// </summary>
        private void ChargerClasses()
        {
            try
            {
                var classes = dbContext.Classes.Include(c => c.AnneeAcademique).ToList();
                dgvClasses.DataSource = classes.Select(c => new
                {
                    c.IdClasse,
                    c.LibelleClasse,
                    AnneeAcademique = c.AnneeAcademique != null ? c.AnneeAcademique.LibelleAnneeAcademique : ""
                }).ToList();

                dgvClasses.Columns["IdClasse"].Visible = false;
                dgvClasses.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors du chargement des classes : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Événement déclenché lors du clic sur une cellule de la DataGridView
        /// Charge les données de la classe sélectionnée dans le formulaire
        /// </summary>
        private void dgvClasses_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int idClasse = (int)dgvClasses.Rows[e.RowIndex].Cells["IdClasse"].Value;
                classeSelectionnee = dbContext.Classes.Include(c => c.AnneeAcademique).FirstOrDefault(c => c.IdClasse == idClasse);
                if (classeSelectionnee != null)
                {
                    txtLibelleClasse.Text = classeSelectionnee.LibelleClasse;
                    cmbAnneeAcademique.SelectedValue = classeSelectionnee.IdAnneeAcademique;
                }
            }
        }

        /// <summary>
        /// Événement déclenché lors du clic sur le bouton "Ajouter"
        /// Ajoute une nouvelle classe dans la base de données
        /// </summary>
        private void btnAjouter_Click(object sender, EventArgs e)
        {
            if (ValiderFormulaire())
            {
                try
                {
                    Classe nouvelleClasse = new Classe
                    {
                        LibelleClasse = txtLibelleClasse.Text.Trim(),
                        IdAnneeAcademique = (int)cmbAnneeAcademique.SelectedValue
                    };

                    dbContext.Classes.Add(nouvelleClasse);
                    dbContext.SaveChanges();
                    MessageBox.Show("Classe ajoutée avec succès!", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ChargerClasses();
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
        /// Modifie la classe sélectionnée dans la base de données
        /// </summary>
        private void btnModifier_Click(object sender, EventArgs e)
        {
            if (classeSelectionnee == null)
            {
                MessageBox.Show("Veuillez sélectionner une classe à modifier", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (ValiderFormulaire())
            {
                try
                {
                    classeSelectionnee.LibelleClasse = txtLibelleClasse.Text.Trim();
                    classeSelectionnee.IdAnneeAcademique = (int)cmbAnneeAcademique.SelectedValue;

                    dbContext.SaveChanges();
                    MessageBox.Show("Classe modifiée avec succès!", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ChargerClasses();
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
        /// Supprime la classe sélectionnée de la base de données après confirmation
        /// </summary>
        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            if (classeSelectionnee == null)
            {
                MessageBox.Show("Veuillez sélectionner une classe à supprimer", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult result = MessageBox.Show(
                $"Êtes-vous sûr de vouloir supprimer la classe \"{classeSelectionnee.LibelleClasse}\" ?",
                "Confirmation",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    dbContext.Classes.Remove(classeSelectionnee);
                    dbContext.SaveChanges();
                    MessageBox.Show("Classe supprimée avec succès!", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ChargerClasses();
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
            if (string.IsNullOrWhiteSpace(txtLibelleClasse.Text))
            {
                MessageBox.Show("Le libellé de la classe est obligatoire", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLibelleClasse.Focus();
                return false;
            }

            if (cmbAnneeAcademique.SelectedValue == null)
            {
                MessageBox.Show("Veuillez sélectionner une année académique", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbAnneeAcademique.Focus();
                return false;
            }

            return true;
        }

        /// <summary>
        /// Réinitialise le formulaire en vidant tous les champs et en désélectionnant la classe
        /// </summary>
        private void ReinitialiserFormulaire()
        {
            txtLibelleClasse.Clear();
            if (cmbAnneeAcademique.Items.Count > 0)
            {
                cmbAnneeAcademique.SelectedIndex = 0;
            }
            classeSelectionnee = null;
            if (dgvClasses.Rows.Count > 0)
            {
                dgvClasses.ClearSelection();
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
