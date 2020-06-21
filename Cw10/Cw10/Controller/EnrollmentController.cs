using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cw10.DTOs;
using Cw10.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cw10.Controller
{
    [Route("api/enrollments")]
    [ApiController]
    public class EnrollmentsController : ControllerBase
    {
        private readonly StudentDBCon _StudentDBCon;

        public EnrollmentsController(StudentDBCon StudentDBCon)
        {
            _StudentDBCon = StudentDBCon;
        }

        [HttpPost]
        public IActionResult CreateStudent(CreateDTOrequest CreateDTOrequest)
        {
            var Studies = _StudentDBCon.Studies.Include(x => x.Enrollments).FirstOrDefault(x => x.Name==CreateDTOrequest.Studies);
            if (Studies == null)
            {
                return BadRequest();
            }

            if (_StudentDBCon.Student.Any(x => x.IndexNumber == CreateDTOrequest.IndexNumber))
            {
                return BadRequest();
            }

            var enrollment = Studies.Enrollments.OrderByDescending(x => x.StartDate).FirstOrDefault(x =>x.Semester==1);
            if (enrollment == null)
            {
                enrollment = new Models.Enrollment()
                {
                    IdEnrollment = _StudentDBCon.Enrollment.Max(x => x.IdEnrollment)+1,
                    Studies = Studies,
                    StartDate = DateTime.Now,
                    Semester = 1
                };
                _StudentDBCon.Enrollment.Add(enrollment);
            }
            var student = new Student()
            {
                IndexNumber = CreateDTOrequest.IndexNumber,
                LastName = CreateDTOrequest.LastName,
                FirstName = CreateDTOrequest.FirstName,
                BirthDate = CreateDTOrequest.BirthDate,
                Enrollment = enrollment
            };
            _StudentDBCon.Student.Add(student);
            _StudentDBCon.SaveChanges();

            return Ok();
        }

        [HttpPost("promotions")]
        public IActionResult PromoteStudents(PromoteDTOrequest PromoteDTOrequest)
        {
            var studies = _StudentDBCon.Studies.Include(x => x.Enrollments).FirstOrDefault(x => x.Name == PromoteDTOrequest.Studies);
            if (studies == null)
            {
                return NotFound();
            }
            if (studies.Enrollments.All(x => x.Semester != PromoteDTOrequest.Semester))
            {
                return NotFound();
            }
            var SemesterEnr = studies.Enrollments.OrderByDescending(x => x.StartDate).FirstOrDefault(x => x.Semester == PromoteDTOrequest.Semester + 1);
            if (SemesterEnr == null)
            {
                SemesterEnr = new Models.Enrollment()
                {
                    IdEnrollment = _StudentDBCon.Enrollment.Max(x => x.IdEnrollment) + 1,
                    Studies = studies,
                    StartDate = DateTime.Now,
                    Semester = PromoteDTOrequest.Semester + 1
                };
                _StudentDBCon.Enrollment.Add(SemesterEnr);
            }
            var Promote = _StudentDBCon.Student.Where(x => x.Enrollment.Studies == studies && x.Enrollment.Semester == PromoteDTOrequest.Semester).ToList();
            foreach (var i in Promote)
            {
                i.Enrollment = SemesterEnr;
            }
            _StudentDBCon.SaveChanges();
            return Ok();
        }
    }
}