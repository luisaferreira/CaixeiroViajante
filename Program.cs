namespace CaixeiroViajante
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int qtdCidades = XMLHelper.ObterNumeroDeCidades();
                int qtdIndividuos = 10;
                int qtdIndividuosCruzamento = 6;
                int maxGeracoes = 20;
                
                
                var algoritmo = new AlgoritmoGenetico(qtdIndividuos, qtdCidades);
                algoritmo.Executar(maxGeracoes, qtdIndividuosCruzamento);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
            }
        }
    }
}
