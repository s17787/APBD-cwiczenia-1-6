using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cw4.Models;
using Cw4.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Cw4.DAL
{
    public interface IDbService
    {
        public IEnumerable<Student> GetStudents();
    }
}
