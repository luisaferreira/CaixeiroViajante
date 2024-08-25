namespace CaixeiroViajante
{
    public class Algoritmo
    {
        public Populacao Populacao { get; set; }
        private readonly Random _random = new Random();
       
        public Algoritmo(int qtdIndividuos, int qtdGenes)
        {
            Populacao = new Populacao(qtdIndividuos, qtdGenes);
        }

        public Individuo? ObterMelhorIndividuo()
            => Populacao.Individuos.OrderBy(i => i.Fitness).FirstOrDefault();

        public IEnumerable<Individuo>? SelecionarIndividuos()
        {
            var selecionados = new List<Individuo>();

            // Tournament Selection
            for (int i = 0; i < Populacao.QtdPopulacao;  i++)
            {                
                var candidatosAleatorios = Populacao.Individuos.OrderBy(x => _random.Next()).Take(5).ToList();

                var melhorCandidato = candidatosAleatorios.OrderBy(x => x.Fitness).First();
                selecionados.Add(melhorCandidato);
            }

            return selecionados;
        }

        public IEnumerable<Individuo>? CruzarIndividuos(IEnumerable<Individuo> selecionados)
        {
            throw new NotImplementedException();
        }

    }
}
