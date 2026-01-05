namespace AppGestionCahierTexte.Views.Parametre
{
    partial class frmClasse
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
            this.dgvClasses = new System.Windows.Forms.DataGridView();
            this.lblLibelleClasse = new System.Windows.Forms.Label();
            this.txtLibelleClasse = new System.Windows.Forms.TextBox();
            this.lblAnneeAcademique = new System.Windows.Forms.Label();
            this.cmbAnneeAcademique = new System.Windows.Forms.ComboBox();
            this.btnAjouter = new System.Windows.Forms.Button();
            this.btnModifier = new System.Windows.Forms.Button();
            this.btnSupprimer = new System.Windows.Forms.Button();
            this.btnAnnuler = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClasses)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvClasses
            // 
            this.dgvClasses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvClasses.Location = new System.Drawing.Point(500, 84);
            this.dgvClasses.Name = "dgvClasses";
            this.dgvClasses.RowHeadersWidth = 82;
            this.dgvClasses.RowTemplate.Height = 33;
            this.dgvClasses.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvClasses.Size = new System.Drawing.Size(700, 650);
            this.dgvClasses.TabIndex = 0;
            this.dgvClasses.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvClasses_CellClick);
            // 
            // lblLibelleClasse
            // 
            this.lblLibelleClasse.AutoSize = true;
            this.lblLibelleClasse.Location = new System.Drawing.Point(60, 84);
            this.lblLibelleClasse.Name = "lblLibelleClasse";
            this.lblLibelleClasse.Size = new System.Drawing.Size(130, 25);
            this.lblLibelleClasse.TabIndex = 1;
            this.lblLibelleClasse.Text = "Libellé classe";
            // 
            // txtLibelleClasse
            // 
            this.txtLibelleClasse.Location = new System.Drawing.Point(60, 130);
            this.txtLibelleClasse.Multiline = true;
            this.txtLibelleClasse.Name = "txtLibelleClasse";
            this.txtLibelleClasse.Size = new System.Drawing.Size(380, 40);
            this.txtLibelleClasse.TabIndex = 2;
            // 
            // lblAnneeAcademique
            // 
            this.lblAnneeAcademique.AutoSize = true;
            this.lblAnneeAcademique.Location = new System.Drawing.Point(60, 190);
            this.lblAnneeAcademique.Name = "lblAnneeAcademique";
            this.lblAnneeAcademique.Size = new System.Drawing.Size(179, 25);
            this.lblAnneeAcademique.TabIndex = 3;
            this.lblAnneeAcademique.Text = "Année académique";
            // 
            // cmbAnneeAcademique
            // 
            this.cmbAnneeAcademique.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAnneeAcademique.FormattingEnabled = true;
            this.cmbAnneeAcademique.Location = new System.Drawing.Point(60, 230);
            this.cmbAnneeAcademique.Name = "cmbAnneeAcademique";
            this.cmbAnneeAcademique.Size = new System.Drawing.Size(380, 33);
            this.cmbAnneeAcademique.TabIndex = 4;
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
            // frmClasse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1220, 800);
            this.ControlBox = false;
            this.Controls.Add(this.btnAnnuler);
            this.Controls.Add(this.btnSupprimer);
            this.Controls.Add(this.btnModifier);
            this.Controls.Add(this.btnAjouter);
            this.Controls.Add(this.cmbAnneeAcademique);
            this.Controls.Add(this.lblAnneeAcademique);
            this.Controls.Add(this.txtLibelleClasse);
            this.Controls.Add(this.lblLibelleClasse);
            this.Controls.Add(this.dgvClasses);
            this.Name = "frmClasse";
            this.Text = "Classe";
            this.Load += new System.EventHandler(this.frmClasse_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvClasses)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvClasses;
        private System.Windows.Forms.Label lblLibelleClasse;
        private System.Windows.Forms.TextBox txtLibelleClasse;
        private System.Windows.Forms.Label lblAnneeAcademique;
        private System.Windows.Forms.ComboBox cmbAnneeAcademique;
        private System.Windows.Forms.Button btnAjouter;
        private System.Windows.Forms.Button btnModifier;
        private System.Windows.Forms.Button btnSupprimer;
        private System.Windows.Forms.Button btnAnnuler;
    }
}
