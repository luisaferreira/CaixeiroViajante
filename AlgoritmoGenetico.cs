namespace CaixeiroViajante
{
    public class AlgoritmoGenetico
    {
        public Populacao Populacao { get; set; }

        public AlgoritmoGenetico(int qtdIndividuos, int qtdGenes)
        {
            Populacao = new Populacao(qtdIndividuos, qtdGenes);
        }

        public void Executar(int maxGeracoes, int qtdIndividuosCruzamento)
        {

            for (int i = 0; i < maxGeracoes; i++)
            {
                try
                {
                    var melhorIndividuo = Populacao.ObterMelhorIndividuo();

                    var selecionados = Populacao.SelecionarMelhoresIndividuos(qtdIndividuosCruzamento);

                    var cruzados = Populacao.CruzarIndividuos(selecionados);

                    //TODO: Mutação


                    Populacao.AtualizarPopulacao(cruzados);
                    Console.WriteLine();
                    Populacao.ImprimirPopulacao();
                }
                catch (Exception ex)
                { 
                    Console.WriteLine($"Erro: {ex.Message}");
                    Console.WriteLine($"Onde: {ex.StackTrace}");
                }
            }
        }


        public void MutarIndividuos(IEnumerable<Individuo> cruzados)
        {
            throw new NotImplementedException();
        }

    }
}
