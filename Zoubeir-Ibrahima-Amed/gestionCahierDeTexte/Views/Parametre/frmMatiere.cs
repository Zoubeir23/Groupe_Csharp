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
    /// Formulaire de gestion des matières (CRUD complet)
    /// </summary>
    public partial class frmMatiere : Form
    {
        private BdCahierTexteContext dbContext;
        private Matiere matiereSelectionnee = null;

        /// <summary>
        /// Constructeur du formulaire
        /// </summary>
        public frmMatiere()
        {
            InitializeComponent();
            dbContext = new BdCahierTexteContext();
        }

        /// <summary>
        /// Événement déclenché au chargement du formulaire
        /// Applique le style moderne et charge les données
        /// </summary>
        private void frmMatiere_Load(object sender, EventArgs e)
        {
            // Appliquer le style moderne
            FormDesignHelper.ApplyModernStyle(this);
            FormDesignHelper.ApplyModernStyle(dgvMatieres);
            
            // Appliquer le style aux boutons
            FormDesignHelper.ApplyModernStyle(btnAjouter, ButtonStyle.Success);
            FormDesignHelper.ApplyModernStyle(btnModifier, ButtonStyle.Primary);
            FormDesignHelper.ApplyModernStyle(btnSupprimer, ButtonStyle.Danger);
            FormDesignHelper.ApplyModernStyle(btnAnnuler, ButtonStyle.Warning);
            
            ChargerMatieres();
            ReinitialiserFormulaire();
        }

        /// <summary>
        /// Charge toutes les matières depuis la base de données et les affiche dans la DataGridView
        /// </summary>
        private void ChargerMatieres()
        {
            try
            {
                var matieres = dbContext.Matieres.ToList();
                dgvMatieres.DataSource = matieres.Select(m => new
                {
                    m.IdMatiere,
                    m.LibelleMatiere,
                    m.VolumeHoraireMatiere,
                    m.Niveau
                }).ToList();

                dgvMatieres.Columns["IdMatiere"].Visible = false;
                dgvMatieres.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors du chargement des matières : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Événement déclenché lors du clic sur une cellule de la DataGridView
        /// Charge les données de la matière sélectionnée dans le formulaire
        /// </summary>
        private void dgvMatieres_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int idMatiere = (int)dgvMatieres.Rows[e.RowIndex].Cells["IdMatiere"].Value;
                matiereSelectionnee = dbContext.Matieres.FirstOrDefault(m => m.IdMatiere == idMatiere);
                if (matiereSelectionnee != null)
                {
                    txtLibelle.Text = matiereSelectionnee.LibelleMatiere;
                    numVolumeHoraire.Value = matiereSelectionnee.VolumeHoraireMatiere ?? 1; // Minimum est 1
                    txtNiveau.Text = matiereSelectionnee.Niveau ?? "";
                }
            }
        }

        /// <summary>
        /// Événement déclenché lors du clic sur le bouton "Ajouter"
        /// Ajoute une nouvelle matière dans la base de données
        /// </summary>
        private void btnAjouter_Click(object sender, EventArgs e)
        {
            if (ValiderFormulaire())
            {
                try
                {
                    Matiere nouvelleMatiere = new Matiere
                    {
                        LibelleMatiere = txtLibelle.Text.Trim(),
                        VolumeHoraireMatiere = (int)numVolumeHoraire.Value,
                        Niveau = txtNiveau.Text.Trim()
                    };

                    dbContext.Matieres.Add(nouvelleMatiere);
                    dbContext.SaveChanges();
                    MessageBox.Show("Matière ajoutée avec succès!", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ChargerMatieres();
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
        /// Modifie la matière sélectionnée dans la base de données
        /// </summary>
        private void btnModifier_Click(object sender, EventArgs e)
        {
            if (matiereSelectionnee == null)
            {
                MessageBox.Show("Veuillez sélectionner une matière à modifier", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (ValiderFormulaire())
            {
                try
                {
                    matiereSelectionnee.LibelleMatiere = txtLibelle.Text.Trim();
                    matiereSelectionnee.VolumeHoraireMatiere = (int)numVolumeHoraire.Value;
                    matiereSelectionnee.Niveau = txtNiveau.Text.Trim();

                    dbContext.SaveChanges();
                    MessageBox.Show("Matière modifiée avec succès!", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ChargerMatieres();
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
        /// Supprime la matière sélectionnée de la base de données après confirmation
        /// </summary>
        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            if (matiereSelectionnee == null)
            {
                MessageBox.Show("Veuillez sélectionner une matière à supprimer", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult result = MessageBox.Show(
                $"Êtes-vous sûr de vouloir supprimer la matière \"{matiereSelectionnee.LibelleMatiere}\" ?",
                "Confirmation",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    dbContext.Matieres.Remove(matiereSelectionnee);
                    dbContext.SaveChanges();
                    MessageBox.Show("Matière supprimée avec succès!", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ChargerMatieres();
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
                MessageBox.Show("Le libellé de la matière est obligatoire", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLibelle.Focus();
                return false;
            }

            if (numVolumeHoraire.Value <= 0)
            {
                MessageBox.Show("Le volume horaire doit être supérieur à 0", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                numVolumeHoraire.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtNiveau.Text))
            {
                MessageBox.Show("Le niveau est obligatoire", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNiveau.Focus();
                return false;
            }

            return true;
        }

        /// <summary>
        /// Réinitialise le formulaire en vidant tous les champs et en désélectionnant la matière
        /// </summary>
        private void ReinitialiserFormulaire()
        {
            txtLibelle.Clear();
            numVolumeHoraire.Value = 1; // Minimum est 1, donc on ne peut pas mettre 0
            txtNiveau.Clear();
            matiereSelectionnee = null;
            if (dgvMatieres.Rows.Count > 0)
            {
                dgvMatieres.ClearSelection();
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
