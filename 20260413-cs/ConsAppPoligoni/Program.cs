using ConsAppPoligoni;

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
