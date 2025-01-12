using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem.Common
{
    internal class Answer
    {
        public int AnswerId { get; set; }
        public string ?AnswerText {  get; set; }
        public bool IsCorrect { get; set; }
       public Answer(int id,string _AnswerText) {
            AnswerId = id;
            AnswerText = _AnswerText;
           

        }
    

    }
}
