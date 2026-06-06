class WhatsAppNotification : INotificationService
{
    public void Send(string message)
    {
        Console.WriteLine("WhatsApp Sent: " + message);
    }
}
