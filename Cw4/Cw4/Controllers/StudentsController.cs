using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Cw4.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cw4.Controllers
{
    [ApiController]
    [Route("api/students")]
    public class StudentsController : ControllerBase
    {
        string id = "1";

        private const string ConString = "Data Source=db-mssql;Initial Catalog=s17787;Integrated Security=True";
        [HttpGet]
        public IActionResult GetStudents()
        {
            var list = new List<Student> ();

            using (SqlConnection con = new SqlConnection(ConString))
            using (SqlCommand com = new SqlCommand())
            {
                com.Connection = con;
                com.CommandText = "SELECT FirstName, LastName, BirthDate, Semester, Name FROM student as i INNER JOIN Enrollment as e ON i.IdEnrollment = e.IdEnrollment INNER JOIN Studies as s ON s.IdStudy = e.IdStudy";

                con.Open();
                SqlDataReader dr = com.ExecuteReader();
                while (dr.Read())
                {
                    var st = new Student();
                    st.FirstName = dr["FirstName"].ToString();
                    st.LastName = dr["LastName"].ToString();
                    st.BirthDate = dr["BirthDate"].ToString();
                    st.Semester = dr["Semester"].ToString();
                    st.Name = dr["Name"].ToString();
                    list.Add(st);
                }
            }
            return Ok(list);
    }
        [HttpGet("{id}")]
        public IActionResult GetSemester()
        {
            var list = new List<Student>();

            using (SqlConnection con = new SqlConnection(ConString))
            using (SqlCommand com = new SqlCommand())
            {
                com.Connection = con; com.CommandText = "select * from Student where IndexNumber=@id"; 
                com.Parameters.AddWithValue("id", id);
                com.Connection = con;

                con.Open();
                SqlDataReader dr = com.ExecuteReader();
                while (dr.Read())
                {
                    var st = new Student();
                    st.IndexNumber = dr["IndexNumber"].ToString();
                    st.FirstName = dr["FirstName"].ToString();
                    st.LastName = dr["LastName"].ToString();
                    st.BirthDate = dr["BirthDate"].ToString();
                    list.Add(st);
                }
            }
            return Ok(list);
        }

        

        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(int id)
        {
            return Ok("Ąktualizacja dokończona");
        }

        [HttpPut("{id}")]
        public IActionResult PutStudent(int id)
        {
            return Ok("Usuwanie ukończone");
        }
    }



}
