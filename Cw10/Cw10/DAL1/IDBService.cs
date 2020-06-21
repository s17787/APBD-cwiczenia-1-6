using Cw10.DTOs;
using Cw10.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cw10.DAL
{
    public interface IDBService
    {
        public IEnumerable<Student> GetStudents();
        public Student GetStudentByIndex(string index);
    }
}
