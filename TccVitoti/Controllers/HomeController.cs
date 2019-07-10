using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TccVitoti.Models;

namespace TccVitoti.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

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

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            string nome = null;
            try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = "DESKTOP-OVI4B4F";
                builder.UserID = "sa";
                builder.Password = "perceptron01";
                builder.InitialCatalog = "electre";

                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    connection.Open();


                    StringBuilder sb = new StringBuilder();
                    sb.Append("SELECT Nome FROM login where Usuario ='" + model.Usuario + "' and Senha =" + model.Senha);
                    String sql = sb.ToString();

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                nome = (string)reader["Nome"];
                            }
                        }
                    }
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }
            if (nome != null)
            {
                return RedirectToAction("Index", "Hierarquia", new { nome = nome });
            }
            else
            {
                model.Mensagem = "Usuario ou senha errados";
                return View(model);
            }
            
        }
    }
}
