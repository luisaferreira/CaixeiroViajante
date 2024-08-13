using System.Xml.Linq;

namespace CaixeiroViajante
{
    public static class XMLHelper
    {
        private static string _CaminhoXml = "C:\\Users\\mlferreira\\Documents\\IFPE\\CaixeiroViajante\\xml\\brazil58.xml";

        private static IList<XElement> ObterVertices()
        {
            XElement doc = XElement.Load(_CaminhoXml);

            return doc.Descendants("vertex").ToList();
        }

        public static decimal ObterCustoEntreCidades(int codCidadeOrigem, int codCidadeDestino)
        {
            var vertices = ObterVertices();

            var custo = vertices[codCidadeOrigem].Descendants("edge")
                .FirstOrDefault(x => x.Value == codCidadeDestino.ToString())
                .FirstAttribute
                .Value;

            return decimal.Parse(custo, System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.InvariantCulture);
        }
    }
}
