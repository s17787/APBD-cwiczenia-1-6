using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cw3.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cw3.DAL
{
    public class MockDbService : IDbService
    {
        private static IEnumerable<Student> _students;
        static MockDbService()
        {
            _students = new List<Student>
            {
            new Student { IdStudent = 1, FirstName = "2an", LastName="Kowalski"},
            new Student {IdStudent = 2, FirstName = "Anna", LastName = "Malewski"}, 
            new Student { IdStudent = 3, FirstName = "Andrzej", LastName = "Andrzejewice" }
            };
        }
        public IEnumerable<Student> GetStudents()
        {
            return _students;
        } 
    } 
}
