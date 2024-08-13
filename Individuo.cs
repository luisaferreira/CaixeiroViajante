namespace CaixeiroViajante
{
    public class Individuo
    {
        public int[] Cromossomo { get; set; }
        public decimal Fitness { get; set; }

        public Individuo(int qtdGenes, int[] genes)
        {
            Cromossomo = ReorganizarIndividuo(genes);
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

        private int[] ReorganizarIndividuo(int[] genesOriginais)
        {
            var random = new Random();
            var genes = (int[])genesOriginais.Clone();

            for (int i = genes.Length - 1; i > 0; i--)
            {
                int j = random.Next(0, i + 1);

                int aux = genes[i];
                genes[i] = genes[j];
                genes[j] = aux;
            }

            return genes;
        }

    }
}
