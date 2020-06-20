using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cw4.Models;
using Cw4.DTOs.Requests;
using Cw4.DTOs.Responses;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using Cw4.Services;
using Microsoft.VisualBasic;

namespace Cw4.Controllers
{
    [Route("api/enrollments")]
    [ApiController]
    public class EnrollmentsController : ControllerBase
    {
        private IStudentDbService _service;
        public EnrollmentsController(IStudentDbService service)
        {
            _service = service;
        }
        [HttpPost]
        public IActionResult EnrollStudent(EnrollStudentRequest request)
        {

            _service.EnrollStudent(request);
            var response = new EnrollStudentResponse();
            response.LastName = request.LastName;

            return Ok(response + "Was registered");

        }

        [Route("/api/enrollments/promotions")]
        [HttpPost]
        public IActionResult UpdateEnroll(EnrollStudentRequest request)
        {
            _service.PromoteStudents(request.Semester, request.Studies);


            return Ok("Updated");
        }
    }
}

