class EmailAlert : IAlertService
{
    public void Send(string message)
    {
        Console.WriteLine("Email Sent: " + message);
    }
}
