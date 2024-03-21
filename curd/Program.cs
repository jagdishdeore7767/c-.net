using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace curd
{

    using System;
    using System.Collections.Generic;

    class Student
    {
        public int StudentID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Grade { get; set; }

        public Student(int id, string name, int age, string grade)
        {
            StudentID = id;
            Name = name;
            Age = age;
            Grade = grade;
        }
    }

    class StudentManager
    {
        private List<Student> students;

        public StudentManager()
        {
            students = new List<Student>();
        }

        public void AddStudent(int id, string name, int age, string grade)
        {
            Student newStudent = new Student(id, name, age, grade);
            students.Add(newStudent);
            Console.WriteLine("Student added successfully!");
        }

        public void ViewAllStudents()
        {
            if (students.Count == 0)
            {
                Console.WriteLine("No students added yet.");
                return;
            }

            foreach (Student student in students)
            {
                Console.WriteLine($"ID: {student.StudentID}, Name: {student.Name}, Age: {student.Age}, Grade: {student.Grade}");
            }
        }

        public void SearchStudentByID(int id)
        {
            Student foundStudent = students.Find(student => student.StudentID == id);
            if (foundStudent != null)
            {
                Console.WriteLine($"ID: {foundStudent.StudentID}, Name: {foundStudent.Name}, Age: {foundStudent.Age}, Grade: {foundStudent.Grade}");
            }
            else
            {
                Console.WriteLine("Student not found.");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            StudentManager manager = new StudentManager();

            while (true)
            {
                Console.WriteLine("\nWelcome to Student Management System!");
                Console.WriteLine("1. Add a new student");
                Console.WriteLine("2. View all students");
                Console.WriteLine("3. Search for a student by ID");
                Console.WriteLine("4. Exit");

                Console.Write("Enter your choice: ");
                int choice;
                while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 4)
                {
                    Console.Write("Invalid input. Please enter a number between 1 and 4: ");
                }

                switch (choice)
                {
                    case 1:
                        Console.Write("Enter Student ID: ");
                        int id = int.Parse(Console.ReadLine());
                        Console.Write("Enter Name: ");
                        string name = Console.ReadLine();
                        Console.Write("Enter Age: ");
                        int age;
                        while (!int.TryParse(Console.ReadLine(), out age) || age < 0)
                        {
                            Console.Write("Invalid input. Please enter a positive integer for age: ");
                        }
                        Console.Write("Enter Grade: ");
                        string grade = Console.ReadLine();
                        manager.AddStudent(id, name, age, grade);
                        break;
                    case 2:
                        manager.ViewAllStudents();
                        break;
                    case 3:
                        Console.Write("Enter Student ID to search: ");
                        int searchID = int.Parse(Console.ReadLine());
                        manager.SearchStudentByID(searchID);
                        break;
                    case 4:
                        Console.WriteLine("Exiting program...");
                        Environment.Exit(0);
                        break;
                }
            }
        }
    }


}
