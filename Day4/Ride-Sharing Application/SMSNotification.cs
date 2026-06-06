class SMSNotification : INotificationService
{
    public void Send(string message)
    {
        Console.WriteLine("SMS Sent: " + message);
    }
}
