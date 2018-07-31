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
    class StudentsList
    {
        private List<Student> students; //Creates the students list

        //Declares a delegate and event - Jak
        public delegate void ChangedHandler(StudentsList students);
        public event ChangedHandler Changed;

        //Constructor
        public StudentsList()
        {
            students = new List<Student>();
        }

        //Method to return the list count - Jak
        public int Count
        {
            get
            {
                return students.Count;
            }
        }

        //Method to get each item in the list by its index - Jak
        public Student GetItemByIndex(int i)
        {
            return students[i];
        }

        public Student this[int i] //Indexer method, used to update the selected item in the list by its index
        {
            get { return students[i]; }
            set { students[i] = value; }
        }

        //Add method
        public void Add(Student student)
        {
            students.Add(student); //Add to the students list - Jak
            Changed(this); //Calls the Changed event whenever the add method is called - Jak
        }

        //Second add method
        public void Add(string firstName, string lastName, string newScore)
        {
            Student i = new Student(firstName, lastName, newScore);
            students.Add(i);
            Changed(this);
        }

        public void Remove(Student student)
        {
            students.Remove(student); //Removes the item from the list
            Changed(this);
        }

        //Runs the GetStudents method from the XMLReader class
        public void Fill()
        {
            students = XMLReaderStudents.GetStudents();
        }

        public void Save()
        {
            XMLReaderStudents.SaveStudents(students);
        }
    }
}
