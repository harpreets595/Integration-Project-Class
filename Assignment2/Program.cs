using System;
using System.Collections.Generic;
using System.Linq;
using static System.Console;

namespace Assignment2
{
    class Program
    {
        const int MINOPTION = 1;
        const int MAXOPTION = 11;
        const int EXIT = 0;
        static void Main(string[] args)
        {
            List<Student> studentList = new List<Student>
            {
                new Student {First="Bob", Last="Jones", ID=111, Age=15, Scores= new List<int> {69, 92, 81, 60}},
                new Student {First="Claire", Last="Simpson", ID=112, Age=17, Scores= new List<int> {75, 84, 83, 39}},
                new Student {First="John", Last="Feetham", ID=113, Age=21, Scores= new List<int> {65, 94, 65, 91}},
                new Student {First="Jonathan", Last="Potts", ID=114, Age=10, Scores= new List<int> {97, 83, 85, 62}},
                new Student {First="Pepe", Last="Garcia", ID=115, Age=20, Scores= new List<int> {35, 72, 91, 70}},
                new Student {First="Samantha", Last="Fakhouri", ID=116, Age=17, Scores= new List<int> {99, 86, 90, 54}},
                new Student {First="Roger", Last="Song", ID=117, Age=19, Scores= new List<int> {60, 72, 64, 45}},
                new Student {First="Hugo", Last="Garcia", ID=118, Age=15, Scores= new List<int> {92, 90, 83, 78}},
                new Student {First="Richard", Last="Ammerman", ID=119, Age=14, Scores= new List<int> {68, 79, 81, 92}},
                new Student {First="Kevin", Last="Adamson", ID=120, Age=11, Scores= new List<int> {68, 71, 81, 79}},
                new Student {First="Jeet", Last="Singh", ID=121, Age=12, Scores= new List<int> {96, 85, 91, 60}}
            };
            
            List<Staff> teacherList = new List<Staff>
            {
                new Staff {First="Jeet", Last="Singh", ID=900},
                new Staff {First="Richard", Last="Potter", ID=901},
                new Staff {First="Terry", Last="Woodward", ID=902},
                new Staff {First="Bob", Last="Feetham", ID=903},
                new Staff {First="Jane", Last="Feetham", ID=904},
                new Staff {First="Oliver", Last="Jones", ID=905},
                new Staff {First="Rafael", Last="Sacramento", ID=906},
                new Staff {First="John", Last="Smith", ID=907},
                new Staff {First="Pepe", Last="Garcia", ID=908}
            };

            List<Course> courseList = new List<Course>
            {
                new Course{Code="100AB",Name="Intro To Computers",Semester="Fall",Duration=15},
                new Course{Code="101AB",Name="Programming I",Semester="Winter",Duration=15},
                new Course{Code="102AB",Name="Programming II",Semester="Fall",Duration=15},
                new Course{Code="103AB",Name="Database I",Semester="Summer",Duration=5},
                new Course{Code="104AB",Name="Database II",Semester="Summer",Duration=5},
                new Course{Code="303ER",Name="Applied Mathematics",Semester="Summer",Duration=5},
                new Course{Code="304ER",Name="Pure Mathematics",Semester="Fall",Duration=15},
                new Course{Code="588A",Name="English Language",Semester="Winter",Duration=10},
                new Course{Code="589A",Name="English Literature",Semester="Winter",Duration=10},
                new Course{Code="588B",Name="More English Language",Semester="Fall",Duration=10},
                new Course{Code="589B",Name="More English Literatute",Semester="Fall",Duration=10},
                new Course{Code="123Z",Name="Basic Biology",Semester="Winter",Duration=15},
                new Course{Code="123Y",Name="Basic Chemistry",Semester="Fall",Duration=15},
                new Course{Code="123X",Name="Basic Physics",Semester="Summer",Duration=8}
            };

            MenuPicker(studentList, teacherList, courseList);

        }
        
