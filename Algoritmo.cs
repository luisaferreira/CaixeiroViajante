namespace CaixeiroViajante
{
    public class Algoritmo
    {
        public Populacao Populacao { get; set; }
       
        public Algoritmo(int qtdIndividuos, int qtdGenes)
        {
            Populacao = new Populacao(qtdIndividuos, qtdGenes);
        }


    }
}
