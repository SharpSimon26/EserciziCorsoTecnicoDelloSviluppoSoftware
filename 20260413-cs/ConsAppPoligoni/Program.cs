using ConsAppPoligoni;
/*
var triangolo = new Triangolo(10);
Console.WriteLine("Triangolo di lato: {0}", triangolo.LunghezzaLato);
Console.WriteLine("Perimetro: {0}", triangolo.Perimetro);
Console.WriteLine("Area: {0}", triangolo.GetArea());
Console.WriteLine();

var quadrato = new Quadrato(10);
Console.WriteLine("Quadrato di lato: {0}", quadrato.LunghezzaLato);
Console.WriteLine("Perimetro: {0}", quadrato.Perimetro);
Console.WriteLine("Area: {0}", quadrato.GetArea());
Console.WriteLine();

var pentagono = new Pentagono(10);
Console.WriteLine("Pentagono di lato: {0}", pentagono.LunghezzaLato);
Console.WriteLine("Perimetro: {0}", pentagono.Perimetro);
Console.WriteLine("Area: {0}", pentagono.GetArea());
Console.WriteLine();

var esagono = new Esagono(10);
Console.WriteLine("Esagono di lato: {0}", esagono.LunghezzaLato);
Console.WriteLine("Perimetro: {0}", esagono.Perimetro);
Console.WriteLine("Area: {0}", esagono.GetArea());
Console.WriteLine();

Poligono p1 = new Triangolo(20);
Triangolo t2 = (Triangolo)p1;
Triangolo t3 = p1 as Triangolo; // se p1 non è un Triangolo diventa null

if (p1 is Triangolo t4)
{
    t4.GetArea();
}
*/

Console.Write("Inserisci la lunghezza del lato: ");
var latoS = Console.ReadLine();
var lato = float.Parse(latoS);

Console.Write("Inserisci il numero di lati: ");
var numLatiS = Console.ReadLine();
int numLati = int.Parse(numLatiS);

Poligono p = Poligono.Factory(lato, numLati);

Console.WriteLine("Poligono di lato: {0}", p.LunghezzaLato);
Console.WriteLine("Perimetro: {0}", p.Perimetro);
Console.WriteLine("Area: {0}", p.GetArea());
Console.WriteLine();
