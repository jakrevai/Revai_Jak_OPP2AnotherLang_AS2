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
    public partial class frmUpdateStudentScores : Form
    {
        public frmUpdateStudentScores()
        {
            InitializeComponent();
        }

        frmStudentScores studentScore = new frmStudentScores();
        //frmAddNewStudent addStudent = new frmAddNewStudent();

        string name; //Name is the first and last name joined
        string strScore; //Score coming from the students index
        string newScore; //Score going to the students form
        int score; //Students score converted to a integer
        string firstName;
        string lastName;

        //List<int> AddStudentScoresList = new List<int>();
        List<int> scores = new List<int>(); //List to hold all the student scores

        private Student student; //Creates a class variable from the Student class - Jak
        private StudentsList students = new StudentsList(); //Calls the StudentsList class
      
        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmUpdate_AddScore addScore = new frmUpdate_AddScore(); //Creates the object / dialog box
            DialogResult dialogResult = addScore.ShowDialog();

            if (addScore != null && dialogResult == DialogResult.OK)
            {
                lstScores.Items.Add(addScore.Tag);
            }            
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int i = lstScores.SelectedIndex; //Index of SELECTED item

            if (i == -1)
            {
                MessageBox.Show("Please select a score to update.", "Error");
            }
            
            if (i != -1)
            {
                frmUpdate_UpdateScore update = new frmUpdate_UpdateScore();
                score = Convert.ToInt32(lstScores.Items[i]);
                update.setScore = score; //Sets the score in the frmUpdate_updateScore.cs file to the score in the list
                
                DialogResult dialogResult = update.ShowDialog(); //Displays the form
               
                int tag = Convert.ToInt32(update.Tag);

                if (dialogResult == DialogResult.OK)
                {
                    lstScores.Items.RemoveAt(i);
                    lstScores.Items.Insert(i, tag);
                }
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            int i = lstScores.SelectedIndex; //Index of SELECTED item

            if (i == -1)
            {
                MessageBox.Show("Please select a score to remove.", "Error");
            }

            if (i != -1)
            {
                string message = "Are you sure you want to delete?";

                DialogResult selectedButton = MessageBox.Show(message, "Confirm Delete", MessageBoxButtons.YesNo); //Shows a dialog box confirming delete action - Jak

                if (selectedButton == DialogResult.Yes)
                {
                    lstScores.Items.RemoveAt(i); //Removes the item from the list;
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            lstScores.Items.Clear();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            firstName = name.Substring(0, name.IndexOf(' ')); //Creates a substring of the first name before the space
            lastName = name.Substring(name.IndexOf(' ') + 1); //Creates a substring of the last name after the space

            foreach (var score in lstScores.Items)
            {
                newScore += score.ToString() + "|";
            }

            this.DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmUpdateStudentScores_Load(object sender, EventArgs e)
        {
            txtName.Text = name; //Assigns the name to the textbox

            //AddStudentScoresList = addStudent.getScores;
            int score = 0;
            int indexOfPipe;
            int lastIndex = strScore.LastIndexOf("|");

            //Unused
            //List<int> indexes = new List<int>();

            //for (int i = strScore.IndexOf('|'); i > -1; i = strScore.IndexOf('|', i + 1)) //Loop to find each index of the | symbol to substring
            //{
            //    indexes.Add(i);
            //}

            string[] words = strScore.Split('|'); //Splits the string after each | symbol
            words = words.Where(x => !string.IsNullOrEmpty(x)).ToArray(); //Uses Linq to remove any blank indexes and make a new array

            foreach (string word in words)
            {
                lstScores.Items.Add(word); //Adds each word to the list box
            }
        }

        public string getNewScore
        {
            get { return newScore; }
        }

        public string setName //Method to set the name string - Jak
        {
            set { name = value; }
            get { return name; }
        }

        public string getFirstName //Method to set the name string - Jak
        {
            get { return firstName; }
        }

        public string getLastName //Method to set the name string - Jak
        {
            get { return lastName; }
        }

        public string setScore
        {
            set { strScore = value; }
            get { return strScore; }
        }

        //public int setScore1
        //{
        //    set { score1 = value; }
        //    get { return score1; }
        //}

        //public int setScore2
        //{
        //    set { score2 = value; }
        //    get { return score2; }
        //}

        //public int setScore3
        //{
        //    set { score3 = value; }
        //    get { return score3; }
        //}

        public Student GetStudent()
        {
            return student;
        }
    }
}
