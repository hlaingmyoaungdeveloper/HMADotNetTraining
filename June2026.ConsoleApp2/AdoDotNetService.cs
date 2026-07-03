using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace June2026.ConsoleApp2;

internal class AdoDotNetService
{

    private readonly SqlConnectionStringBuilder sb;

    public AdoDotNetService()
    {
        sb = new SqlConnectionStringBuilder
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
        SqlConnection connection = new SqlConnection(sb.ConnectionString);
        connection.Open();

        string query = @"SELECT [StudentId]
                            ,[StudentName]
                            ,[StudentNo]
                            ,[FatherName]
                            ,[DateOfBirthday]
                            ,[Email]
                            ,[MobileNo]
                            ,[IsDelete]
                            FROM [dbo].[Tbl_Student]";

        SqlCommand cmd = new SqlCommand(query, connection);

        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        adapter.Fill(dt);


        //SqlDataReader reader = cmd.ExecuteReader();
        //while (reader.Read())
        //{
        //    Console.WriteLine(reader["StudentName"]);
        //}
        connection.Close();

        foreach (DataRow item in dt.Rows)
        {
            Console.WriteLine(item["StudentId"]);
            Console.WriteLine(item["StudentName"]);
            Console.WriteLine(item["StudentNo"]);
            Console.WriteLine(item["FatherName"]);
            DateTime birthday = Convert.ToDateTime(item["DateOfBirthday"]);
            Console.WriteLine(birthday.ToString("dd-MMM-yyyy"));
            Console.WriteLine(item["Email"]);
            Console.WriteLine(item["MobileNo"]);
            Console.WriteLine(item["IsDelete"]);
            Console.WriteLine("-----------------------------------------");
        }
    }

    //public void Read()
    //{
    //    string connectionString = @"Data Source = ASPIERLITE16;
    //    Initial Catalog = June2026Db;
    //    User ID = sa;
    //    Password = sasa@123;
    //    TrustServerCertificate = true";

    //    SqlConnection connection = new SqlConnection(connectionString);
    //    connection.Open();
    //    string query = @"SELECT [StudentId]
    //                        ,[StudentName]
    //                        ,[StudentNo]
    //                        ,[FatherName]
    //                        ,[DateOfBirthday]
    //                        ,[Email]
    //                        ,[MobileNo]
    //                        ,[IsDelete]
    //                        FROM [dbo].[Tbl_Student]";

    //    SqlCommand cmd = new SqlCommand(query, connection);
    //    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
    //    DataTable dt = new DataTable();
    //    adapter.Fill(dt);
    //}


    public void Create()
    {
        SqlConnection connection = new SqlConnection(sb.ConnectionString);
        connection.Open();
        string query = @"INSERT INTO [dbo].[Tbl_Student] 
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
('Edward Norton', 'S005', 'John Norton', '2005-05-08', 'edward.n@example.com', '9876543214', 0);";

        SqlCommand cmd = new SqlCommand(query, connection);
        int result = cmd.ExecuteNonQuery();
        connection.Close();
    }

    public void Update()
    {
        SqlConnection connection = new SqlConnection(sb.ConnectionString);
        connection.Open();
        string query = @"UPDATE [dbo].[Tbl_Student]
                        SET [StudentName] = 'Mg Mg',
                        [Email] = 'mgmg@gmail.com'
                        WHERE [StudentId] = 1;";

        SqlCommand cmd = new SqlCommand(query, connection);
        int result = cmd.ExecuteNonQuery();
        connection.Close();
    }

    public void Delete()
    {
        SqlConnection connection = new SqlConnection(sb.ConnectionString);
        connection.Open();
        string query = @"UPDATE [dbo].[Tbl_Student]
                         SET [IsDelete] = 1
                         WHERE [StudentId] = 1;";

        SqlCommand cmd = new SqlCommand(query, connection);
        int result = cmd.ExecuteNonQuery();
        connection.Close();
    }
}
