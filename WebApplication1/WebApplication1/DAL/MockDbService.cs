using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.DAL
{
    public class MockDbService : ControllerBase
    {
        private static IEnumerable<Student> _students;
        static MockDbService()
        {
            _students = new List<Student>
            {
                new Student { IdStudent = 1, FirstName = "Jan", LastName = "Kowalski" },
                new Student { IdStudent = 2, FirstName = "Anna", LastName = "Malewski" },
                new Student { IdStudent = 3, FirstName = "Andrzej", LastName = "Andrzejewicz" }
            };
        }
            public IEnumerable<Student> GetStudent() {
                return _students;
            }
        }
    }