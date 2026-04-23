using ConsAppVeicoli;

IVeicolo moto = new Moto();
Console.WriteLine("Moto: vel max {0}", moto.GetVelocitaMax());
if (moto is ICaricabile m2)
{
    Console.WriteLine("Capacità di carico: {0}", m2.GetCapacitaCarico());
}

Console.WriteLine();

IVeicolo auto = new Auto();
Console.WriteLine("Auto: vel max {0}", auto.GetVelocitaMax());
if (auto is ICaricabile a2)
{
    Console.WriteLine("Capacità di carico: {0}", a2.GetCapacitaCarico());
}

Console.WriteLine();

IVeicolo camion = new Camion();
Console.WriteLine("Camion: vel max {0}", camion.GetVelocitaMax());
if (camion is ICaricabile c2)
{
    Console.WriteLine("Capacità di carico: {0}", c2.GetCapacitaCarico());
}

Console.WriteLine();