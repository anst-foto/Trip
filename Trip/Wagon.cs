namespace Trip;

public enum WagonType
{
    Econom, Delux, Lux
}

public class Wagon
{
    public static Dictionary<WagonType, int> WagonDictionary = new Dictionary<WagonType, int>
    {
        { WagonType.Econom, 54},
        { WagonType.Delux, 36},
        { WagonType.Lux, 16}
    };
    
    public  WagonType Type { get; init; }
    public int NumberOfPassenger { get; init; }
    public Dictionary<uint, Passenger?> Passengers { get; init; }

    public Wagon(WagonType type)
    {
        Type = type;
        NumberOfPassenger = WagonDictionary[Type];
        Passengers = new Dictionary<uint, Passenger?>(NumberOfPassenger);
        for (uint i = 1; i <= NumberOfPassenger; i++)
        {
            Passengers.Add(i, null);
        }
    }

    public bool AddPassenger(uint place, Passenger passenger)
    {
        if (place < 1 || place > NumberOfPassenger)
        {
            return false;
        }

        if (Passengers[place] is not null)
        {
            return false;
        }

        Passengers[place] = passenger;
        return true;
    }
}