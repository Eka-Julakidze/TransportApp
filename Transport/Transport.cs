using System;

namespace TransportNameSpace
{
    public abstract class Transport
    {
        public static int NumberOfTransportCrash { get; set; }
        public char TransportType { get; set; }
        public string TransportName { get; set; }
        public double Speed { get; set; }

        public Transport(char transportType, string name, double speed)
        {
            TransportType = transportType;
            TransportName = name;
            Speed = speed;
        }

        protected event EventHandler<SpeedEventArgs> SpeedLimitReached; // virtual event

        public abstract double IncreaseSpeed(double now);

        protected abstract void _OnSpeedLimitReached(object source, SpeedEventArgs e);
       
        public bool HasGreaterOrEqualSpeed(Transport other)
        {
            return this.Speed >= other.Speed ? true : false;
        }

        public override string ToString()
        {
            return $"Name: {this.TransportName}, Speed: {this.Speed}";
        }
    }
}
