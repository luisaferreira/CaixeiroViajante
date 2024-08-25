namespace CaixeiroViajante
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int qtdCidades = XMLHelper.ObterNumeroDeCidades();
                int qtdIndividuos = 6;

                var algoritmo = new Algoritmo(qtdIndividuos, qtdCidades);
                algoritmo.Populacao.ImprimirPopulacao();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
            }
        }
    }
}