        public static void MenuPicker(List<Student> studentList, List<Staff> teacherList, List<Course> courseList)
        {
            WriteLine("\n");

            int input;

            Console.WriteLine("Here is solutions to all question 1 to 11.");
            Console.WriteLine();
            Console.WriteLine("1. Students who are under 18 years of age (in order of age)");
            Console.WriteLine("2. Students who are teenagers (alphabetical order by last name)");
            Console.WriteLine("3. Students who scored 80 or more in their last test (order by score descending)");
            Console.WriteLine("4. Students who scored over 320 marks in total (across all their tests)");
            Console.WriteLine("5. Students who scored at least 60 in all of their tests");
            Console.WriteLine("6. Students grouped by first letter of their last name");
            Console.WriteLine("7. Average score of each test");
            Console.WriteLine("8. Students who are also teachers");
            Console.WriteLine("9. Courses of a duration of 15 weeks");
            Console.WriteLine("10. Courses held in the Winter semester (order by duration)");
            Console.WriteLine("11. Courses grouped by semester");
            Console.WriteLine();
            Console.Write("Enter number 1 to 11, enter 0 to exit: ");

            while (!int.TryParse(ReadLine(), out input) || input < MINOPTION || input > MAXOPTION)
            {
                ForegroundColor = ConsoleColor.Red;
                Write("Error, please enter a valid menu choice: ");
                ResetColor();
            }
            // if user enters 0 than exit the console app
            if (input == EXIT)
                System.Environment.Exit(0);

            switch (input)
            {
                case 1:
                    Question1(studentList);
                    break;
                case 2:
                    Question2(studentList);
                    break;
                case 3:
                    Question3(studentList);
                    break;
                case 4:
                    Question4(studentList);
                    break;
                case 5:
                    Question5(studentList);
                    break;
                case 6:
                    break;
                case 7:
                    break;
                case 8:
                    break;
                case 9:
                    break;
                case 10:
                    break;
                case 11:
                    break;
            }
        }

        #region Question_1 Students who are under 18 years of age (in order of age)
        public static void Question1(List<Student> studentList)
        {
            var studentQuery =
                from s in studentList
                where s.Age < 18
                orderby s.Age ascending
                select s;

            foreach (var student in studentQuery)
            {
                Console.WriteLine("{0} {1}, Age: {2}", student.First, student.Last, student.Age);
            }
        }
        #endregion

        #region Question_2 Students who are teenagers (alphabetical order by last name)
        public static void Question2(List<Student> studentList)
        {
            var studentQuery =
                from s in studentList
                where s.Age >= 13 && s.Age <= 19
                orderby s.Last ascending
                select s;

            foreach (var student in studentQuery)
            {
                Console.WriteLine("{0} {1}, Age: {2}", student.First, student.Last, student.Age);
            }
        }
        #endregion

        #region Question_3 Students who scored 80 or more in their last test (order by score descending)
        public static void Question3(List<Student> studentList)
        {
            var studentQuery =
                from s in studentList
                where s.Scores[3] >= 80
                orderby s.Scores[3] descending
                select s;

            foreach (var student in studentQuery)
            {
                Console.WriteLine("{0} {1}, Score: {2}", student.First, student.Last, student.Scores[3]);
            }
        }
        #endregion

        #region Question_4 Students who scored over 320 marks in total (across all their tests)
        public static void Question4(List<Student> studentList)
        {

            var studentQuery =
                from s in studentList
                where (s.Scores.GetRange(0, 4).Sum()) >= 320
                select s;

            //var studentQuery =
            //    from s in studentList
            //    let totalScore = s.Scores[0] + s.Scores[1] + s.Scores[2] + s.Scores[3]
            //    select s;


            foreach (var student in studentQuery)
            {
                Console.WriteLine("{0} {1}, Score: {2}", student.First, student.Last, student.Scores.GetRange(0, 4).Sum());
            }
        }
        #endregion

        #region Question_5 Students who scored at least 60 in all of their tests
        public static void Question5(List<Student> studentList)
        {

            var studentQuery =
                from s in studentList
                where s.Scores[0] >= 60 && s.Scores[1] >=60 && s.Scores[2] >= 60 && s.Scores[3] >= 60
                select s;

            //var studentQuery =
            //    from s in studentList
            //    let totalScore = s.Scores[0] + s.Scores[1] + s.Scores[2] + s.Scores[3]
            //    select s;


            foreach (var student in studentQuery)
            {
                Console.WriteLine("{0} {1}", student.First, student.Last);
            }
        }
        #endregion



    }
}
