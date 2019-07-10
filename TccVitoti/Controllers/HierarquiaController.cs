using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TccVitoti.Entities;
using TccVitoti.Models;

namespace TccVitoti.Controllers
{
    public class HierarquiaController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index(string nome)
        {
            TempData["Nome"] = nome;
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(CadastrarHierarquiaViewModel model)
        {
            ViewBag.QtdCriterio = model.QtdCriterio;
            ViewBag.QtdAlternativa = model.QtdAlternativa;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Criar([FromBody]Hierarquia hierarquia)
        {
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
                    sb.Append($@"INSERT INTO hierarquia (Nome,Descricao) output inserted.Id VALUES('{hierarquia.Nome}','{hierarquia.Descricao}')");
                    String sql = sb.ToString();

                    var hierarquiaId = 0;

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        hierarquiaId = (int)await command.ExecuteScalarAsync();
                    }

                    foreach (Criterio c in hierarquia.Criterios)
                    {
                        sb = new StringBuilder();
                        sb.Append($@"INSERT INTO criterio
                        (Id,Nome,Funcao,Peso,HierarquiaId)
                        VALUES({c.Id},'{c.Nome}','{c.Funcao}',{c.Peso},{hierarquiaId})");
                        sql = sb.ToString();

                        using (SqlCommand command = new SqlCommand(sql, connection))
                        {
                            command.ExecuteNonQuery();
                        }

                        foreach (Alternativa a in c.Alternativas)
                        {
                            sb = new StringBuilder();
                            sb.Append($@"INSERT INTO alternativa
                            (Id,Peso,CriterioId,HierarquiaId)
                            VALUES({a.Id},{a.Peso},{c.Id},{hierarquiaId})");
                            sql = sb.ToString();

                            using (SqlCommand command = new SqlCommand(sql, connection))
                            {
                                command.ExecuteNonQuery();
                            }
                        }
                    }
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }

            return View();
        }
    }
}
