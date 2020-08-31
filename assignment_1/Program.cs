using System;
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
                    test();
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

        public static void CheckInputValidationForIntegers(int input)
        {
            
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
            string input;
            string[] words;
            int numOfWords;
            int totalNumSpaces;
            string longestWord;
            string shortestWord;

            WriteLine("Enter your sentence to get the following info about the sentence: ");
            input = ReadLine();

            // split each words by space into the array
            words = input.Split(' ');

            Write("Number of words: " + words.Length);




            // call back to Menu system
            MenuPicker();

        }

        public static void test()
        {
            string phrase = "";
            string[] words;

            if (phrase == "")
            {
                Write("Number of words: 0");

            }
            else 
            {
                words = phrase.Split(' ');
                
                Write("Number of words: " + words.Length);

                foreach (var word in words)
                {
                    System.Console.WriteLine($"<{word}>");
                }
            }
           
            
        }
    }
}
