class NotificationManager
{
    private INotificationService _service;

    public NotificationManager(INotificationService service)
    {
        _service = service;
    }

    public void Notify(string msg)
    {
        _service.Send(msg);
    }
}
