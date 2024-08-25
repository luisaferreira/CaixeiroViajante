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
            var random = new Random();
            var genes = Enumerable.Range(0, QtdGenes).ToList();

            for (int i = genes.Count - 1; i > 0; i--)
            {
                int j = random.Next(0, i + 1);
                (genes[j], genes[i]) = (genes[i], genes[j]);
            }

            return [.. genes];
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
                Console.Write("(");

                foreach (var gene in individuo.Cromossomo)
                    Console.Write($" {gene}");

                Console.WriteLine($" ) : { individuo.Fitness:F2}");
            }
        }
    }
}
