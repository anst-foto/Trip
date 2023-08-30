using Trip;

var train = new Train(
    route: "Москва - Нью Васюки",
    numberOfEconomWagonType: 2,
    numberOfDeluxWagonType: 1
    );

var passenger = new Passenger()
{
    FirstName = "F",
    LastName = "FF"
};

var result = false;
var score = 0;
do
{
    result = train.AddPassenger(WagonType.Lux, 100, passenger);
    if (!result)
    {
        score++;
    }
} while (!result && score < 3); // НЕ true ИЛИ меньше 3

Console.WriteLine($"{passenger.FullName} - такого вагона и места нет в поезде");