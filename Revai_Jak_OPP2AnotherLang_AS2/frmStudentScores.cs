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
    public partial class frmStudentScores : Form
    {
        public frmStudentScores()
        {
            InitializeComponent();
        }

        //Creates global variables
        string name;
        string score;

        private StudentsList students = new StudentsList(); //Calls the StudentsList class

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmAddNewStudent addStudent = new frmAddNewStudent(); //Initialises the frmAddNewStudent form - Jak
            Student student = addStudent.GetStudent(); //Creates the addNewStudent form - Jak

            if (student != null)
            {
                students.Add(student);
                students.Save();
                FillStudentListBox();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {            
            frmUpdateStudentScores updateStudent = new frmUpdateStudentScores(); //Initialises the salesTax form
            Student student = updateStudent.GetStudent(); //Calls the getStudent method from the Student class
            
            int i = lstStudents.SelectedIndex; //Gets the index from the selected item in the list box

            if (i != -1) //If an item is selected
            {
                Student studentIndex = students.GetItemByIndex(i); //Matches the selected item to the index in the list
                name = studentIndex.FirstName + " " + studentIndex.LastName; //Sets the name

                //Getters / Access the public method in the student class to retrieve the score values
                score = studentIndex.SetScore;
                //score2 = studentIndex.Score2;
                //score3 = studentIndex.Score3;

                //Setters / Passing data to frmUpdateStudentScores
                updateStudent.setName = name; //Sets the name on the update form to the name in the selected index of the list - Jak
                updateStudent.setScore = score;
                //updateStudent.setScore2 = score2;
                //updateStudent.setScore3 = score3;

                DialogResult selectedButton = updateStudent.ShowDialog(); //Creates a dialog result 

                if (selectedButton == DialogResult.OK) //When the user has clicked ok in the salesFrm
                {
                    //Getters / Retrieves the NEW score values from frmUpdateStudentScores
                    score = updateStudent.getNewScore;                    
                    //score2 = updateStudent.setScore2;
                    //score3 = updateStudent.setScore3;

                    //creates a new student with the new values
                    student = new Student(updateStudent.getFirstName, updateStudent.getLastName, score);

                    students[i] = student; //Using the indexer method so when you update the user data, the student wont be moved in the list
                    students.Save();
                    FillStudentListBox();
                    SetScore(); //Sets the score calulations to default of 0
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int i = lstStudents.SelectedIndex; //Creates an index based on the selected item in the list - Jak

            if(i != -1)
            {
                Student student = students.GetItemByIndex(i);
                string name = student.FirstName +" "+ student.LastName;
                string message = "Are you sure you want to delete " + name + "?";

                DialogResult selectedButton = MessageBox.Show(message, "Confirm Delete", MessageBoxButtons.YesNo); //Shows a dialog box confirming delete action - Jak
                
                if (selectedButton == DialogResult.Yes)
                {
                    students.Remove(student); //Removes the selected index from the list - Jak
                    students.Save(); //updates the Xml file - Jak
                    FillStudentListBox(); //Refreshes the list box - Jak 
                    SetScore();
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmStudentScores_Load(object sender, EventArgs e)
        {            
            students.Changed += new StudentsList.ChangedHandler(HandleChange);
            students.Fill();            
            FillStudentListBox();            

            //foreach (string word in words)
            //{
               
            //}        
        }

        //METHODS

        private void FillStudentListBox()
        {
            Student student; //Creates a student variable from the Student.cs base class
            lstStudents.Items.Clear(); //Clears the list box - Jak //Mainly used for the HandleChange event so the list box refreshes

            for (int i = 0; i < students.Count; i++ )
            {
                student = students.GetItemByIndex(i);
                lstStudents.Items.Add(student.GetText()); //Runs the GetText method from the student.cs class to display it in the list - Jak
            }
        }

        private void HandleChange(StudentsList students) //Handle changed is called whenever a student is added or removed from the list
        {
            students.Save(); //runs the save method from the studentsList class - Jak
            FillStudentListBox(); //Runs the method to fill the list box - Jak
        }

        private void SetScore()
        {
            int i = lstStudents.SelectedIndex; //Creates an index based on the selected item in the list - Jak

            //If nothing in the list is selected set the scores totals to 0
            if (i != -1)
            {
                GetScoreTotal();
            }
            else
            {
                txtScoreTotal.Text = "";
                txtScoreCount.Text = "";
                txtScoreAverage.Text = "";
            }
        }

        public string setName //Method to set the name string - Jak
        {
            set { name = value; }
        }

        private void GetScoreTotal()
        {
            //TOTAL
            int i = lstStudents.SelectedIndex;
            Student studentIndex = students.GetItemByIndex(i);

            string scoreForCalc = studentIndex.SetScore;

            string[] words = scoreForCalc.Split('|'); //Splits the string after each | symbol
            words = words.Where(x => !string.IsNullOrEmpty(x)).ToArray(); //Uses Linq to remove any blank indexes and make a new array

            int[] scores = Array.ConvertAll(words, int.Parse); //Converts the string array to an integer array
            int sum = scores.Sum();
            txtScoreTotal.Text = sum.ToString();

            //AVERAGE
            int average = sum / scores.Count();
            txtScoreAverage.Text = average.ToString();

            //SCORE COUNT
            txtScoreCount.Text = scores.Count().ToString();
        }

        //END METHODS

        private void lstStudents_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetScore(); //Sets the scores to 0 so they can be changed again when a new item in the list is selected - Jak
        }
    }
}
