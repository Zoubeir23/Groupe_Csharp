using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    public partial class Bienvenue : Form
    {
        public Bienvenue()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void frmWelcome(object sender, EventArgs e)
        {

        }

        private void btnQuitter_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtNom_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnEnregistrer_Click(object sender, EventArgs e)
        {
            MessageBox.Show(String.Format("Bienvenue {0} {1} Votre email est : {2}", txtNom.Text, txtPrenom.Text, txtEmail.Text));

            // Reset des champs
            txtNom.Text = string.Empty;
            txtPrenom.Text = string.Empty;
            txtEmail.Text = string.Empty;

            // Remet le focus sur le premier champ
            txtNom.Focus();

        }
    }
}
