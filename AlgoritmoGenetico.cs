namespace CaixeiroViajante
{
    public class AlgoritmoGenetico(int qtdIndividuos, int qtdGenes)
    {
        public Populacao Populacao { get; set; } = new Populacao(qtdIndividuos, qtdGenes);

        public void Executar(int maxGeracoes, int qtdIndividuosCruzamento, double taxaMutacao)
        {
            Individuo? melhorIndividuoFinal = null;

            for (int i = 0; i < maxGeracoes; i++)
            {
                try
                {
                    Console.WriteLine(new string('-', 50));
                    Console.WriteLine($"Geração {i}");
                    Console.WriteLine(new string('-', 50));

                    // Melhor indivíduo da população atual
                    var melhorIndividuo = Populacao.ObterMelhorIndividuo();
                    Console.WriteLine("Melhor Individuo na geração atual:");
                    Individuo.ImprimirIndividuo(melhorIndividuo);
                    Console.WriteLine(new string('-', 50));

                    if (melhorIndividuoFinal == null || melhorIndividuo?.Fitness < melhorIndividuoFinal.Fitness)
                        melhorIndividuoFinal = melhorIndividuo;

                    // Seleção
                    var selecionados = Populacao.SelecionarMelhoresIndividuos(qtdIndividuosCruzamento);
                    Console.WriteLine("Indivíduos selecionados para cruzamento:");
                    foreach (var individuo in selecionados)
                        Individuo.ImprimirIndividuo(individuo);

                    Console.WriteLine(new string('-', 50));

                    // Cruzamento
                    var cruzados = Populacao.CruzarIndividuos(selecionados);
                    Console.WriteLine("Indivíduos após cruzamento:");
                    foreach (var individuo in cruzados)
                        Individuo.ImprimirIndividuo(individuo);
                    Console.WriteLine(new string('-', 50));

                    // Mutação
                    Populacao.MutarIndividuos(cruzados, taxaMutacao);
                    Console.WriteLine("Indivíduos após mutação:");
                    foreach (var individuo in cruzados)
                        Individuo.ImprimirIndividuo(individuo);
                    Console.WriteLine(new string('-', 50));

                    // Atualizando a população
                    Populacao.AtualizarPopulacao(cruzados);
                    Console.WriteLine("População atualizada:");
                    Populacao.ImprimirPopulacao();
                    Console.WriteLine(new string('-', 50));

                    // Melhor indivíduo final
                    var melhorIndividuoAtual = Populacao.ObterMelhorIndividuo();
                    if (melhorIndividuoFinal == null || melhorIndividuoAtual?.Fitness < melhorIndividuoFinal.Fitness)
                    {
                        melhorIndividuoFinal = melhorIndividuoAtual;
                    }

                    // Melhor fitness da geração atual
                    var melhorFitnessDaGeracao = melhorIndividuoAtual?.Fitness;
                    Console.WriteLine($"Melhor Fitness da geração {i+1}: {melhorFitnessDaGeracao:F2}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erro:");
                    Console.WriteLine($"Mensagem: {ex.Message}");
                    Console.WriteLine(new string('-', 50));
                }
            }

            if (melhorIndividuoFinal != null)
            {
                Console.WriteLine(new string('*', 50));
                Console.WriteLine("Melhor Individuo Final:");
                Individuo.ImprimirIndividuo(melhorIndividuoFinal);
                Console.WriteLine(new string('*', 50));
            }
        }
    }
}
