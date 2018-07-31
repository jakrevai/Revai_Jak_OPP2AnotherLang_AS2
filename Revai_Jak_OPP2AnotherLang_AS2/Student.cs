using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Author Block
//Author: Jak Revai
//Project: Revai_Jak_OP2AnotherLang_AS2_RESUBMIT
//Description: C# Maintain Student Scores
//Version: 1.0

namespace Revai_Jak_OPP2AnotherLang_AS2
{
    public class Student //Class to hold base student object from the XMLReaderStudents.cs
    {
        private string firstName;
        private string lastName;
        private int score1;
        private int score2;
        private int score3;

        private string score;

        public Student()
        {
        }

        public Student(string newFirstName, string newLastName, string newScore)
        {
            this.firstName = newFirstName;
            this.lastName = newLastName;
            this.score = newScore;

            //this.score1 = newScore1;
            //this.score2 = newScore2;
            //this.score3 = newScore3;
        }

        //Getters and setters
        public string FirstName
        {
            get
            {
                return firstName;
            }
            set
            {
                firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return lastName;
            }
            set
            {
                lastName = value;
            }
        }

        public string SetScore
        {
            get
            {
                return score;
            }
            set
            {
                score = value;
            }
        }

        //public int Score1
        //{
        //    get
        //    {
        //        return score1;
        //    }
        //    set
        //    {
        //        score1 = value;
        //    }
        //}

        //public int Score2
        //{
        //    get
        //    {
        //        return score2;
        //    }
        //    set
        //    {
        //        score2 = value;
        //    }
        //}

        //public int Score3
        //{
        //    get
        //    {
        //        return score3;
        //    }
        //    set
        //    {
        //        score3 = value;
        //    }
        //}

        //Method that builds a string from the stored values - Jak
        public string GetText()
        {
            return firstName + " " + lastName + "|" + score;
        }

        //Methods to calculate the scores on the main student form - Jak
        //private void GetScoreTotal()
        //{
        //    int i = lstStudents.SelectedIndex;
        //    Student studentIndex = students.GetItemByIndex(i);

        //    string scoreForCalc = studentIndex.SetScore;

        //    string[] words = scoreForCalc.Split('|'); //Splits the string after each | symbol
        //    words = words.Where(x => !string.IsNullOrEmpty(x)).ToArray(); //Uses Linq to remove any blank indexes and make a new array

        //    int[] scores = Array.ConvertAll(words, int.Parse);
        //    int sum = scores.Sum();

        //    // MessageBox.Show(words.ToString());
        //}
        //public int GetScoreTotal()
        //{
        //    return Score1 + Score2 + Score3;
        //}

        //public int GetScoreAverage()
        //{
        //    return GetScoreTotal() / GetScoreCount();
        //}

        //public int GetScoreCount()
        //{
        //    return 3; //To be updated
        //}
    }    
}
