namespace ConsAppPoligoni;

internal abstract class Poligono(int numeroLati, float lunghezzaLato)
{
    public int NumeroLati { get; private set; } = numeroLati;
    public float LunghezzaLato { get; private set; } = lunghezzaLato;
    public float Perimetro
    {
        get {
            return NumeroLati * LunghezzaLato;
        }
    }

    public abstract float GetArea();
}

internal class Triangolo(float lunghezzaLato) : Poligono(3, lunghezzaLato)
{
    /**
    L'area di un triangolo equilatero si calcola elevando la lunghezza del lato al quadrato, 
    moltiplicando per la radice quadrata di 3 (1.732) e dividendo il risultato per 4.
    Poiché è richiesto un float viene effettuato un cast da double a float
    */    
    public override float GetArea()
    {
        return (float)(LunghezzaLato * LunghezzaLato * Math.Sqrt(3) / 4);
    }
}

internal class Quadrato(float lunghezzaLato) : Poligono(4, lunghezzaLato)
{
    /*
    L'area di un quadrato si calcola elevando al quadrato la lunghezza del lato, ovvero 
    moltiplicando il lato per se stesso
    */
    public override float GetArea()
    {
        return LunghezzaLato * LunghezzaLato;
    }
}

internal class Pentagono(float lunghezzaLato) : Poligono(5, lunghezzaLato)
{
    /*
    Per calcolare l'area di un pentagono regolare in C# partendo dal lato, la formula 
    più comune utilizza la costante fissa (pari a circa): 1.720477
    */
    public override float GetArea()
    {
        // La formula completa è: (5/4) * lato^2 * (1 / tan(π/5))
        // Che semplificata usa la costante 1.720477...
        double costantePentagono = 1.720477400588967;

        return (float)(LunghezzaLato * LunghezzaLato * costantePentagono);
    }
}

internal class Esagono(float lunghezzaLato) : Poligono(6, lunghezzaLato)
{
    /*
    Per l'esagono regolare, la formula dell'area è molto simile a quella del triangolo 
    equilatero, poiché un esagono è composto esattamente da 6 triangoli equilateri.
    */
    public override float GetArea()
    {
        return (float)((3 * Math.Sqrt(3) / 2) * LunghezzaLato * LunghezzaLato);
    }
}
