using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace MapQuiz
{
    public sealed class ProblemModel
    {
        public ProblemModel()
        {
            QuestionList = new List<QuestionModel>();
        }


        //public string MapImageFileName { get; set; }
        public string MapImageRelativePath { get; set; }
        //[System.Xml.Serialization.XmlArrayItem(typeof(QuestionModel))]
        public List<QuestionModel> QuestionList { get; set; }
        //public IList<QuestionModel> QuestionList { get; set; }




        

    }
}
