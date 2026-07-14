using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace June2026.SqlInjectionTesting
{
    internal class LoginService
    {
        private readonly SqlConnectionStringBuilder _sb;

        public LoginService()
        {
            _sb = new SqlConnectionStringBuilder()
            {
                DataSource = "ASPIERLITE16",
                InitialCatalog = "June2026Db",
                UserID = "sa",
                Password = "sasa@123",
                TrustServerCertificate = true
            };
        }

        public void Login(string username, string password)
        {
            using(IDbConnection db = new SqlConnection(_sb.ConnectionString))
            {
                var user = db.Query("Select * from Tbl_User Where Username=@username and Password=@password", new
                {
                    Username = username,
                    Password = password
                }).FirstOrDefault();
                //var user = db.Query("Select * from Tbl_User Where Username=username and Password=password"); this can do sqlinjection
                if (user != null)
                {
                    Console.WriteLine("Login successfully");
                }
                else
                {
                    Console.WriteLine("Login Fail");
                }
            }
        }
    }
}
