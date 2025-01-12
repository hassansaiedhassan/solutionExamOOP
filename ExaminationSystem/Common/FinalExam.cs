using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem.Common
{
    internal class FinalExam : Exam

    {
        public FinalExam(int numberOfQuestions, double time, string subjectName) : base(numberOfQuestions, time, subjectName) { }

        public override void GenerateExam()
        {
            for (int i = 0; i < NumberOfQuestions; i++)
            {
                Console.Write($"Please Choose Type of Question {i + 1} (1 for True/False, 2 for MCQ): ");
                int type;
                while (!int.TryParse(Console.ReadLine(), out type) || type < 1 || type > 2)
                {
                    Console.WriteLine("Please enter 1 for True/False or 2 for MCQ.");
                }

                Questions[i] = type == 1 ? new TrueOrFalse() : new MCQ();
                Questions[i].AssignQuestion();
            }
        }
    }
}
