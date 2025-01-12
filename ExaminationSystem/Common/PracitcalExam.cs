using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem.Common
{
    internal class PracitcalExam:Exam
    {
        public PracitcalExam(int numberOfQuestions, double time, string subjectName) : base(numberOfQuestions, time, subjectName) { }

        #region GenerateExam
        public override void GenerateExam()
        {
            for (int i = 0; i < NumberOfQuestions; i++)
            {
                Questions[i] = new TrueOrFalse();
                Questions[i].AssignQuestion();
            }
        } 
        #endregion
    }
}
