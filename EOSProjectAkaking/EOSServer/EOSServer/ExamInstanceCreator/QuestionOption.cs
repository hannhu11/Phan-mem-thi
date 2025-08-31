using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamInstanceCreator
{
    [Serializable]
    public class QuestionOption
    {
        public QuestionOption() { }
        public string id { get; set; }
        public string  description { get; set; }

        [DefaultValue(false)]
        public bool isCorrect { get; set; }

        public QuestionOption(string id, string description, bool isCorrect)
        {
            this.id = id;
            this.description = description;
            this.isCorrect = isCorrect;
        }
    }
}
