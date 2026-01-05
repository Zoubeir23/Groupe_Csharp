using System;
using System.Drawing;
using System.Windows.Forms;

namespace AppGestionCahierTexte.Views.Parametre
{
    /// <summary>
    /// Classe helper pour appliquer un style moderne aux formulaires
    /// </summary>
    public static class FormDesignHelper
    {
        // Couleurs modernes
        public static readonly Color ColorBackground = Color.FromArgb(245, 245, 250);
        public static readonly Color ColorGroupBox = Color.White;
        public static readonly Color ColorLabel = Color.FromArgb(51, 51, 51);
        public static readonly Color ColorButtonPrimary = Color.FromArgb(0, 120, 215);
        public static readonly Color ColorButtonSuccess = Color.FromArgb(16, 124, 16);
        public static readonly Color ColorButtonDanger = Color.FromArgb(196, 43, 28);
        public static readonly Color ColorButtonWarning = Color.FromArgb(217, 119, 6);

        /// <summary>
        /// Applique un style moderne à un formulaire
        /// </summary>
        public static void ApplyModernStyle(Form form)
        {
            form.BackColor = ColorBackground;
            form.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
        }

        /// <summary>
        /// Applique un style moderne à un GroupBox
        /// </summary>
        public static void ApplyModernStyle(GroupBox groupBox)
        {
            groupBox.BackColor = ColorGroupBox;
            groupBox.ForeColor = ColorLabel;
            groupBox.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            groupBox.Padding = new Padding(10);
        }

        /// <summary>
        /// Applique un style moderne à un Label
        /// </summary>
        public static void ApplyModernStyle(Label label)
        {
            label.ForeColor = ColorLabel;
            label.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
        }

        /// <summary>
        /// Applique un style moderne à un TextBox
        /// </summary>
        public static void ApplyModernStyle(TextBox textBox)
        {
            textBox.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            textBox.BackColor = Color.White;
            textBox.BorderStyle = BorderStyle.FixedSingle;
        }

        /// <summary>
        /// Applique un style moderne à un bouton (Primary)
        /// </summary>
        public static void ApplyModernStyle(Button button, ButtonStyle style = ButtonStyle.Primary)
        {
            button.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold, GraphicsUnit.Point);
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
            button.Cursor = Cursors.Hand;
            button.Size = new Size(120, 40);

            switch (style)
            {
                case ButtonStyle.Primary:
                    button.BackColor = ColorButtonPrimary;
                    button.ForeColor = Color.White;
                    break;
                case ButtonStyle.Success:
                    button.BackColor = ColorButtonSuccess;
                    button.ForeColor = Color.White;
                    break;
                case ButtonStyle.Danger:
                    button.BackColor = ColorButtonDanger;
                    button.ForeColor = Color.White;
                    break;
                case ButtonStyle.Warning:
                    button.BackColor = ColorButtonWarning;
                    button.ForeColor = Color.White;
                    break;
            }
        }

        /// <summary>
        /// Applique un style moderne à une DataGridView
        /// </summary>
        public static void ApplyModernStyle(DataGridView dgv)
        {
            dgv.BackgroundColor = ColorGroupBox;
            dgv.BorderStyle = BorderStyle.None;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(51, 51, 51);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            dgv.EnableHeadersVisualStyles = false;
            dgv.DefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 248, 248);
            dgv.RowHeadersVisible = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.MultiSelect = false;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
    }

    public enum ButtonStyle
    {
        Primary,
        Success,
        Danger,
        Warning
    }
}

