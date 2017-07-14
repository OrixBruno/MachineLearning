using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AspNetAPiRestfull.Controllers
{
    public class HomeController : Controller
    {
        // GET => Rota padrão
        [HttpGet]
        public IEnumerable<string> Index()
        {
            return new string[] { "value1", "value2" };
        }

        // GET /Home
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }
        // GET /Home/Buscar?o1=XXXXXXXXX&o2=XXXXXXXXX
        public string Buscar(string o1, string o2)
        {
            return o1 + o2;
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
