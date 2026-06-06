class AlertManager
{
    private IAlertService _alert;

    public AlertManager(IAlertService alert)
    {
        _alert = alert;
    }

    public void Notify(string message)
    {
        _alert.Send(message);
    }
}
