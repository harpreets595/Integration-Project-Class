using System;
using System.Collections;
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
                    //case 6:
                    //    question6();
                    //    break;
                    //case 7:
                    //    question7();
                    //    break;
                    //case 8:
                    //    question8();
                    //    break;
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

        public static void Question5()
        {
            // start with some color in arrayList
            ArrayList list = new ArrayList();
            list.Add("red");
            list.Add("green");
            list.Add("blue");

            //string[] colors = new string[] { "red", "green", "blue" };
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
                    WriteLine("The color that was searched is not in the list.");
            }
            //// add case
            //else if (inputOption == "add")
            //{
            //    WriteLine("Enter the color to add in the list");
                
            //}
            //// delete case
            //for (int i = 0; i < list.Count; i++)
            //{

            //}

        }

        public static bool CheckIfColorExist(ArrayList list, string inputColor)
        {
            foreach (var color in list)
            {
                if (inputColor == (string)color)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
