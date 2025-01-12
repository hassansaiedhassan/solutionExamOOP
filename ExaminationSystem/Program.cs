using ExaminationSystem.Common;
using System.ComponentModel.Design;

namespace ExaminationSystem
{
    internal class Program
    {
        static void Main(string[] args)

        {
            #region MakeExam
            Console.WriteLine("Please Enter the type of Exam you want to create (1 for Final Exam, 2 for Practical Exam):");
            int examType;
            while (!int.TryParse(Console.ReadLine(), out examType) || examType < 1 || examType > 2)
            {
                Console.WriteLine("Please enter 1 for Final Exam or 2 for Practical Exam.");
            }

            Console.WriteLine("Please Enter the Time of the Exam (in minutes):");
            double time;
            while (!double.TryParse(Console.ReadLine(), out time) || time <= 0)
            {
                Console.WriteLine("Please enter a valid positive number.");
            }

            Console.WriteLine("Please Enter the Number of Questions:");
            int numberOfQuestions;
            while (!int.TryParse(Console.ReadLine(), out numberOfQuestions) || numberOfQuestions <= 0)
            {
                Console.WriteLine("Please enter a valid positive number.");
            }

            Exam exam = examType == 1 ? new FinalExam(numberOfQuestions, time, "Programming") : new PracitcalExam(numberOfQuestions, time, "Programming");
            exam.GenerateExam();
            Console.Clear();
            #endregion
            #region TestExam
            Console.WriteLine("Do you want to start the Exam (y|n)");
            string input;
            do
            {
                input = Console.ReadLine()?.ToLower();
                if (input != "n" && input != "y")
                {
                    Console.WriteLine("Invalid input. Please enter 'y' to start the exam or 'n' to exit.");
                }
            } while (input != "n" && input != "y" || string.IsNullOrWhiteSpace(input));

            if (input == "y")
            {
                exam!.TakeExam(); // Start the exam if the user chooses 'y'
            }
            else
            {
                Console.WriteLine("Thanks for using the system. Goodbye!"); // Exit message
            }

            #endregion
        }

    }
}
