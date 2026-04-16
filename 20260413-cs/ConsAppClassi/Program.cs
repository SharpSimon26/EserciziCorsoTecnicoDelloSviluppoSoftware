using ConsAppClassi;

var province = new List<Provincia>
{
    new("Trieste", 20, true),
    new("Udine", 17, true),
    new("Gorizia", 15, true),
    new("Pordenone", 14, true),
};

var provCalda = province.MaxBy(m => m.Temperatura);
var provFredda = province.MinBy(m => m.Temperatura);

if (provCalda != null && provFredda != null)
{
    Console.WriteLine(provFredda.Stampa());
    Console.WriteLine(provCalda.Stampa());
}
else
{
    Console.WriteLine("Non ci sono dati da analizzare");
}
