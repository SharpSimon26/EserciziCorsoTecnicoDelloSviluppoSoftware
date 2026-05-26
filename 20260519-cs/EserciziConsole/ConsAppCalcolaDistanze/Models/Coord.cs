namespace ConsAppCalcolaDistanze.Models;

public class Coord
{
    public double Lat { get; init; } 
    public double Lng { get; init; }
    public double Elev { get; init; }

    public double Distance(Coord other)
    {
        return Services.Distance.DistanceInMeters(Lat, Lng, other.Lat, other.Lng);
    }
}