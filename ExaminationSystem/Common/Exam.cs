using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem.Common
{
    internal abstract class Exam

    {
        #region properties
        public double Time { get; set; }
        public int NumberOfQuestions { get; set; }
        public Subject Subject { get; set; }
        public Question[] Questions { get; set; }

        #endregion
        protected Exam(int numberOfQuestions, double time, string subjectName)
        {
            NumberOfQuestions = numberOfQuestions;
            Time = time;
            Subject = new Subject { Name = subjectName };
            Questions = new Question[numberOfQuestions];
         

        }

        #region Method
        public abstract void GenerateExam();

        public void TakeExam()
        {
            double userScore = 0;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            double TotalMark = 0;

            Console.WriteLine("Starting the Exam...");
            Console.WriteLine($"You have {Time} minutes to complete the exam.");
            Console.WriteLine("----------------------------------------");

            for (int i = 0; i < NumberOfQuestions; i++)
            {
                if (stopwatch.Elapsed.TotalMinutes >= Time)
                {
                    Console.WriteLine("Time's up! The exam has ended.");
                    break;
                }


                Console.WriteLine($"Question {i + 1} of {NumberOfQuestions}:");
                Console.WriteLine($"Header: {Questions[i].HeaderQuestion}");
                Console.WriteLine($"Body: {Questions[i].BodyQuestion}");
                Console.WriteLine($"Mark: {Questions[i].Mark}");
                TotalMark += Questions[i].Mark;
                Console.WriteLine("Choices:");

                if (Questions[i] is TrueOrFalse)
                {
                    Console.WriteLine("1. True");
                    Console.WriteLine("2. False");
                }
                else
                {
                    for (int j = 0; j < Questions[i].AnswerList.Length; j++)
                    {
                        Console.WriteLine($"{j + 1}. {Questions[i].AnswerList[j].AnswerText}");
                    }
                }

                int userAnswer;
                bool flag;
                do
                {
                    Console.Write("Your answer (Enter the number of your choice): ");
                    flag = int.TryParse(Console.ReadLine(), out userAnswer);

                    if (Questions[i] is TrueOrFalse)
                    {
                        if (!flag || userAnswer < 1 || userAnswer > 2)
                        {
                            Console.WriteLine("Invalid input. Please enter 1 for True or 2 for False.");
                        }
                    }
                    else
                    {
                        if (!flag || userAnswer < 1 || userAnswer > Questions[i].AnswerList.Length)
                        {
                            Console.WriteLine($"Invalid input. Please enter a number between 1 and {Questions[i].AnswerList.Length}.");
                        }
                    }
                } while (!flag || (Questions[i] is TrueOrFalse ? (userAnswer < 1 || userAnswer > 2) : (userAnswer < 1 || userAnswer > Questions[i].AnswerList.Length)));

                if (Questions[i].AnswerList[userAnswer - 1].IsCorrect)
                {
                    userScore += Questions[i].Mark;
                    Console.WriteLine("Correct!");
                }
                else
                {
                    Console.WriteLine("Incorrect!");
                    Console.WriteLine($"The correct answer is: {GetCorrectAnswer(Questions[i])}");
                }

                Console.WriteLine("----------------------------------------");
                //Console.Clear();
            }

            stopwatch.Stop();

            Console.WriteLine("Exam Finished!");
            Console.WriteLine($"Subject: {Subject.Name}");
            Console.WriteLine($"Your score: {userScore} out of {TotalMark}");
            Console.WriteLine($"Time taken: {stopwatch.Elapsed.TotalMinutes:F2} minutes");
        }

        private string GetCorrectAnswer(Question question)
        {
            return question.AnswerList.FirstOrDefault(a => a.IsCorrect)?.AnswerText ?? "No correct answer found.";
        } 
        #endregion

    }
}
