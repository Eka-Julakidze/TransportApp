using System;

namespace TransportNameSpace
{
    public abstract class Transport
    {
        public static int NumberOfTransportCrash { get; set; }
        public string TransportName { get; set; }
        public double Speed { get; set; }

        public Transport(string name, double speed)
        {
            TransportName = name;
            Speed = speed;
        }

        protected event EventHandler<SpeedEventArgs> SpeedLimitReached; // virtual event

        public abstract double IncreaseSpeed(double now);

        protected abstract void _OnSpeedLimitReached(object source, SpeedEventArgs e);
       
        public override string ToString()
        {
            return $"This is: {this.TransportName}, The Speed is: {this.Speed}";
        }






    }
}
