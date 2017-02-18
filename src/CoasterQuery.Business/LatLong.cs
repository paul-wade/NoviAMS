namespace CoasterQuery.Business
{
    public struct LatLong
    {
        private readonly double _latitude;
        private readonly double _longitute;

        public double latitude => _latitude;
        public double Longitude => _longitute;

        public LatLong(double latitude, double longitude)
        {
            _latitude = latitude;
            _longitute = longitude;
        }
    }
}