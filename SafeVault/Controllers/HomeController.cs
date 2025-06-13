using Microsoft.AspNetCore.Mvc;
using SafeVault.Models;
using System.Diagnostics;
using MySql.Data.MySqlClient;
using SafeVault.Helpers;

namespace SafeVault.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        public IActionResult Submit() => View();



        [HttpPost]
        public IActionResult Submit(string username, string email)
        {
            
            
            //string test= InputSanitizer.SanitizeUsername("; DROP TABLE Users; --");
            //string test1 = InputSanitizer.SanitizeUsername("<script >alert('xss');</script>");
            string safeUsername = InputSanitizer.SanitizeUsername(username);
            string safeEmail = InputSanitizer.SanitizeEmail(email);

            string connStr = "server=localhost;user=root;database=safevault;password=;";
            using var conn = new MySqlConnection(connStr);
            conn.Open();

            string query = "INSERT INTO Users (Username, Email) VALUES (@Username, @Email)";
            using var cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Username", safeUsername);
            cmd.Parameters.AddWithValue("@Email", safeEmail);
            cmd.ExecuteNonQuery();

            ViewBag.Message = "Data submitted successfully!";
            return View();
        }



    }
}