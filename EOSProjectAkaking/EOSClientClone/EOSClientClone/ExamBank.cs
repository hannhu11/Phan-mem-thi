using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EOSClientClone
{
    public class ExamBank
    {
        public string id { get; set; }
        public Subject subject { get; set; }
        public User? createdBy { get; set; }
    }
}
