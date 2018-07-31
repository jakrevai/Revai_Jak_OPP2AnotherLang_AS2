using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//Author Block
//Author: Jak Revai
//Project: Revai_Jak_OP2AnotherLang_AS2_RESUBMIT
//Description: C# Maintain Student Scores
//Version: 1.0

namespace Revai_Jak_OPP2AnotherLang_AS2
{
    public partial class frmUpdate_AddScore : Form
    {
        public frmUpdate_AddScore()
        {
            InitializeComponent();
            //this.ShowDialog(); //Whenever this constructor is called, it initiates the form as a dialog box
        }

        int score;

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (isValid())
            {
                score = Convert.ToInt32(txtScore.Text);
                this.Tag = score;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public bool isValid() //Checks that the input is valid
        {
            return  IsInt(txtScore) &&
                    IsWithinRange(txtScore, 0, 100);
        }

        public static bool IsWithinRange(TextBox textBox, int min, int max)
        {
            int number = Convert.ToInt32(textBox.Text); //Converts the input

            if (number < min || number > max)
            {
                MessageBox.Show(textBox.Tag + " must be between " + min
                    + " and " + max + ".", "Error");
                textBox.Focus();
                return false;
            }
            return true;
        }

        public static bool IsInt(TextBox textBox)
        {
            int number = 0;
            if (Int32.TryParse(textBox.Text, out number))
            {
                return true;
            }
            else
            {
                MessageBox.Show(textBox.Tag + " must be an integer.", "Error");
                textBox.Focus();
                return false;
            }
        }
    }
}
