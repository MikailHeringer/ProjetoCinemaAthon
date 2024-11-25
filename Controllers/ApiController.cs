using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Text;
using ConfigurationManager = System.Configuration.ConfigurationManager;

namespace ProjetoCinemaAthon.Controllers
{
    public class ApiController : Controller
    {
        private readonly string? apiKey = ChaveAPI.GetKey(); // web.config não deu certo

        public JsonResult BuscarImagens(string query, string type)
        {
            var url = $"https://api.themoviedb.org/3/search/{type}?query={query.Replace(" ", "-")}&api_key={apiKey}";
            using (var client = new HttpClient())
            {
                var response = client.GetStringAsync(url).Result;
                return Json(response);
            }

        }
    }
}
