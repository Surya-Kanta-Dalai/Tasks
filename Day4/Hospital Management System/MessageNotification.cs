public class MessageNotification : INotificationService
{
    public void Send()
    {
        Console.WriteLine("Sending Message...\nMessage Sent: Your report is ready");
    }
}
