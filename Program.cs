namespace CaixeiroViajante
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int qtdCidades = XMLHelper.ObterNumeroDeCidades();
                var qtdGenes = 6;

                var populacao = new Populacao(qtdCidades, qtdGenes);
                populacao.ImprimirPopulacao();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
            }
        }
    }
}
