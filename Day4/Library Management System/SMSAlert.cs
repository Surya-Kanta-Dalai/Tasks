class SMSAlert : IAlertService
{
    public void Send(string message)
    {
        Console.WriteLine("SMS Sent: " + message);
    }
}
