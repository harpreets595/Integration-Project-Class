using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks.Dataflow;
using static System.Console;

namespace assignment_1
{
    class Program
    {
        const int MINOPTION = 0;
        const int MAXOPTION = 8;
        const int EXIT = 0;
        const double INCHES_TO_CM = 2.54;
        
        static void Main(string[] args)
        {
            // Display the Menu system
            MenuPicker();
        }

        public static void MenuPicker()
        {
            WriteLine("\n");

            int input;

            Console.WriteLine("Here is solutions to all question 1 to 8.");
            Console.Write("Enter number 1 to 8, enter 0 to exit: ");

            while (!int.TryParse(ReadLine(), out input) || input < MINOPTION || input > MAXOPTION)
            {
                ForegroundColor = ConsoleColor.Red;
                Write("Error, please enter a valid menu choice: ");
                ResetColor();
            }
            // if user enters 0 than exit the console app
            if(input == EXIT)
                System.Environment.Exit(0);
            
            switch (input)
            {
                case 1:
                    Question1();
                    break;
                case 2:
                    Question2();
                    break;
                case 3:
                    Question3();
                    break;
                case 4:
                    Question4();
                    break;
                case 5:
                    Question5();
                    break;
                case 6:
                    Question6();
                    break;
                case 7:
                    Question7();
                    break;
                case 8:
                    Question8();
                    break;
                    //default:
                    //    System.Environment.Exit(0);
                    //    break;
            }
        }

        public static void Question1()
        {
            Clear();

            double input;
            double result;
            float i = 3f;

            Write("Enter the number of inches to convert in centimeter: ");
            while(!double.TryParse(ReadLine(), out input) || input < 0)
            {
                ForegroundColor = ConsoleColor.Red;
                Write("Error, please enter a valid number: ");
                ResetColor();
            }

            result = input * INCHES_TO_CM;

            ForegroundColor = ConsoleColor.Green;
            WriteLine(input + " inches = "+ result +" centimeters");
            ResetColor();

            // call back to Menu system
            MenuPicker();
            
        }

        public static void Question2()
        {
            Clear();
            // inputs from user
            int number1;
            int number2;
            int result = 0;
            // check to see if there any bugs
            bool bug = false;

            // get inputs from the user
            Write("Please enter your first number: ");
            while (!int.TryParse(ReadLine(), out number1) || number1 < 0)
            {
                ForegroundColor = ConsoleColor.Red;
                Write("Error, please enter a valid Positive number: ");
                ResetColor();
            }
            Write("Please enter your second number: ");
            while (!int.TryParse(ReadLine(), out number2) || number2 < 0)
            {
                ForegroundColor = ConsoleColor.Red;
                Write("Error, please enter a valid Positive number: ");
                ResetColor();
            }

            try
            {
                result = number1 / number2;
            }
            catch (DivideByZeroException ex)
            {
                WriteLine(ex.Message);
                bug = true;
            }
            finally
            {
                if (!bug)
                    WriteLine("result : " + result);
            }

            // call back to Menu system
            MenuPicker();
        }

        public static void Question3()
        {
            decimal input;

            WriteLine("Enter the amount to receive as change: ");
            while (!decimal.TryParse(ReadLine(), out input) || input < 0)
            {
                ForegroundColor = ConsoleColor.Red;
                Write("Error, please enter a valid Positive amount: ");
                ResetColor();
            }
        }

        public static void Question4()
        {
            Clear();

            string input;
            string[] words;
            int numOfWords = 0;
            int totalNumSpaces = 0;
            string longestWord = "";
            string shortestWord ="";
            // get the index of correspondings to display the word in the array
            int longWordCount;
            int shortWordCount;

            WriteLine("Enter your sentence to get the following info about the sentence: ");
            input = ReadLine();
            
            if (input != "")
            {
                // split each words by space into the array
                words = input.Split(' ');
                longWordCount = words[0].Length;
                shortWordCount = words[0].Length;

                numOfWords = words.Length;
                totalNumSpaces = words.Length - 1;
                
                foreach (var word in words)
                {
                    if(word.Length >= longWordCount)
                        longestWord = word;
                    if(word.Length <= shortWordCount)
                        shortestWord = word;
                }
            }
            // printout of the results at the end
            WriteLine("\nNumber of words: " + numOfWords);
            WriteLine("Total number of spaces: " + totalNumSpaces);
            WriteLine("Shortest word: " + shortestWord);
            WriteLine("Longest word: " + longestWord);

            // call back to Menu system
            MenuPicker();
        }

