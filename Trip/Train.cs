namespace Trip;

/*public class Train
{
    private static void AddWagons(ICollection<Wagon> wagons, uint numberOfWagons, WagonType type)
    {
        for (int i = 0; i < numberOfWagons; i++)
        {
            wagons.Add(new Wagon(type));
        }
    }
    public string Route { get; init; }

    public List<Wagon> Wagons { get; init; }

    public Train(string route, uint numberOfEconomWagonType = 0, uint numberOfDeluxWagonType = 0, uint numberOfLuxWagonType = 0)
    {
        Route = route;

        var size = numberOfEconomWagonType + numberOfDeluxWagonType + numberOfLuxWagonType;
        Wagons = new List<Wagon>((int)size);
        AddWagons(Wagons, numberOfEconomWagonType, WagonType.Econom);
        AddWagons(Wagons, numberOfDeluxWagonType, WagonType.Delux);
        AddWagons(Wagons, numberOfLuxWagonType, WagonType.Lux);
    }

    public bool AddPassenger(WagonType type, uint place, Passenger passenger)
    {
        foreach (var wagon in Wagons)
        {
            if (wagon.Type == type)
            {
                if (wagon.AddPassenger(place, passenger))
                {
                    return true;
                }
            }
        }

        return false;
    }
}*/
public class Train
{
    private static void AddWagons(ICollection<Wagon> wagons, uint numberOfWagons, WagonType type)
    {
        for (int i = 0; i < numberOfWagons; i++)
        {
            wagons.Add(new Wagon(type));
        }
    }
    public string Route { get; init; }

    public Dictionary<WagonType, List<Wagon>> Wagons { get; init; }

    public Train(string route, uint numberOfEconomWagonType = 0, uint numberOfDeluxWagonType = 0, uint numberOfLuxWagonType = 0)
    {
        Route = route;
        
        
        var economWagons = new List<Wagon>((int)numberOfEconomWagonType);
        AddWagons(economWagons, numberOfEconomWagonType, WagonType.Econom);
        
        var deluxWagons = new List<Wagon>((int)numberOfEconomWagonType);
        AddWagons(deluxWagons, numberOfDeluxWagonType, WagonType.Delux);
        
        var luxWagons = new List<Wagon>((int)numberOfEconomWagonType);
        AddWagons(luxWagons, numberOfLuxWagonType, WagonType.Lux);
        
        Wagons = new Dictionary<WagonType, List<Wagon>>
        {
            { WagonType.Econom, economWagons },
            { WagonType.Delux, deluxWagons },
            { WagonType.Lux, luxWagons }
        };
    }

    public bool AddPassenger(WagonType type, uint place, Passenger passenger)
    {
        var wagons = Wagons[type];
        foreach (var wagon in wagons)
        {
            if (wagon.AddPassenger(place, passenger))
            {
                return true;
            }
        }

        return false;
    }
}