namespace CaixeiroViajante
{
    public class Individuo
    {
        public int[] Cromossomo { get; set; }
        public decimal Fitness { get; set; }

        public Individuo(int qtdGenes)
        {
            Cromossomo = GerarGenes(qtdGenes);
            Fitness = CalcularFitness();
        }

        public Individuo(int[] cromossomo)
        {
            Cromossomo = cromossomo;
            Fitness = CalcularFitness();
        }

        private decimal CalcularFitness()
        {
            //Somatório das distâncias considerando a ordem das cidades no indivíduo
            //Distâncias definidas no arquivo brazil58.xml
            decimal somatorioFitness = 0;
            for (int i = 0; i < Cromossomo.Length; i++)
            {
                var index = i + 1;
                if (index == Cromossomo.Length)
                    index = 0;

                somatorioFitness += XMLHelper.ObterCustoEntreCidades(Cromossomo[i], Cromossomo[index]);
            }

            return somatorioFitness;
        }

        private int[] GerarGenes(int qtdGenes)
        {
            var random = new Random();
            var genes = Enumerable.Range(0, qtdGenes).ToList();

            for (int i = genes.Count - 1; i > 0; i--)
            {
                int j = random.Next(0, i + 1);
                (genes[j], genes[i]) = (genes[i], genes[j]);
            }

            return [.. genes];
        }

    }
}
