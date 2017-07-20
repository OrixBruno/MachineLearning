using System.Xml.Linq;
using System.Linq;
using System.Collections.Generic;
using AspNetAPiRestfull.ViewModels;
using System;
using AspNetAPiRestfull.Utils;

namespace AspNetAPiRestfull.Classes
{
    public class ListConverters
    {
        public string Nome { get; set; }
        public string Data { get; set; }
        public List<CondicaoModel> ListaCondicoes { get; set; }
        public ListConverters()
        {
            ListaCondicoes = new List<CondicaoModel>();
            GerarMockadoLista();
        }
        private void GerarMockadoLista(){
            try
            {
                XDocument document = XDocument.Load("MockadoXML/Condicao.xml");
                foreach (var item in document.Descendants("CONDICAO"))
                {
                    var condicao = new CondicaoModel();
                    condicao.Bandeira = Utilitario.GetValueFromListXMLElement(item.Descendants().ToList(),"BANDEIRA");
                    condicao.Internacional = Utilitario.GetValueFromListXMLElement(item.Descendants().ToList(),"INTERNACIONAL");
                    condicao.Debito = Utilitario.GetValueFromListXMLElement(item.Descendants().ToList(),"DEBITO");
                    ListaCondicoes.Add(condicao);
                }

                Nome = Utilitario.GetSubElementValue(document,"NOME_DOCUMENTO","NOME");
                Data = Utilitario.GetSubElementValue(document,"NOME_DOCUMENTO","DATA");                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }        
    }
}