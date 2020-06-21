using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cw10.Models
{
    public class Student
    {
        public string IndexNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public int IdEnrollment { get; set; }
        public virtual Enrollment Enrollment { get; set; }
        public string StudyName { get; internal set; }
        public int SemesterNumber { get; internal set; }
    }
}
