using System;

interface IVehicle
{
    int MaxSpeed { get; set; }
    void Start();
    void Stop();
}

class Car : IVehicle
{  
    public int MaxSpeed { get; set; }
 
    public int NumberOfDoors { get; set; }

    public Car(int maxSpeed, int numberOfDoors)
    {
        MaxSpeed = maxSpeed;
        NumberOfDoors = numberOfDoors;
    }

    public void Start()
    {
        Console.WriteLine("Samochód uruchomiony.");
    }

    public void Stop()
    {
        Console.WriteLine("Samochód zatrzymany.");
    }
}

class Bike : IVehicle
{
 
    public int MaxSpeed { get; set; }
 
    public bool HasBell { get; set; }

    public Bike(int maxSpeed, bool hasBell)
    {
        MaxSpeed = maxSpeed;
        HasBell = hasBell;
    }

    public void Start()
    {
        Console.WriteLine("Rower jedzie.");
    }

    public void Stop()
    {
        Console.WriteLine("Rower zatrzymany.");
    }

    public void RingBell()
    {
        if (HasBell)
            Console.WriteLine("Dzwonek roweru: Ding Ding");
        else
            Console.WriteLine("Rower nie ma dzwonka.");
    }
}
