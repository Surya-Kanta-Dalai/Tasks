public class CreditCardPayment : IPaymentService
{
    public void Pay(double amount)
    {
        Console.WriteLine("Paid ₹" + amount + " using Credit Card");
    }
}
