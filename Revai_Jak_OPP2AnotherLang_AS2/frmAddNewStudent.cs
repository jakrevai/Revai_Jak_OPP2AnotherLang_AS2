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
    public partial class frmAddNewStudent : Form
    {
        public frmAddNewStudent()
        {
            InitializeComponent();
        }

        private Student student;
        string strScores;
        
        public List<int> scores = new List<int>();
        

        public Student GetStudent()
        {
            this.ShowDialog();
            return student;
        }

        private void btnAddScore_Click(object sender, EventArgs e)
        {
            if (isValid())
            {
                txtScores.Clear(); //Clears the textbox

                int score = Convert.ToInt32(txtScore.Text);
                scores.Add(score); //Add the score to the list         
            }

            strScores = "";

            foreach (int val in scores)
            {
                txtScores.Text += val.ToString() + " "; //Add each score in the list to the textbox
                strScores += val.ToString() + "|";
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            scores.Clear(); //Clears the textboxes
            txtScores.Clear();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            string firstName = "";
            string lastName = "";

            if (txtName.Text.Equals("")) //If nothing is in the field display a messagebox
            {
                MessageBox.Show("Name is a required field.", "Name Required");
            }
            else if (!txtName.Text.Contains(' ')) //If the name textbox doesnt contain a space, then no last name can be input, displays a textbox telling the user to enter a lastname
            {
                MessageBox.Show("Please enter a last name", "Last Name Required");
            }
            else
            {
                firstName = name.Substring(0, name.IndexOf(' ')); //Creates a substring of the first name before the space
                lastName = name.Substring(name.IndexOf(' ') + 1); //Creates a substring of the last name after the space

                if (scores.Count <= 0)
                {
                    MessageBox.Show("Please enter at least one score", "Score Required");
                }
                else
                {
                    //strScores.Trim();                
                    student = new Student(firstName, lastName, strScores);
                    this.Close();
                }
                
                //if (scores.Count <= 0)
                //{
                //    scores.Add(0); //Add a score to the list
                //    scores.Add(0);
                //    scores.Add(0);
                //    student = new Student(firstName, lastName, scores[0], scores[1], scores[2]); //Creates a new student object - Jak
                //    this.Close();
                //}
                //else if (scores.ElementAtOrDefault(1) != null) //If a second score doesnt exist
                //{
                //    scores.Add(0);
                //    scores.Add(0);
                //    student = new Student(firstName, lastName, scores[0], scores[1], scores[2]); //Creates a new student object - Jak
                //    this.Close();
                //}
                //else if (scores.ElementAtOrDefault(2) != null) //If a third score doesnt exist
                //{
                //    scores.Add(0);
                //    student = new Student(firstName, lastName, scores[0], scores[1], scores[2]); //Creates a new student object - Jak
                //    this.Close();
                //}
                //else if (scores.ElementAtOrDefault(1) != null && scores.ElementAtOrDefault(2) != null) //If both scores dont exist
                //{
                //    scores.Add(0);
                //    scores.Add(0);
                //    student = new Student(firstName, lastName, scores[0], scores[1], scores[2]); //Creates a new student object - Jak
                //    this.Close();
                //}
                //else //When all scores exist
                //{
                //    student = new Student(firstName, lastName, scores[0], scores[1], scores[2]); //Creates a new student object - Jak
                //    this.Close();
                //} 
            }            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Methods for validation
        public bool isValid() //Checks that the input is valid
        {
            return IsInt(txtScore) &&
                    IsWithinRange(txtScore, 0, 100);
        }

        public static bool IsWithinRange(TextBox textBox, int min, int max) //Checks that the input number is within a range of 0-100
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

        public static bool IsInt(TextBox textBox) //Checks that the number input is an integer
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

        public List<int> getScores //Method to set the name string - Jak
        {
            get { return scores; }
        }

    }
}
