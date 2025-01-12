using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem.Common
{
    internal abstract  class Question
    {
      
         public string ?HeaderQuestion { get; set; }
        public string? BodyQuestion { get; set; }
        public double Mark { get; set; }
        
        public Answer[] ?AnswerList { get; set; }
        
        public abstract void AssignQuestion();

    }
}
