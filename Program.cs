using CaixeiroViajante;

var qtdGenes = 6;
var qtdPop = 10;

var populacao = new Populacao(qtdPop, qtdGenes);

populacao.ImprimirPopulacao();


var i = XMLHelper.ObterCustoEntreCidades(0,43);


Console.WriteLine(i);



