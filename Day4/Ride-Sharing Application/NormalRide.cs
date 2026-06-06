class NormalRide : IRide
{
    public double CalculateFare(double distance)
    {
        return distance * 10;
    }
}
