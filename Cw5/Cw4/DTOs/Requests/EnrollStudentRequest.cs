using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Cw4.DTOs.Requests
{
    public class EnrollStudentRequest
    {
        public string IndexNumber { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }

        public string Studies { get; set; }
    }
}
