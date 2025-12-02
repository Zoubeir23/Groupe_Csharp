using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Forminterface
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Textnom_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void Txtprenom_TextChanged(object sender, EventArgs e)
        {

        }

        private void Txtemail_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnajouter_Click(object sender, EventArgs e)
        {
            MessageBox.Show(string.Format("Bienvenue {0} {1}, votre email est {2} ", txtnom, txtprenom, txtemail));
        }
    }
}
