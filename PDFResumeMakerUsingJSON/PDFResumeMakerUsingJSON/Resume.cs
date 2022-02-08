using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDFResumeMakerUsingJSON
{
    class Resume
    {
        public string FullName { get; set; }
        public string Address { get; set; }
        public string ContactNo { get; set; }
        public string Email { get; set; }

        public string Objective { get; set; }

        public string College { get; set; }
        public string CollegeDetail1 { get; set; }
        public string CollegeDetail2 { get; set; }
        public string Highschool{ get; set; }
        public string Elementary { get; set; }

        public string Skill1 { get; set; }
        public string Skill2 { get; set; }
        public string Skill3 { get; set; }
        public string Skill4 { get; set; }

        public string Closing { get; set; }

        //public string Name { get; set; }
        //public int Age { get; set; }
        //public string Course { get; set; }
        //public string School { get; set; }
        //public string Address { get; set; }
        //public string Objective { get; set; }
        //public string Skills { get; set; }
    }
}
