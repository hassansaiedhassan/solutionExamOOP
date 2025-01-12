using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem.Common
{
    internal class MCQ:Question
    {
        #region AssingMcqQuestion
        public override void AssignQuestion()
        {
            Console.WriteLine("MCQ Question");
            Console.WriteLine("Please Enter Header Of Question:");
            do
            {
                HeaderQuestion = Console.ReadLine();
                if(string.IsNullOrEmpty(HeaderQuestion))
                {
                    Console.WriteLine("Please Enter Header Of Question:");
                }
            } while (string.IsNullOrWhiteSpace(HeaderQuestion));


            Console.WriteLine("Please Enter Body of Question:");
            do
            {
                BodyQuestion = Console.ReadLine();
                if(string.IsNullOrWhiteSpace(BodyQuestion))
                {
                    Console.WriteLine("Please Enter Body of Question:");

                }
            } while (string.IsNullOrWhiteSpace(BodyQuestion));
        

            Console.WriteLine("Please Enter Mark of Question:");
            double mark;
            while (!double.TryParse(Console.ReadLine(), out mark) || mark <= 0)
            {
                Console.WriteLine("Please Enter a valid positive number.");
            }
            Mark = mark;
            string? input;

            AnswerList = new Answer[4];
            for (int i = 0; i < 4; i++)
            {
                Console.Write($"Please Enter Choice {i + 1}: ");
                do
                {
                    input = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(input))
                        Console.Write($"Please Enter Choice {i + 1}: ");
                } while (string.IsNullOrWhiteSpace(input));
                AnswerList[i] = new Answer(i + 1, input);
            }

            Console.WriteLine("Please Enter the Correct Choice Number (1-4):");
            int correctChoice;
            while (!int.TryParse(Console.ReadLine(), out correctChoice) || correctChoice < 1 || correctChoice > 4)
            {
                Console.WriteLine("Please Enter a number between 1 and 4.");
            }

            for (int i = 0; i < 4; i++)
            {
                AnswerList[i].IsCorrect = (i + 1 == correctChoice);
            }
            Console.Clear();
        } 
        #endregion
    }
}
