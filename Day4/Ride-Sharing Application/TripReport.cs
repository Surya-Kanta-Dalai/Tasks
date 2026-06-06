class TripReport
{
    public void Generate(string rideType, double fare)
    {
        Console.WriteLine("\n---- TRIP REPORT ----");
        Console.WriteLine($"Ride Type: {rideType}");
        Console.WriteLine($"Total Fare: ₹{fare}");
    }
}
