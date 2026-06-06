// Case Study 3: Ride-Sharing Application (Like Uber/Ola)
// Scenario
// The application handles:
// •	Ride Booking
// •	Driver Assignment
// •	Payment
// •	Notifications
// •	Trip Reports
// ________________________________________

// Activity Questions
// 1.	Add a LuxuryRide fare calculator.
// 2.	Add WhatsApp notification support.
// 3.	Add BikeRide and AutoRide classes without modifying existing code.
// 4.	Implement Dependency Injection for NotificationService.

using System;

class RideSharingApplication
{
    static void Main()
    {
        Console.WriteLine("===== RIDE SHARING APPLICATION =====");

        Console.Write("Enter Distance (km): ");
        double distance = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("\nSelect Ride Type:");
        Console.WriteLine("1. Normal Ride");
        Console.WriteLine("2. Luxury Ride");
        Console.WriteLine("3. Bike Ride");
        Console.WriteLine("4. Auto Ride");
        Console.Write("Enter your choice(Enter a Number): ");
        int choice = Convert.ToInt32(Console.ReadLine());

        IRide ride = null;
        string rideType = "";

        switch (choice)
        {
            case 1:
                ride = new NormalRide();
                rideType = "Normal Ride";
                break;

            case 2:
                ride = new LuxuryRide();
                rideType = "Luxury Ride";
                break;

            case 3:
                ride = new BikeRide();
                rideType = "Bike Ride";
                break;

            case 4:
                ride = new AutoRide();
                rideType = "Auto Ride";
                break;

            default:
                Console.WriteLine("Invalid choice");
                return;
        }

        double fare = ride.CalculateFare(distance);

        PaymentService payment = new PaymentService();
        payment.Pay(fare);

        Console.WriteLine("\n1. Email");
        Console.WriteLine("2. SMS");
        Console.WriteLine("3. WhatsApp");
        Console.Write("Select Notification Type: ");
        int notify = Convert.ToInt32(Console.ReadLine());

        INotificationService service = null;

        if (notify == 1)
            service = new EmailNotification();
        else if (notify == 2)
            service = new SMSNotification();
        else
            service = new WhatsAppNotification();

        NotificationManager manager = new NotificationManager(service);
        manager.Notify("Ride Booked Successfully. Happy Journey.");

        TripReport report = new TripReport();
        report.Generate(rideType, fare);
    }
}
