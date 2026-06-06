public class DebitCardPayment : IPaymentService
{
    public void Pay(double amount)
    {
        Console.WriteLine("Paid ₹" + amount + " using Debit Card");
    }
}
