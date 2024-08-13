namespace CaixeiroViajante
{
    public class Individuo
    {
        public int[] Cromossomo { get; set; }
        public double Fitness { get; set; }

        public Individuo(int qtdGenes, int[] genes)
        {
            Cromossomo = ReorganizarIndividuo(genes);
        }

        private void CalcularFitness()
        {
            //Somatório das distâncias considerando a ordem das cidades no indivíduo
            //Distâncias definidas no arquivo brazil58.xml
            //TODO: Verificar a melhor maneira de transformar o xml em um objeto para ter acesso as propriedades de distância
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
