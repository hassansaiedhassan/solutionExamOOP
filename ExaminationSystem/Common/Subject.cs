using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ExaminationSystem.Common
{
    internal class Subject
    {
        #region properties
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? AnswerText { get; set; }
        //Subject(int id, string? name)
        //{
        //    Id = id;    
        //    Name = name;    
        //}

        #endregion

    }
}
