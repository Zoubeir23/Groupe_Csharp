namespace AppGestionCahierTexte.Views.Parametre
{
    partial class frmAnneeAcademique
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
            this.dgvAnneeAcademiques = new System.Windows.Forms.DataGridView();
            this.lblLibelle = new System.Windows.Forms.Label();
            this.txtLibelle = new System.Windows.Forms.TextBox();
            this.lblValueAnnee = new System.Windows.Forms.Label();
            this.numValueAnnee = new System.Windows.Forms.NumericUpDown();
            this.btnAjouter = new System.Windows.Forms.Button();
            this.btnModifier = new System.Windows.Forms.Button();
            this.btnSupprimer = new System.Windows.Forms.Button();
            this.btnAnnuler = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAnneeAcademiques)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numValueAnnee)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvAnneeAcademiques
            // 
            this.dgvAnneeAcademiques.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAnneeAcademiques.Location = new System.Drawing.Point(500, 84);
            this.dgvAnneeAcademiques.Name = "dgvAnneeAcademiques";
            this.dgvAnneeAcademiques.RowHeadersWidth = 82;
            this.dgvAnneeAcademiques.RowTemplate.Height = 33;
            this.dgvAnneeAcademiques.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAnneeAcademiques.Size = new System.Drawing.Size(700, 650);
            this.dgvAnneeAcademiques.TabIndex = 0;
            this.dgvAnneeAcademiques.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAnneeAcademiques_CellClick);
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
            // lblValueAnnee
            // 
            this.lblValueAnnee.AutoSize = true;
            this.lblValueAnnee.Location = new System.Drawing.Point(60, 190);
            this.lblValueAnnee.Name = "lblValueAnnee";
            this.lblValueAnnee.Size = new System.Drawing.Size(61, 25);
            this.lblValueAnnee.TabIndex = 3;
            this.lblValueAnnee.Text = "Année";
            // 
            // numValueAnnee
            // 
            this.numValueAnnee.Location = new System.Drawing.Point(60, 230);
            this.numValueAnnee.Maximum = new decimal(new int[] {
            2100,
            0,
            0,
            0});
            this.numValueAnnee.Minimum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.numValueAnnee.Name = "numValueAnnee";
            this.numValueAnnee.Size = new System.Drawing.Size(380, 31);
            this.numValueAnnee.TabIndex = 4;
            this.numValueAnnee.Value = new decimal(new int[] {
            2025,
            0,
            0,
            0});
            // 
            // btnAjouter
            // 
            this.btnAjouter.Location = new System.Drawing.Point(60, 310);
            this.btnAjouter.Name = "btnAjouter";
            this.btnAjouter.Size = new System.Drawing.Size(140, 45);
            this.btnAjouter.TabIndex = 5;
            this.btnAjouter.Text = "Ajouter";
            this.btnAjouter.UseVisualStyleBackColor = true;
            this.btnAjouter.Click += new System.EventHandler(this.btnAjouter_Click);
            // 
            // btnModifier
            // 
            this.btnModifier.Location = new System.Drawing.Point(220, 310);
            this.btnModifier.Name = "btnModifier";
            this.btnModifier.Size = new System.Drawing.Size(140, 45);
            this.btnModifier.TabIndex = 6;
            this.btnModifier.Text = "Modifier";
            this.btnModifier.UseVisualStyleBackColor = true;
            this.btnModifier.Click += new System.EventHandler(this.btnModifier_Click);
            // 
            // btnSupprimer
            // 
            this.btnSupprimer.Location = new System.Drawing.Point(60, 370);
            this.btnSupprimer.Name = "btnSupprimer";
            this.btnSupprimer.Size = new System.Drawing.Size(140, 45);
            this.btnSupprimer.TabIndex = 7;
            this.btnSupprimer.Text = "Supprimer";
            this.btnSupprimer.UseVisualStyleBackColor = true;
            this.btnSupprimer.Click += new System.EventHandler(this.btnSupprimer_Click);
            // 
            // btnAnnuler
            // 
            this.btnAnnuler.Location = new System.Drawing.Point(220, 370);
            this.btnAnnuler.Name = "btnAnnuler";
            this.btnAnnuler.Size = new System.Drawing.Size(140, 45);
            this.btnAnnuler.TabIndex = 8;
            this.btnAnnuler.Text = "Annuler";
            this.btnAnnuler.UseVisualStyleBackColor = true;
            this.btnAnnuler.Click += new System.EventHandler(this.btnAnnuler_Click);
            // 
            // frmAnneeAcademique
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1220, 800);
            this.ControlBox = false;
            this.Controls.Add(this.btnAnnuler);
            this.Controls.Add(this.btnSupprimer);
            this.Controls.Add(this.btnModifier);
            this.Controls.Add(this.btnAjouter);
            this.Controls.Add(this.numValueAnnee);
            this.Controls.Add(this.lblValueAnnee);
            this.Controls.Add(this.txtLibelle);
            this.Controls.Add(this.lblLibelle);
            this.Controls.Add(this.dgvAnneeAcademiques);
            this.Name = "frmAnneeAcademique";
            this.Text = "Année Académique";
            this.Load += new System.EventHandler(this.frmAnneeAcademique_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAnneeAcademiques)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numValueAnnee)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvAnneeAcademiques;
        private System.Windows.Forms.Label lblLibelle;
        private System.Windows.Forms.TextBox txtLibelle;
        private System.Windows.Forms.Label lblValueAnnee;
        private System.Windows.Forms.NumericUpDown numValueAnnee;
        private System.Windows.Forms.Button btnAjouter;
        private System.Windows.Forms.Button btnModifier;
        private System.Windows.Forms.Button btnSupprimer;
        private System.Windows.Forms.Button btnAnnuler;
    }
}
