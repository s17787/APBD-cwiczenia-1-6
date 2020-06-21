using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cw10.DAL;
using Cw10.DTOs;
using Cw10.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cw10.Controller
{
    //zadanie 2
    [ApiController]
    [Route("api/students")]
    public class StudentsController : ControllerBase
    {
        private readonly IDBService _IDBService;
        private readonly StudentDBCon _StudentDBCon;

        public StudentsController(IDBService IDBService, StudentDBCon StudentDBCon)
        {
            _StudentDBCon = StudentDBCon;
            _IDBService = IDBService;
        }

        [HttpGet]
        public IActionResult GetStudent()
        {
            var student =_StudentDBCon.Student.ToList();
            return Ok(student);
        }

        [HttpPost]
        public IActionResult AddStudent(Student student)
        {
            student.IndexNumber = $"s{new Random().Next(1, 100)}";
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetStudentId([FromRoute] int id)
        {
            var student = _IDBService.GetStudentByIndex(id.ToString());
            if (student != null)
            {
                return Ok(student);
            }

            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateStudent(UpdateDTOrequest UpdateDTOrequest, [FromRoute] int id)
        {
            var student = _StudentDBCon.Student.FirstOrDefault(x => x.IndexNumber == id.ToString());
            if (student == null)
            {
                return NotFound();
            }
            student.FirstName = UpdateDTOrequest.FirstName;
            student.LastName = UpdateDTOrequest.LastName;
            student.BirthDate = UpdateDTOrequest.BirthDate;
            _StudentDBCon.SaveChanges();
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteStudent([FromRoute] int id)
        {
            var student =_StudentDBCon.Student.FirstOrDefault(x => x.IndexNumber == id.ToString());
            if (student == null)
            {
                return NotFound();
            }
            _StudentDBCon.Student.Remove(student);
            _StudentDBCon.SaveChanges();
            return Ok();
        }
    }
}