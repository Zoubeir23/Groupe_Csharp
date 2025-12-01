namespace WindowsFormsApp
{
    partial class Bienvenue
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblNom = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblPrenom = new System.Windows.Forms.Label();
            this.btnQuitter = new System.Windows.Forms.Button();
            this.btnEnregistrer = new System.Windows.Forms.Button();
            this.txtNom = new System.Windows.Forms.TextBox();
            this.txtPrenom = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // lblNom
            // 
            this.lblNom.AutoSize = true;
            this.lblNom.Location = new System.Drawing.Point(78, 62);
            this.lblNom.Name = "lblNom";
            this.lblNom.Size = new System.Drawing.Size(56, 25);
            this.lblNom.TabIndex = 0;
            this.lblNom.Text = "Nom";
            this.lblNom.Click += new System.EventHandler(this.label1_Click);
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(78, 354);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(65, 25);
            this.lblEmail.TabIndex = 1;
            this.lblEmail.Text = "Email";
            this.lblEmail.Click += new System.EventHandler(this.label2_Click);
            // 
            // lblPrenom
            // 
            this.lblPrenom.AutoSize = true;
            this.lblPrenom.Location = new System.Drawing.Point(78, 208);
            this.lblPrenom.Name = "lblPrenom";
            this.lblPrenom.Size = new System.Drawing.Size(86, 25);
            this.lblPrenom.TabIndex = 2;
            this.lblPrenom.Text = "Prenom";
            this.lblPrenom.Click += new System.EventHandler(this.label3_Click);
            // 
            // btnQuitter
            // 
            this.btnQuitter.Location = new System.Drawing.Point(340, 566);
            this.btnQuitter.Name = "btnQuitter";
            this.btnQuitter.Size = new System.Drawing.Size(190, 68);
            this.btnQuitter.TabIndex = 6;
            this.btnQuitter.Text = "Quitter";
            this.btnQuitter.UseVisualStyleBackColor = true;
            this.btnQuitter.Click += new System.EventHandler(this.btnQuitter_Click);
            // 
            // btnEnregistrer
            // 
            this.btnEnregistrer.Location = new System.Drawing.Point(612, 566);
            this.btnEnregistrer.Name = "btnEnregistrer";
            this.btnEnregistrer.Size = new System.Drawing.Size(190, 68);
            this.btnEnregistrer.TabIndex = 7;
            this.btnEnregistrer.Text = "Enregistrer";
            this.btnEnregistrer.UseVisualStyleBackColor = true;
            this.btnEnregistrer.Click += new System.EventHandler(this.btnEnregistrer_Click);
            // 
            // txtNom
            // 
            this.txtNom.Location = new System.Drawing.Point(83, 146);
            this.txtNom.Name = "txtNom";
            this.txtNom.Size = new System.Drawing.Size(421, 31);
            this.txtNom.TabIndex = 3;
            this.txtNom.TextChanged += new System.EventHandler(this.txtNom_TextChanged);
            // 
            // txtPrenom
            // 
            this.txtPrenom.Location = new System.Drawing.Point(83, 275);
            this.txtPrenom.Name = "txtPrenom";
            this.txtPrenom.Size = new System.Drawing.Size(421, 31);
            this.txtPrenom.TabIndex = 5;
            this.txtPrenom.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(83, 404);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(421, 31);
            this.txtEmail.TabIndex = 4;
            // 
            // Bienvenue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(869, 673);
            this.ControlBox = false;
            this.Controls.Add(this.btnEnregistrer);
            this.Controls.Add(this.btnQuitter);
            this.Controls.Add(this.txtPrenom);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtNom);
            this.Controls.Add(this.lblPrenom);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.lblNom);
            this.Name = "Bienvenue";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.TextChanged += new System.EventHandler(this.frmWelcome);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNom;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblPrenom;
        private System.Windows.Forms.Button btnQuitter;
        private System.Windows.Forms.Button btnEnregistrer;
        private System.Windows.Forms.TextBox txtNom;
        private System.Windows.Forms.TextBox txtPrenom;
        private System.Windows.Forms.TextBox txtEmail;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}

