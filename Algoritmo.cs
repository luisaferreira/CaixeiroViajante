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
            var cruzados = new List<Individuo>();
            var listaSelecionados = selecionados.ToList();

            while(listaSelecionados.Count >= 2)
            {
                var pai1 = listaSelecionados[_random.Next(listaSelecionados.Count)];
                listaSelecionados.Remove(pai1);

                var pai2 = listaSelecionados[_random.Next(listaSelecionados.Count)];
                listaSelecionados.Remove(pai2);

                // Crossover com um ponto
                var filho1 = Cruzamento(pai1, pai2);
                var filho2 = Cruzamento(pai2, pai1);

                cruzados.Add(filho1);
                cruzados.Add(filho2);
            }

            return null;
        }

        public Individuo Cruzamento(Individuo pai1, Individuo pai2)
        {
            var tamanho = pai1.Cromossomo.Length;
            var pontoDeCorte = _random.Next(tamanho);

            var cromossomoFilho = new int[tamanho];

            for (int i = 0; i <= pontoDeCorte; i++)
                cromossomoFilho[i] = pai1.Cromossomo[i];

            int posicaoRestante = pontoDeCorte + 1;

            foreach(var gene in pai2.Cromossomo)
            {
                if(!cromossomoFilho.Contains(gene))
                {
                    cromossomoFilho[posicaoRestante] = gene;
                    posicaoRestante = (posicaoRestante + 1) % tamanho;
                }
            }

            return new Individuo(tamanho, cromossomoFilho); 
        }

        public void MutarIndividuos(IEnumerable<Individuo> cruzados)
        {
            throw new NotImplementedException();
        }

        public Populacao AtualizarPopulacao(Populacao populacao, IEnumerable<Individuo> novosIndividuos)
        {
            throw new NotImplementedException();
        }
    }
}
