using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.DAL
{
    public interface IDbService{
        public IEnumerable<Student> GetStudent();
        object GetStudents();
    }
}