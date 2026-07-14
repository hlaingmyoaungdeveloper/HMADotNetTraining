using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace June2026.ConsoleApp3
{
    internal class DapperService
    {
        private readonly SqlConnectionStringBuilder _sb;

        public DapperService()
        {
            _sb = new SqlConnectionStringBuilder
            {
                DataSource = "ASPIERLITE16",
                InitialCatalog = "June2026Db",
                UserID = "sa",
                Password = "sasa@123",
                TrustServerCertificate = true
            };
        }

        public void Read()
        {
            using (IDbConnection db = new SqlConnection(_sb.ConnectionString))
            {
                db.Open();
                List<Student> students = db.Query<Student>("SELECT * FROM [dbo].[Tbl_Student]").ToList();
                foreach (Student item in students)
                {
                    Console.WriteLine($"Student ID : {item.StudentId}  Student Name : {item.StudentName}");
                }
            }
        }

        public void Create()
        {
            using (IDbConnection db = new SqlConnection(_sb.ConnectionString))
            {
                db.Open();
                int result = db.Execute(@"INSERT INTO [dbo].[Tbl_Student] 
                ([StudentName], 
                [StudentNo], 
                [FatherName],
                [DateOfBirthday], 
                [Email],
                [MobileNo], 
                [IsDelete])
                VALUES 
                ('Alice Johnson', 'S001', 'Robert Johnson', '2005-03-12', 'alice.j@example.com', '9876543210', 0),
                ('Bob Smith', 'S002', 'William Smith', '2004-07-22', 'bob.smith@example.com', '9876543211', 0),
                ('Charlie Davis', 'S003', 'Michael Davis', '2005-01-15', 'charlie.d@example.com', '9876543212', 0),
                ('Diana Prince', 'S004', 'Steve Prince', '2006-11-30', 'diana.p@example.com', '9876543213', 0),
                ('Edward Norton', 'S005', 'John Norton', '2005-05-08', 'edward.n@example.com', '9876543214', 0);");
                Console.WriteLine($"Row Effected : {result}");
            }
        }

        public void Update()
        {
            using (IDbConnection db = new SqlConnection(_sb.ConnectionString))
            {
                db.Open();
                int result = db.Execute(@"UPDATE [dbo].[Tbl_Student]
                        SET [StudentName] = 'Mg Mg',
                        [Email] = 'mgmg@gmail.com'
                        WHERE [StudentId] = 7;");
                Console.WriteLine($"Row Effected : {result} ");
            }
        }

        public void Delete()
        {
            using (IDbConnection db = new SqlConnection(_sb.ConnectionString))
            {
                db.Open();
                int result = db.Execute("DELETE FROM [dbo].[Tbl_Student] WHERE StudentId = 5");
                Console.WriteLine($"Row Effected : {result} ");
            }
        }
    }

    public class Student
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public string StudentNo { get; set; }
        public string FatherName { get; set; }
        public DateTime DateOfBirthday { get; set; }
        public string Email { get; set; }
        public string MobileNo { get; set; }
        public bool IsDelete { get; set; }
    }
}