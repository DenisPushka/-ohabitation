using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace DataAccess
{
    public  class ApplicationContextSQL : DbContext
    {
        public SqlConnection Connection { get; set; }

        public ApplicationContextSQL()
        {
            Connection = new SqlConnection("Server=LAPTOP-28M8R7NT\\SQLEXPRESS;Database=Cohabitation;Trusted_Connection=True;TrustServerCertificate=Yes;");
            Connection.Open();
            Console.WriteLine("Connect db");
        }

        //private async void Connect()
        //{
            /*Connection = new SqlConnection("Server=(localdb)\\mssqllocaldb;Database=Cohabitation;Trusted_Connection=True");
            await Connection.OpenAsync();
            Console.WriteLine("Connect db");

            SqlCommand command = new()
            {
                CommandText = "CREATE TAABLE aaa (Id INT PRIMARY KEY IDENTITY, Age INT NOT NULL, Name NVARCHAR(100) NOT NULL)",
                Connection = this.Connection
            };
            await command.ExecuteNonQueryAsync();*/
        //}
    }
}
