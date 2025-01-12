using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem.Common
{
    internal class TrueOrFalse:Question
    {
        #region AssignQuestion
        public override void AssignQuestion()
        {
            Console.WriteLine("True|False Question");
            Console.WriteLine("Please Enter Header Of Question:");
            HeaderQuestion = Console.ReadLine();

            Console.WriteLine("Please Enter Body of Question:");
            BodyQuestion = Console.ReadLine();

            Console.WriteLine("Please Enter Mark of Question:");
            double mark;
            while (!double.TryParse(Console.ReadLine(), out mark) || mark <= 0)
            {
                Console.WriteLine("Please Enter a valid positive number.");
            }
            Mark = mark;

            Console.WriteLine("Please Enter The Right Answer of the Question (1 for True and 2 for False):");
            int answer;
            while (!int.TryParse(Console.ReadLine(), out answer) || answer < 1 || answer > 2)
            {
                Console.WriteLine("Please Enter 1 for True or 2 for False.");
            }

            AnswerList = new Answer[]
            {
            new Answer(1, "True") { IsCorrect = answer == 1 },
            new Answer(2, "False") { IsCorrect = answer == 2 }
            };
        } 
        #endregion
    }
}