        #region Question 5
        public static void Question5()
        {
            // start with some color in arrayList
            ArrayList list = new ArrayList();
            list.Add("red");
            list.Add("green");
            list.Add("blue");

            string inputOption;
            string inputColor;
            // check to see if color was found 
            bool isFoundColor = false;

            WriteLine("Please enter one the options: search, add or delete an existing color");
            inputOption = ReadLine().ToLower();

            // input validation
            while(inputOption != "search" && inputOption != "add" && inputOption != "delete")
            {
                ForegroundColor = ConsoleColor.Red;
                WriteLine("Error! Please enter one the options: search, add or delete");
                ResetColor();
                inputOption = ReadLine().ToLower();
            }
            // search case
            if(inputOption == "search")
            {
                Write("Enter the color to search: ");
                inputColor = ReadLine();
                // check to if color exist in a different method
                isFoundColor = CheckIfColorExist(list, inputColor);
                
                if (isFoundColor)
                    WriteLine("The Color is available in the list");
                else
                    WriteLine("{0} is not in the list.", inputColor);
            }
            // add case
            else if (inputOption == "add")
            {
                Write("Enter the color to add in the list: ");
                inputColor = ReadLine();

                isFoundColor = CheckIfColorExist(list, inputColor);

                // validation to check if color already exist to not have redundency
                while (isFoundColor)
                {
                    WriteLine("That color already exists in the list");
                    Write("Enter a new color to add in the list: ");
                    inputColor = ReadLine();
                    isFoundColor = CheckIfColorExist(list, inputColor);
                }
                // add the new color in the list
                list.Add(inputColor);
            }
            // delete case
            else
            {
                Write("Enter the color to delete: ");
                inputColor = ReadLine();
                
                isFoundColor = CheckIfColorExist(list, inputColor);
                
                // validation to check if color exist in the list in order to delete
                while (!isFoundColor)
                {
                    WriteLine("That color does not exists in the list");
                    Write("Enter a new color to delete in the list: ");
                    inputColor = ReadLine();
                    isFoundColor = CheckIfColorExist(list, inputColor);
                }

                // delete the inputColor in the list
                foreach (var color in list)
                {
                    if((string)color == inputColor)
                    {
                        list.Remove(color);
                        break;
                    }                        
                }
            }

            // sort the list in alphabet order
            list.Sort();

            WriteLine("Total Number of Colors in the list: {0}", list.Count);
            WriteLine("The colors in the list are: ");
            // display all colors in list
            foreach (var color in list)
            {
                WriteLine(color);
            }

            // call back to Menu system
            MenuPicker();
        }
        // check to see if a color already exists in the list
        public static bool CheckIfColorExist(ArrayList list, string inputColor)
        {
            foreach (var color in list)
            {
                if (inputColor == (string)color)
                    return true;
            }
            return false;
        }
        #endregion 

        public static void Question6()
        {
            Clear();

            //string filePath = @"\Employee_DATA.csv";

            //string path = Path.GetFullPath("Employee_DATA.csv");
            var reader = new StreamReader(File.OpenRead(@"C:\Users\harp\Documents\GitHub\Integration-Project-Class\assignment_1\Employee_DATA.csv"));
            Console.WriteLine(reader);
 
            int id;
            string fname;
            string lname;
            string dept;
            string pos;
            decimal yearSal;
            int counter = 0;
            var employeeList = new List<Employee>();

            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();

                var lineResult = line.Split(',');

                id = Int32.Parse(lineResult[0]);
                yearSal = Decimal.Parse(lineResult[5]); 
                employeeList.Add(new Employee(id, lineResult[1], lineResult[2], lineResult[3], lineResult[4], yearSal));
            }



            var winners = new List<Employee>();
            for (int i = 0; i < 3; i++)
            {
                GenerateRandomNumber(employeeList.Count, employeeList, winners);
            }

            Console.WriteLine("Platinum Place:");
            Console.WriteLine("First name: {0}, Last name: {1}, Deparment: {2}, Position: {3}, YearlySalary: {4}", winners[0].FirstName, winners[0].LastName, winners[0].Departement, winners[0].Position, winners[0].YearlySalary);
            Console.WriteLine("Gold Place:");
            Console.WriteLine("First name: {0}, Last name: {1}, Deparment: {2}, Position: {3}, YearlySalary: {4}", winners[1].FirstName, winners[1].LastName, winners[1].Departement, winners[1].Position, winners[1].YearlySalary);
            Console.WriteLine("Silver Place:");
            Console.WriteLine("First name: {0}, Last name: {1}, Deparment: {2}, Position: {3}, YearlySalary: {4}", winners[2].FirstName, winners[2].LastName, winners[2].Departement, winners[2].Position, winners[2].YearlySalary);


        }

        public static int GenerateRandomNumber(int range, List<Employee> employeeList, List<Employee> winners)
        {
            var random = new Random();
            var randomNumber = random.Next(range);
            winners.Add(employeeList[randomNumber]);
            //remove employee from list.
            employeeList.RemoveAt(randomNumber);

            return randomNumber;
        }


        public static void Question7()
        {
            Letter l = new Letter(new DateTime(1995, 1, 1), "many");
            CertifiedLetter cl = new CertifiedLetter(3);

            WriteLine(cl.ToString());

        }

        public static void Question8()
        {
            var cookieOrder1 = new CookieOrder("Happy", 5, 5, "oatmeal");
            //returns the total price.
            WriteLine(cookieOrder1.CalculatePrice(cookieOrder1));

            var cookieOrder2 = new CookieOrder("Happy", 5, 1, "oatmeal");
            WriteLine(cookieOrder2.CalculatePrice(cookieOrder2));

        }
    }
}
