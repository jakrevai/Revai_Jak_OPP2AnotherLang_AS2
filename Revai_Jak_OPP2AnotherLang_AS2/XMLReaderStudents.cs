using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

//Author Block
//Author: Jak Revai
//Project: Revai_Jak_OP2AnotherLang_AS2_RESUBMIT
//Description: C# Maintain Student Scores
//Version: 1.0

namespace Revai_Jak_OPP2AnotherLang_AS2
{
    class XMLReaderStudents
    {
        private const string Path = @"..\..\Students.xml"; //Path to the Students.xml file where all the students will be stored - Jak

        //XMLReader method
        public static List<Student> GetStudents() //Method to grab all the students from the Students.xml
        {
            //Creates a list - Jak
            List<Student> students = new List<Student>();

            //Creates a XmlReaderSettings object - Jak
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.IgnoreWhitespace = true;
            settings.IgnoreComments = true;

            //Creates the XmlReader object - Jak
            XmlReader xmlIn = XmlReader.Create(Path, settings);

            //Reads past every line until it finds a Student node - Jak
            if (xmlIn.ReadToDescendant("Student"))
            {
                //Creates one student for each Students node - Jak
                do
                {
                    Student student = new Student();
                    xmlIn.ReadStartElement("Student"); //Reads the Student start node - Jak
                    
                    //Runs the get methods from the Student.cs class and add it to the list - Jak
                    student.FirstName = xmlIn.ReadElementContentAsString();
                    student.LastName = xmlIn.ReadElementContentAsString();
                    student.SetScore = xmlIn.ReadElementContentAsString();
                    students.Add(student); //Add each student to the students list - Jak
                }
                while (xmlIn.ReadToNextSibling("Student")); //Reads to the next Student node and repeat the abov code - Jak
            }

            // close the XmlReader object
            xmlIn.Close();

            return students; //Returns the list object - Jak
        }

        //XMLWriter method
        public static void SaveStudents(List<Student> students) //Writes students to the xml file - Jak
        {
            //Creates the XmlWriterSettings object - Jak
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.IndentChars = ("    ");

            //Create the XmlWriter object - Jak
            XmlWriter xmlOut = XmlWriter.Create(Path, settings);

            //Write the start of the document
            xmlOut.WriteStartDocument();
            xmlOut.WriteStartElement("Students"); //Setsup the starting node if none exist - Jak

            //Write out sample students if none exist
            
            

            //Write each student object to the xml file - Jak
            foreach (Student student in students)
            {
                xmlOut.WriteStartElement("Student");
                xmlOut.WriteElementString("FirstName", student.FirstName);
                xmlOut.WriteElementString("LastName", student.LastName);
                xmlOut.WriteElementString("Score", student.SetScore);
                xmlOut.WriteEndElement();
            }

            //Write the end tag - Jak
            xmlOut.WriteEndElement();

            //Close the xmlWriter object - Jak
            xmlOut.Close();
        }

        
    }
}
