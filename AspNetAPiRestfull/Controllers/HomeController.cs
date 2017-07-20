using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AspNetAPiRestfull.ViewModels;
using AspNetAPiRestfull.Classes;

namespace AspNetAPiRestfull.Controllers
{
    public class HomeController : Controller
    {
        // GET => Rota padrão
        [HttpGet]
        public IEnumerable<object> Index()
        {
            var listaConverter = new ListConverters();
            return listaConverter.ListaCondicoes.Select(x => new {
                Bandeira = x.Bandeira,
                Internacional = x.Internacional,
                Debito = x.Debito
            });
        }

        // GET /1
        [HttpGet("RetornaString/{id}")]
        public string RetornaString(int id)
        {
            return "value";
        }
        // GET /Buscar?o1=XXXXXXXXX&o2=XXXXXXXXX
        [HttpGet("Buscar")]
        public string Buscar(string o1, string o2)
        {
            return o1 + o2;
        }        
        // GET /BuscarLista
        [HttpGet("BuscarLista")]
        public object BuscarLista()
        {
            var listaConverter = new ListConverters();
            return new {
                Nome = listaConverter.Nome,
                Data = listaConverter.Data
            };
        }  
        // POST /Cadastrar
        [HttpPost("Cadastrar")]
        public void Cadastrar([FromBody]string value)
        {
        }

        // PUT /Atualizar/1
        [HttpPut("Atualizar/{id}")]
        public void Atualizar(int id, [FromBody]string value)
        {
        }

        // DELETE /Excluir/1
        [HttpDelete("{id}")]
        public void Excluir(int id)
        {
        }
    }
}
