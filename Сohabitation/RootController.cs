using DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace Сohabitation
{
    public class RootController : Controller
    {
        [HttpGet("/")]
        public IActionResult Result()
        {
            using var db = new ApplicationContextSQL();
            return View("index.cshtml");
        }


        private static void AddTable(ApplicationContextSQL db)
        {
            SqlCommand command = new()
            {
                CommandText = "CREATE TABLE Users (UsersID INT PRIMARY KEY IDENTITY, " +
                                                "NameFirstName NVARCHAR(100) NOT NULL, " +
                                                "UniversityID INT NOT NULL, " +
                                                "Age INT NOT NULL, " +
                                                "Description NVARCHAR(800), " +
                                                "Pay INT NOT NULL, " +
                                                "Course INT, " +
                                                "Gender BIT, " +
                                                "Phone NVARCHAR(11) NOT NULL," +
                                                "Email NVARCHAR(50) NOT NULL," +
                                                "DescriptionID INT NOT NULL)",
                Connection = db.Connection
            };
            command.ExecuteNonQuery();
        }
    }
}
