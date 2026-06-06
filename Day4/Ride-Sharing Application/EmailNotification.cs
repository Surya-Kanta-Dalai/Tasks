class EmailNotification : INotificationService
{
    public void Send(string message)
    {
        Console.WriteLine("Email Sent: " + message);
    }
}
