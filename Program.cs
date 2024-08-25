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
                int maxGeracoes = 1000;

                for(int i = 0; i < maxGeracoes; i++)
                {
                    var algoritmo = new Algoritmo(qtdIndividuos, qtdCidades);
                    algoritmo.Populacao.ImprimirPopulacao();

                    var melhorIndividuo = algoritmo.ObterMelhorIndividuo();

                    // Seleção 
                    var selecionados = algoritmo.SelecionarIndividuos();

                    // Cruzamento
                    var cruzados = algoritmo.CruzarIndividuos(selecionados);

                    // TODO: Mutação
                    algoritmo.MutarIndividuos(cruzados);

                    // TODO: Atualizar população
                    algoritmo.Populacao = algoritmo.AtualizarPopulacao(algoritmo.Populacao, cruzados);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
            }
        }
    }
}
