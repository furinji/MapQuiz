using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.IO;
using System.Xml.Serialization;

namespace MapQuiz
{
    public sealed class ProblemForSerialize
    {
        public ProblemForSerialize()
        {
            Questions = new List<Question>();
        }

        public static ProblemForSerialize ConvertFromExecutionModel(
            ProblemModel problemModel)
        {
            var instance = new ProblemForSerialize();
            instance.MapImageFileRelativePath = problemModel.MapImageRelativePath;
            foreach (var questionItem in problemModel.QuestionList)
            {
                var newQuestion = new Question();
                newQuestion.Position = questionItem.Position;
                foreach (var answer in questionItem.Answer.Items)
                {
                    newQuestion.Answers.Add(answer.Value);
                }
                instance.Questions.Add(newQuestion);
            }
            return instance;
        }

        public ProblemModel ConvertToExecutionModel()
        {
            var result = new ProblemModel();
            result.MapImageRelativePath = MapImageFileRelativePath;
            result.QuestionList = new List<QuestionModel>();
            foreach (var questionItem in Questions)
            {
                var newQuestion = new QuestionModel();
                newQuestion.Position = questionItem.Position;
                newQuestion.Answer = new AnswerModel();
                newQuestion.Answer.Items = new List<AnswerModel.Item>();
                foreach (var answerItem in questionItem.Answers)
                {
                    newQuestion.Answer.Items.Add(new AnswerModel.Item(answerItem));
                }
                result.QuestionList.Add(newQuestion);
            }
            return result;
        }

        public static ProblemModel LoadFromFile(string filePath)
        {
            if (!File.Exists(filePath)) return null;
            ProblemForSerialize loadItem = null;
            XmlSerializer serializer = new XmlSerializer(typeof(ProblemForSerialize));
            using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                try
                {
                    loadItem = (ProblemForSerialize)serializer.Deserialize(fs);
                }
                catch
                {
                    loadItem = null;
                }
            }
            return loadItem.ConvertToExecutionModel();
        }

        public static bool SaveToFile(ProblemModel problemModel, string filePath)
        {
            var problemForSerialize = 
                ProblemForSerialize.ConvertFromExecutionModel(problemModel);
            XmlSerializer serializer = new XmlSerializer(typeof(ProblemForSerialize));
            bool res = true;
            try
            {
                using (FileStream fs = new FileStream(filePath, FileMode.Create))
                {
                    serializer.Serialize(fs, problemForSerialize);
                }
            }
            catch
            {
                res = false;
            }
            return res;
        }

        public string MapImageFileRelativePath { get; set; }
        public List<Question> Questions { get; set; }

        public sealed class Question
        {
            public Question()
            {
                Answers = new List<string>();
            }

            public Point Position { get; set; }
            public List<string> Answers { get; set; }

        }

    }
}
