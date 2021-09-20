using System;

namespace TransportNameSpace
{
    public abstract class Transport
    {
        public string TransportName { get; set; }
        public double Speed { get; set; }

        public Transport(string name, double speed)
        {
            TransportName = name;
            Speed = speed;
        }

        protected event EventHandler<SpeedEventArgs> SpeedLimitReached; // virtual event

        public abstract double IncreaseSpeed(double now);

        protected virtual void _OnSpeedLimitReached(string name, double speed)
        {
            if (SpeedLimitReached != null)
            {
                SpeedLimitReached(this, new SpeedEventArgs { S = speed, N = name});
            }
        }

        public override string ToString()
        {
            return $"This is: {this.TransportName}, The Speed is: {this.Speed}";
        }






    }
}
