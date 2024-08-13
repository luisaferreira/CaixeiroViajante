namespace CaixeiroViajante
{
    public class Populacao
    {
        public int[] Genes { get; set; }
        public IEnumerable<Individuo> Individuos { get; set; }
        public int QtdPopulacao { get; set; }
        public int QtdGenes { get; set; }

        public Populacao(int qtdIndividuos, int qtdGenes)
        {
            QtdPopulacao = qtdIndividuos;
            QtdGenes = qtdGenes;
            Genes = GerarGenes();
            Individuos = GerarIndividuos();
        }

        private int[] GerarGenes()
        {
            int valor;
            var genes = new int[QtdGenes];
            var random = new Random();
            for (int i = 0; i < QtdGenes; i++)
            {
                valor = random.Next(0, 58);

                while (genes.Any(x => x == valor))
                    valor = random.Next(0, 58);

                genes[i] = valor;
            }

            return genes;
        }

        private IEnumerable<Individuo> GerarIndividuos()
        {
            var individuos = new List<Individuo>();

            for (int i = 0; i < QtdPopulacao; i++)
                individuos.Add(new Individuo(QtdGenes, Genes));

            return individuos;
        }

        public void ImprimirPopulacao()
        {
            foreach (var individuo in Individuos)
            {
                Console.Write("{");
                foreach (var gene in individuo.Cromossomo)
                {
                    Console.Write($" {gene}");
                }
                Console.WriteLine(" }");
            }
        }
    }
}
