public class CashPayment : IPaymentService
{
    public void Pay(double amount)
    {
        Console.WriteLine("Paid ₹" + amount + " using Cash");
    }
}
