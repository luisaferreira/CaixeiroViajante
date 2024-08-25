using System.Xml.Linq;

namespace CaixeiroViajante
{
    public static class XMLHelper
    {
        private static readonly string _CaminhoXml = "xml\\brazil58.xml";

        private static XElement DocumentoXml
        {
            get
            {
                return XElement.Load(_CaminhoXml);
            }
        }

        private static IList<XElement> ObterVertices()
            => DocumentoXml.Descendants("vertex").ToList();

        public static int ObterNumeroDeCidades()
            => DocumentoXml.Descendants("vertex").Count();

        public static decimal ObterCustoEntreCidades(int codCidadeOrigem, int codCidadeDestino)
        {
            var vertices = ObterVertices();

            var custo = vertices[codCidadeOrigem].Descendants("edge")?
                .FirstOrDefault(x => x.Value == codCidadeDestino.ToString())?
                .FirstAttribute?
                .Value;

            return decimal.Parse(custo, System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.InvariantCulture);
        }
    }
}
