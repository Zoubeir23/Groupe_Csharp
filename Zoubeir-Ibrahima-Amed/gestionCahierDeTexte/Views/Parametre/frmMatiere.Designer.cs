namespace AppGestionCahierTexte.Views.Parametre
{
    partial class frmMatiere
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvMatieres = new System.Windows.Forms.DataGridView();
            this.lblLibelle = new System.Windows.Forms.Label();
            this.txtLibelle = new System.Windows.Forms.TextBox();
            this.lblVolumeHoraire = new System.Windows.Forms.Label();
            this.numVolumeHoraire = new System.Windows.Forms.NumericUpDown();
            this.lblNiveau = new System.Windows.Forms.Label();
            this.txtNiveau = new System.Windows.Forms.TextBox();
            this.btnAjouter = new System.Windows.Forms.Button();
            this.btnModifier = new System.Windows.Forms.Button();
            this.btnSupprimer = new System.Windows.Forms.Button();
            this.btnAnnuler = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMatieres)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numVolumeHoraire)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvMatieres
            // 
            this.dgvMatieres.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMatieres.Location = new System.Drawing.Point(500, 84);
            this.dgvMatieres.Name = "dgvMatieres";
            this.dgvMatieres.RowHeadersWidth = 82;
            this.dgvMatieres.RowTemplate.Height = 33;
            this.dgvMatieres.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMatieres.Size = new System.Drawing.Size(700, 650);
            this.dgvMatieres.TabIndex = 0;
            this.dgvMatieres.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMatieres_CellClick);
            // 
            // lblLibelle
            // 
            this.lblLibelle.AutoSize = true;
            this.lblLibelle.Location = new System.Drawing.Point(60, 84);
            this.lblLibelle.Name = "lblLibelle";
            this.lblLibelle.Size = new System.Drawing.Size(71, 25);
            this.lblLibelle.TabIndex = 1;
            this.lblLibelle.Text = "Libellé";
            // 
            // txtLibelle
            // 
            this.txtLibelle.Location = new System.Drawing.Point(60, 130);
            this.txtLibelle.Multiline = true;
            this.txtLibelle.Name = "txtLibelle";
            this.txtLibelle.Size = new System.Drawing.Size(380, 40);
            this.txtLibelle.TabIndex = 2;
            // 
            // lblVolumeHoraire
            // 
            this.lblVolumeHoraire.AutoSize = true;
            this.lblVolumeHoraire.Location = new System.Drawing.Point(60, 190);
            this.lblVolumeHoraire.Name = "lblVolumeHoraire";
            this.lblVolumeHoraire.Size = new System.Drawing.Size(155, 25);
            this.lblVolumeHoraire.TabIndex = 3;
            this.lblVolumeHoraire.Text = "Volume horaire";
            // 
            // numVolumeHoraire
            // 
            this.numVolumeHoraire.Location = new System.Drawing.Point(60, 230);
            this.numVolumeHoraire.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numVolumeHoraire.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numVolumeHoraire.Name = "numVolumeHoraire";
            this.numVolumeHoraire.Size = new System.Drawing.Size(380, 31);
            this.numVolumeHoraire.TabIndex = 4;
            this.numVolumeHoraire.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblNiveau
            // 
            this.lblNiveau.AutoSize = true;
            this.lblNiveau.Location = new System.Drawing.Point(60, 290);
            this.lblNiveau.Name = "lblNiveau";
            this.lblNiveau.Size = new System.Drawing.Size(71, 25);
            this.lblNiveau.TabIndex = 5;
            this.lblNiveau.Text = "Niveau";
            // 
            // txtNiveau
            // 
            this.txtNiveau.Location = new System.Drawing.Point(60, 330);
            this.txtNiveau.Multiline = true;
            this.txtNiveau.Name = "txtNiveau";
            this.txtNiveau.Size = new System.Drawing.Size(380, 40);
            this.txtNiveau.TabIndex = 6;
            // 
            // btnAjouter
            // 
            this.btnAjouter.Location = new System.Drawing.Point(60, 410);
            this.btnAjouter.Name = "btnAjouter";
            this.btnAjouter.Size = new System.Drawing.Size(140, 45);
            this.btnAjouter.TabIndex = 7;
            this.btnAjouter.Text = "Ajouter";
            this.btnAjouter.UseVisualStyleBackColor = true;
            this.btnAjouter.Click += new System.EventHandler(this.btnAjouter_Click);
            // 
            // btnModifier
            // 
            this.btnModifier.Location = new System.Drawing.Point(220, 410);
            this.btnModifier.Name = "btnModifier";
            this.btnModifier.Size = new System.Drawing.Size(140, 45);
            this.btnModifier.TabIndex = 8;
            this.btnModifier.Text = "Modifier";
            this.btnModifier.UseVisualStyleBackColor = true;
            this.btnModifier.Click += new System.EventHandler(this.btnModifier_Click);
            // 
            // btnSupprimer
            // 
            this.btnSupprimer.Location = new System.Drawing.Point(60, 470);
            this.btnSupprimer.Name = "btnSupprimer";
            this.btnSupprimer.Size = new System.Drawing.Size(140, 45);
            this.btnSupprimer.TabIndex = 9;
            this.btnSupprimer.Text = "Supprimer";
            this.btnSupprimer.UseVisualStyleBackColor = true;
            this.btnSupprimer.Click += new System.EventHandler(this.btnSupprimer_Click);
            // 
            // btnAnnuler
            // 
            this.btnAnnuler.Location = new System.Drawing.Point(220, 470);
            this.btnAnnuler.Name = "btnAnnuler";
            this.btnAnnuler.Size = new System.Drawing.Size(140, 45);
            this.btnAnnuler.TabIndex = 10;
            this.btnAnnuler.Text = "Annuler";
            this.btnAnnuler.UseVisualStyleBackColor = true;
            this.btnAnnuler.Click += new System.EventHandler(this.btnAnnuler_Click);
            // 
            // frmMatiere
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1220, 800);
            this.ControlBox = false;
            this.Controls.Add(this.btnAnnuler);
            this.Controls.Add(this.btnSupprimer);
            this.Controls.Add(this.btnModifier);
            this.Controls.Add(this.btnAjouter);
            this.Controls.Add(this.txtNiveau);
            this.Controls.Add(this.lblNiveau);
            this.Controls.Add(this.numVolumeHoraire);
            this.Controls.Add(this.lblVolumeHoraire);
            this.Controls.Add(this.txtLibelle);
            this.Controls.Add(this.lblLibelle);
            this.Controls.Add(this.dgvMatieres);
            this.Name = "frmMatiere";
            this.Text = "Matière";
            this.Load += new System.EventHandler(this.frmMatiere_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMatieres)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numVolumeHoraire)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvMatieres;
        private System.Windows.Forms.Label lblLibelle;
        private System.Windows.Forms.TextBox txtLibelle;
        private System.Windows.Forms.Label lblVolumeHoraire;
        private System.Windows.Forms.NumericUpDown numVolumeHoraire;
        private System.Windows.Forms.Label lblNiveau;
        private System.Windows.Forms.TextBox txtNiveau;
        private System.Windows.Forms.Button btnAjouter;
        private System.Windows.Forms.Button btnModifier;
        private System.Windows.Forms.Button btnSupprimer;
        private System.Windows.Forms.Button btnAnnuler;
    }
}
