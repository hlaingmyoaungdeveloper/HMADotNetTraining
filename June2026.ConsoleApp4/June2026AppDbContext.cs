using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace June2026.ConsoleApp4
{
    public class June2026AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            SqlConnectionStringBuilder sb = new SqlConnectionStringBuilder
            {
                DataSource = "ASPIERLITE16",
                InitialCatalog = "June2026Db",
                UserID = "sa",
                Password = "sasa@123",
                TrustServerCertificate = true
            };
            optionsBuilder.UseSqlServer(sb.ConnectionString);
        }

        public DbSet<StaffEntity> Staffs { get; set; }
    }
}
