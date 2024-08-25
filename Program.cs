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
                // TODO: Definir número máximo de gerações
                // TODO: Definir fitness de parada

                var algoritmo = new Algoritmo(qtdIndividuos, qtdCidades);
                algoritmo.Populacao.ImprimirPopulacao();

                // TODO: Validar se melhor indivíduo se encaixa no fitness de parada
                var melhorIndividuo = algoritmo.ObterMelhorIndividuo();

                // Seleção 
                var selecionados = algoritmo.SelecionarIndividuos();

                // TODO: Cruzamento

                // TODO: Mutação

                // TODO: Atualizar população

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
            }
        }
    }
}
