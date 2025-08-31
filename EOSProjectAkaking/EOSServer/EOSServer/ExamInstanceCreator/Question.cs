using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamInstanceCreator
{
    [Serializable]
    public class Question
    {
        public Question() { }

        public string id { get; set; }
        public string questionDescription { get; set; }

        public Dictionary<string , QuestionOption> questionOption  { get; set; }
        public int mark { get; set; }
        public string? image { get; set; }
        public string questionType { get; set; }

        public Question(string id, string questionDescription, Dictionary<string, QuestionOption> questionOption, int mark, string? image, string questionType)
        {
            this.id = id;
            this.questionDescription = questionDescription;
            this.questionOption = questionOption;
            this.mark = mark;
            this.image = image;
            this.questionType = questionType;
        }
    }
}
