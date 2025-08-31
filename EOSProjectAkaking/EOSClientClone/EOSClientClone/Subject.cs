using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EOSClientClone
{
    public class Subject
    {
        public Subject()
        {
        }

        public string id { get; set; }
        public string description { get; set; }

        public Subject(string id, string description)
        {
            this.id = id;
            this.description = description;
        }
    }
}
