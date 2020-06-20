using Cw4.DTOs.Requests;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Cw4.Services
{
    public class SqlServerDbService : IStudentDbService
    {
        private const string ConString = "Data Source=db-mssql;Initial Catalog=s17787;Integrated Security=True";
        public void EnrollStudent(EnrollStudentRequest request)
        {
            using (SqlConnection con = new SqlConnection(ConString))
            using (SqlCommand com = new SqlCommand())
            {
                con.Open();
                com.Connection = con;
                var tran = con.BeginTransaction();
                com.Transaction = tran;
                try
                {
                    com.CommandText = "select IdStudy from Studies where Name=@name";
                    com.Parameters.AddWithValue("name", request.Studies);
                    var dr = com.ExecuteReader();
                    if (!dr.Read())
                    {
                        dr.Close();
                        tran.Rollback();
                    }
                    int idstudies = (int)dr["IdStudy"];
                    dr.Close();
                    com.CommandText = "SELECT * FROM Enrollment as e INNER JOIN  Studies as s ON e.IdStudy = s.IdStudy WHERE e.Semester = 1 AND Name = " + idstudies + " order by e.IdEnrollment desc";
                    dr = com.ExecuteReader();
                    if (!dr.Read())
                    {
                        dr.Close();
                        com.CommandText = "Select IdEnrollment FROM Enrollment";
                        dr = com.ExecuteReader();
                        int enrollid = 1;
                        if (dr.Read())
                        {
                            enrollid = (int)dr["IdEnrollment"];
                        }

                        dr.Close();
                        com.CommandText = "INSERT INTO Enrollment(IdEnrollment, Semester, IdStudy, StartDate) VALUES(" + enrollid + ", 1, " + idstudies + ", " + DateTime.Now.ToString("M/d/yyyy") + ")";
                        com.Parameters.AddWithValue("Studies", request.Studies);
                        com.ExecuteNonQuery();
                    }
                    dr = com.ExecuteReader();
                    com.CommandText = "select IdStudent from Student where StudentId = @IndexNumber";
                    com.Parameters.AddWithValue("IndexNumber", request.IndexNumber);
                    com.Parameters.AddWithValue("name", request.Studies);

                    if (!dr.Read())
                    {
                        dr.Close();
                        tran.Rollback();
                    }

                    com.CommandText = "INSERT INTO Student(IndexNumber, FirstName, LastName, BirthDate, Studies) VALUES(@IndexNumber, @FirstmName, @LastName, @BirthDate, @Studies)";
                    com.Parameters.AddWithValue("IndexNumber", request.IndexNumber);
                    com.Parameters.AddWithValue("FirstmName", request.FirstName);
                    com.Parameters.AddWithValue("LastName", request.LastName);
                    com.Parameters.AddWithValue("BirthDate", request.BirthDate);
                    com.Parameters.AddWithValue("Studies", request.Studies);
                    com.ExecuteNonQuery();

                    tran.Commit();
                }
                catch (SqlException exc)
                {
                    tran.Rollback();
                }
            }
        } 

            public void PromoteStudents(int semester, string studies)
        {
            using (SqlConnection con = new SqlConnection(ConString))
            using (SqlCommand com = new SqlCommand())
            {
                con.Open();
                com.Connection = con;
                var tran = con.BeginTransaction();
                com.Transaction = tran;
                try
                {
                    com.CommandText = "CREATE PROCEDURE PromoteStudents @Studies NVARCHAR(100) = @ValueStudies, @Semester INT = @ValueSemester AS BEGIN  BEGIN TRAN DECLARE @IdStudies INT = (SELECT IdStudy FROM Studies WHERE Name = @Studies); IF @IdStudies IS NULL BEGIN DECLARE @idid INT = (SELECT MAX(IdStudy) FROM Studies); Insert into studies(IdStudy, Name) Values(@idid + 1, @Studies) DECLARE @ididid INT = (SELECT MAX(IdEnrollment) FROM Enrollment); Insert into Enrollment(IdStudy, Semester, IdStudy, StartDate) Values(@ididid + 1, 1, @idid + 1, '2018-11-11') RETURN END UPDATE Enrollment SET Semester = Semester + 1 FROM student as i INNER JOIN Enrollment as e ON i.IdEnrollment = e.IdEnrollment INNER JOIN Studies as s ON s.IdStudy = e.IdStudy WHERE s.Name = @Semester COMMIT END;";
                    com.Parameters.AddWithValue("ValueStudies", semester);
                    com.Parameters.AddWithValue("ValueSemester", studies);
                    var dr = com.ExecuteReader();
                    if (!dr.Read())
                    {
                        dr.Close();
                        tran.Rollback();
                    }
                    int idstudies = (int)dr["IdStudy"];
                    dr.Close();

                }
                catch (SqlException exc)
                {
                    tran.Rollback();
                }
            }
    }
}
