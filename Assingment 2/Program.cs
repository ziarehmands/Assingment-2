using System;
using System.Collections.Generic;

//Interface to impplmenet different individual components of Car
public interface IComponent{}

//Concrete implement of different implementation of different component of the car
public class Seats : IComponent
{
    public int noOfSeats { get; set; }

    public Seats(int seat)
    {
        noOfSeats = seat;
    }
}

public class Engine : IComponent
{
    public string Type { get; set; }

    public Engine(string type = "Gasoline")
    {
        Type = type;
    }
}

public class Doors : IComponent
{
    public int Number { get; set; }

    public Doors(int number = 4)
    {
        Number = number;
    }
}

public class Multimedia : IComponent
{
    public string Type { get; set; }

    public Multimedia(string type = "Basic")
    {
        Type = type;
    }
}

public class Suspension : IComponent
{
    public string Type { get; set; }

    public Suspension(string type = "Standard")
    {
        Type = type;
    }
}

public class ElectricalSystem : IComponent
{
    public string Type { get; set; }

    public ElectricalSystem(string type = "12V")
    {
        Type = type;
    }
}

//Car class consisting of different componets 
public class Car
{
    public Seats Seats { get; set; }
    public Engine Engine { get; set; }
    public Doors Doors { get; set; }
    public Multimedia Multimedia { get; set; }
    public Suspension Suspension { get; set; }
    public ElectricalSystem ElectricalSystem { get; set; }

    public Car(int seats, string engine, int doors, string multimedia, string suspension, string electricalSystem)
    {
        Seats = new Seats(seats);
        Engine = new Engine(engine);
        Doors = new Doors(doors);
        Multimedia = new Multimedia(multimedia);
        Suspension = new Suspension(suspension);
        ElectricalSystem = new ElectricalSystem(electricalSystem);
    }

    //Converting different component of the car to a string.
    public void DisplayCarInformaion()
    {
        Console.WriteLine($"Car with {Seats.noOfSeats} seats, {Engine.Type} engine, {Doors.Number} doors, {Multimedia.Type} multimedia, {Suspension.Type} suspension, and {ElectricalSystem.Type} electrical system.");
    }

}

/// <summary>
/// Car Factory class to create object of car based on differnt properteis of differnt component of car
/// By using Static it is ensured that signle object of Carfactory will be created througout the program.
/// </summary>
public class CarFactory
{
    private static CarFactory _instance;

    private List<Car> _cars = new List<Car>();
    private CarFactory() { }

    public static CarFactory Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new CarFactory();
            }
            return _instance;
        }
    }

    //Create a new car component by calling constructor of car class and return it. 
    public void CreateCar(int seats = 5, string engine = "Standard Engine", int doors = 4, string multimedia = "Basic Multimedia", string suspension = "Standard Suspension", string electricalSystem = "Basic Electrical System")
    {
        Car newCar = new Car(seats, engine, doors, multimedia, suspension, electricalSystem);

        _cars.Add(newCar);
    }

    public List<Car> GetAllCars()
    {
        return _cars;
    }

    public void GetAllCarsInformation()
    {
        for (int i = 0; i < _cars.Count; i++)
        {
            _cars[i].DisplayCarInformaion();
        }
    }

    public int GetCarCounts()
    {
        return _cars.Count;
    }

}

class Program
{
    static void Main(string[] args)
    {
        CarFactory factory = CarFactory.Instance;

        factory.CreateCar();
        factory.CreateCar(seats: 2, engine: "Sport Engine", doors: 2, multimedia: "Advanced Multimedia");
        Console.WriteLine("Total Number of Car: " + factory.GetCarCounts() + "\n");

        factory.GetAllCarsInformation();

    }
}
