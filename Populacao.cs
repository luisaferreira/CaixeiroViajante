using System;

namespace CaixeiroViajante
{
    public class Populacao
    {
        public IEnumerable<Individuo> Individuos { get; set; }
        public int QtdPopulacao { get; set; }
        public int QtdGenes { get; set; }

        public Populacao(int qtdIndividuos, int qtdGenes)
        {
            QtdPopulacao = qtdIndividuos;
            QtdGenes = qtdGenes;
            Individuos = GerarIndividuos();
        }

        private IEnumerable<Individuo> GerarIndividuos()
        {
            var individuos = new List<Individuo>();

            for (int i = 0; i < QtdPopulacao; i++)
                individuos.Add(new Individuo(QtdGenes));

            return individuos;
        }

        public Individuo? ObterMelhorIndividuo()
            => Individuos.OrderBy(i => i.Fitness).FirstOrDefault();

        public IEnumerable<Individuo> SelecionarMelhoresIndividuos(int qtdIndividuos)
            => Individuos.OrderBy(x => x.Fitness).Take(qtdIndividuos);

        public IEnumerable<Individuo>? CruzarIndividuos(IEnumerable<Individuo> selecionados)
        {
            Random _random = new Random();
            var filhos = new List<Individuo>();
            var listaSelecionados = selecionados.ToList();

            while (listaSelecionados.Count >= 2)
            {
                var pai1 = listaSelecionados[_random.Next(listaSelecionados.Count)];
                listaSelecionados.Remove(pai1);

                var pai2 = listaSelecionados[_random.Next(listaSelecionados.Count)];
                listaSelecionados.Remove(pai2);

                // Crossover com um ponto
                var filho1 = Cruzamento(pai1, pai2);
                var filho2 = Cruzamento(pai2, pai1);

                filhos.Add(filho1);
                filhos.Add(filho2);
            }

            return filhos;
        }

        public Individuo Cruzamento(Individuo pai1, Individuo pai2)
        {
            Random _random = new Random();
            var tamanho = pai1.Cromossomo.Length;
            var metadeTamanho = tamanho / 2;
            var pontoDeCorteInicial = _random.Next(0, metadeTamanho + 1);
            var pontoDeCorteFinal = _random.Next(metadeTamanho + 1, tamanho);

            var filho = new int[tamanho];

            for (int i = pontoDeCorteInicial; i < pontoDeCorteFinal + 1; i++)
                filho[i] = pai1.Cromossomo[i];

            var numerosRestantes = pai2.Cromossomo.Except(filho.Where(x => x != 0)).ToArray();
            var numerosInicio = numerosRestantes.Take(pontoDeCorteInicial).ToArray();
            var numerosFim = numerosRestantes.Except(numerosInicio).ToArray();

            for (int i = 0; i < pontoDeCorteInicial; i++)
            {
                if (i < numerosInicio.Length)
                    if (!filho.Contains(numerosInicio[i]) && filho[i] == 0)
                    {
                        filho[i] = numerosInicio[i];
                    }
            }


            for (int i = pontoDeCorteFinal + 1; i < tamanho; i++)
            {
                var valor = i - (pontoDeCorteFinal + 1);
                if (valor < numerosFim.Length)
                {
                    if (!filho.Contains(numerosFim[valor]) && filho[i] == 0)
                    {
                        filho[i] = numerosFim[i - (pontoDeCorteFinal + 1)];
                    }
                }
            }

            return new Individuo(filho);
        }

        public void AtualizarPopulacao(IEnumerable<Individuo> novosIndividuos)
        {
            var populacao = Individuos.ToList();
            populacao.AddRange(novosIndividuos);

            Individuos = populacao
                .GroupBy(x => x.Fitness)
                .Select(g => g.First())
                .OrderBy(x => x.Fitness)
                .Take(QtdPopulacao)
                .ToList();
        }

        public void ImprimirPopulacao()
        {
            foreach (var individuo in Individuos.OrderBy(x => x.Fitness))
            {
                Console.Write("(");

                foreach (var gene in individuo.Cromossomo)
                    Console.Write($" {gene}");

                Console.WriteLine($" ) : {individuo.Fitness:F2}");
            }
        }
    }
}
