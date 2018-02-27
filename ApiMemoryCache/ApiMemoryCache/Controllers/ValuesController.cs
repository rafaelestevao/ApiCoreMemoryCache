using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;

namespace ApiMemoryCache.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        [HttpGet]
        public ContentResult Get([FromServices]IConfiguration config, [FromServices]IMemoryCache cache)
        {
            string valorJSON = cache.GetOrCreate<string>(
                "MemoryCache ", context =>
                {
                    context.SetAbsoluteExpiration(TimeSpan.FromSeconds(30));
                    context.SetPriority(CacheItemPriority.High);

                    return $"Estes dados foram retornados as: {DateTime.Now.ToString()}";
                    //using (SqlConnection conexao = new SqlConnection(
                    //    config.GetConnectionString("BaseCotacoes")))
                    //{
                    //    return conexao.QueryFirst<string>(
                    //        "SELECT Sigla " +
                    //              ",NomeMoeda " +
                    //              ",UltimaCotacao " +
                    //              ",GETDATE() AS DataProcessamento " +
                    //              ",ValorComercial AS 'Cotacoes.Comercial' " +
                    //              ",ValorTurismo AS 'Cotacoes.Turismo' " +
                    //        "FROM dbo.Cotacoes " +
                    //        "ORDER BY NomeMoeda " +
                    //        "FOR JSON PATH, ROOT('Moedas')");
                    //}
                });

            return Content(valorJSON, "application/json");
        }

        // GET api/values
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
