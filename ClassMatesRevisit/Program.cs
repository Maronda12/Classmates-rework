using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;

namespace ClassMatesRevisit
{
    class Program
    {
        static void Main(string[] args)
        {
            //Started over because my first classmates lab was a mess
            //Still not running correctly
            Console.WriteLine("Welcome to our class");

            //Had to add the student names here as well my list was not importing from txt
            List<Student> StudentList = new List<Student>();
            StudentList.Add(new Student("Mark", "Grand Rapids", "Cilantro"));
            StudentList.Add(new Student("Andrew", "Grayslake", "Sushi"));
            StudentList.Add(new Student("Tommy", "Raleigh", "Chicken Curry"));
            StudentList.Add(new Student("James", "Toledo", "Sushi"));
            StudentList.Add(new Student("Jerome", "Milwaukee", "Italian cusine"));
            StudentList.Add(new Student("Trent", "Rochester", "Tacos"));
            StudentList.Add(new Student("Troy", "Indian River", "Broccoli"));
            StudentList.Add(new Student("Kevin", "Detroit", "Asian cusine"));
            StudentList.Add(new Student("Josh", "Northville", "Nalesniki"));
            StudentList.Add(new Student("Kate", "Zeeland", "Pizza"));
            StudentList.Add(new Student("Maronda", "Detroit", "Salmon"));

            

            string input = GetUserInput("View student list or add student");
            

            if (input == "add student") 
            {
                //call new student
                Console.WriteLine("Great lets add a new student");
                AddStudent(StudentList);     
            }
            else if (input == "view student list")
            {
                
                //call student information list
                StudentLists(StudentList);

            }
          

        }

        public static void StudentLists(List<Student> StudentList)
        {
            //print out list of all student objects by name
            Console.WriteLine("Student List");
            for (int i = 0; i < StudentList.Count; i++)
            {
                Student stu = StudentList[i];
                Console.WriteLine($"{i} : {stu.Name}");
            }

            string input = GetUserInput("Would you like to learn more about a student? (yes/no)");
            if (input == "yes" || input == "y")
            {
                MoreInfo(StudentList);
            }
            
            
        }

        public static void MoreInfo(List<Student> StudentList)
        {
            Console.WriteLine("Please select the index of the student you want to learn more about");
            string input = Console.ReadLine();
            try
            {
                int index = int.Parse(input);

                for (int i = 0; i < StudentList.Count; i++)
                {
                    Student stu = StudentList[i];
                    if (index == i)
                    {
                        Console.WriteLine($"Favorite food is: {stu.FavoriteFood}");
                        Console.WriteLine($"Hometown is: {stu.HomeTown}");
                        Console.ReadLine();
                        
                    }

                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Please select the index of the student you want to learn more about");
                MoreInfo(StudentList);
            }

        }

        public static void DisplayStudentLists()
        {
           
            string filePath = "StudentList.txt";  //relative file path

            StreamReader reader = new StreamReader(filePath);
            //this is how we read the file

            //this reads the whole file
            string output = reader.ReadToEnd();
            Console.WriteLine(output);

            //split lines of file when new line starts, then store those new lines in and array
            string[] lines = output.Split("\n");

            //create a list of student objects
            List<Student> studentInfo = new List<Student>();

            //converts each line into a Student object 
            foreach (string line in lines)
            {
                Student stu = ConvertToStudent(line);
                if (stu != null)
                {
                    //goes to list of students we created in txt file
                    studentInfo.Add(stu);
                }
            }
            reader.Close();
        }

        public static void AddStudent(List<Student> StudentList)
        {
            
            string filePath = "StudentList.txt";//Add relative file path

            
            Student s = new Student();// this is our new student

            
            Console.WriteLine("Please enter the new students name: ");
            s.Name = Console.ReadLine();

            Console.WriteLine("Thanks now enter their HomeTown:");
            s.HomeTown = Console.ReadLine();

            Console.WriteLine("Last enter their favoite food:");
            s.FavoriteFood = Console.ReadLine();

            //convert Student object to string format
            string line = StudentToString(s);
            StudentList.Add(s);
            Console.Write($"{line} has been added to the list");

            //read file
            StreamReader reader = new StreamReader(filePath);
            //make copy of original txt file
            string original = reader.ReadToEnd();
            reader.Close();

            //write new info to existing file
            StreamWriter writer = new StreamWriter(filePath);
            writer.WriteLine(original + line);
            writer.Close();


        }

        public static string StudentToString(Student s)
        {
            string output = $"{s.Name}, {s.HomeTown}, {s.FavoriteFood}";
            return output;
        }

        public static Student ConvertToStudent(string line)
        {
            //split the line at every comma and store it into a string array
            string[] properties = line.Split(',');
            //create a new student object
            Student s = new Student();

            //check it new string has 3 indexs
            if (properties.Length == 3)
            {
                s.Name = properties[0];
                s.HomeTown = properties[1];
                s.FavoriteFood = properties[2];
               
                return s;
            }
            else
            {
                //return empty object
                return s;
            }
        }

        public static string GetUserInput(string message)
        {
            Console.WriteLine(message);
            string userInput = Console.ReadLine().ToLower().Trim();

            if (userInput == "add student")
            {
                return userInput;
            }
            else if(userInput == "view student list")
            {
                return userInput;
            }
            else
            {
                return "not an input";
            }
        }

        
       
    }




}