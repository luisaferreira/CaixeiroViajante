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
                double taxaMutacao = 0.05;                
                
                var algoritmo = new AlgoritmoGenetico(qtdIndividuos, qtdCidades);
                algoritmo.Executar(maxGeracoes, qtdIndividuosCruzamento, taxaMutacao);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
            }
        }
    }
}
