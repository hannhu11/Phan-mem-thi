using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EOSClientClone
{
    public class ExamCode
    {
        public ExamCode()
        {
        }

        public string examCode { get; set; }
        public DateTime? startDate { get; set; }
        public DateTime? endDate { get; set; }
        public bool isActive { get; set; }
        public DateTime startTime { get; set; }
        public DateTime endTime { get; set; }
        

        public ExamCode(string examCode, DateTime startDate, DateTime endDate, bool isActive, DateTime startTime, DateTime endTime)
        {
            this.examCode = examCode;
            this.startDate = startDate;
            this.endDate = endDate;
            this.isActive = isActive;
            this.startTime = startTime;
            this.endTime = endTime;
        }
    }
}
