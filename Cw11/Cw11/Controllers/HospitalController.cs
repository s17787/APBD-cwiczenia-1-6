using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cw11.DTOs;
using Cw11.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cw11.Controllers
{
    public class HospitalController : Controller
    {
        private readonly HospitalDBContext _context;
        public HospitalController(HospitalDBContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetDoctors()
        {
            return Ok(await _context.Doctors.ToListAsync());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDoctor(int id)
        {
            var doctorbyid = await _context.Doctors.FindAsync(id);
            if (doctorbyid == null)
            {
                return NotFound();
            }
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> CreateDoctor(DoctorDTORequest DoctorDTORequest)
        {
            var doctor = new Doctor
            {
                FirstName = DoctorDTORequest.FirstName,
                LastName = DoctorDTORequest.LastName,
                Email = DoctorDTORequest.Email
            };
            await _context.Doctors.AddAsync(doctor);
            await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDoctor(int idDoctor)
        {
            var doctor = await _context.Doctors.FindAsync(idDoctor);
            if (doctor == null)
            {
                return NotFound();
            }
            _context.Doctors.Remove(doctor);
            await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> EditDoctor(int idDoctor, DoctorDTORequest DoctorDTORequest)
        {
            var doctor = await _context.Doctors.FindAsync(idDoctor);
            if (doctor == null)
            {
                return NotFound();
            }
            doctor.FirstName = DoctorDTORequest.FirstName;
            doctor.LastName = DoctorDTORequest.LastName;
            doctor.Email = DoctorDTORequest.Email;
            await _context.SaveChangesAsync();
            return Ok();
        }   
    }
}

