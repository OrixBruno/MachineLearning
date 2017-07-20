using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace AspNetAPiRestfull.Utils
{
    public static class Utilitario
    {
        public static string GetValueFromListXMLElement(List<XElement> lista, string nome)
        {
            foreach (var a in lista)
            {
                if(a.Name == nome)
                {
                    return a.Value.Trim();
                }
            }
            return string.Empty;
        }
        public static string GetSubElementValue(XDocument xDoc, string elemento, string subElemento)
        {
            try
            {
                var a = xDoc.Root.Descendants((xDoc.Root.GetDefaultNamespace().GetName(elemento))).Descendants()
                            .Where( x => x.Name == xDoc.Root.GetDefaultNamespace().GetName(subElemento))
                            .Select(x => new { resultado = x });

                foreach (var b in a)
                {
                    var reader = b.resultado.CreateReader();
                    reader.MoveToContent();
                    var vlr = reader.ReadInnerXml();

                    if (vlr != null && vlr.Trim() != string.Empty)
                        return vlr.Trim();
                }
            }
            catch
            {
                return string.Empty;
            }
            return string.Empty;
        }
    }    
}