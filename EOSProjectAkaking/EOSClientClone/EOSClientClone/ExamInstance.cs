using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EOSClientClone
{
    public class ExamInstance
    {
        public User user { get; set; }
        public ExamBank? examBank { get; set; }
        public ExamCode examCode { get; set; }
        public Dictionary<Question, string>? MyProperty { get; set; }
        public String operationSystem { get; set; }
        public ExamInstance() {}

        public ExamInstance(User user, ExamBank examBank, ExamCode examCode, Dictionary<Question, string> myProperty, String operationSystem)
        {
            this.user = user;
            this.examBank = examBank;
            this.examCode = examCode;
            this.operationSystem = operationSystem;
        }
    }


}
