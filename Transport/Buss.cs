using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transport
{
    public class Buss: Transport
    {
        public Buss(string name, double speed)
            :base(name,speed)
        {
            SpeedLimitReached += _OnSpeedLimitReached;
        }

        public override double IncreaseSpeed(double now)
        {
            Console.WriteLine($"\nSpeed of buss was {Speed}");
            Console.WriteLine($"### Increasing speed of buss by +{now}");
            Speed += now;
            if (Speed > 80)
            {
                _OnSpeedLimitReached(this.TransportName, this.Speed);
            }
            return Speed;
        }

        protected void _OnSpeedLimitReached(object source, SpeedEventArgs e)
        {
            Console.WriteLine("The Buss '{0}' is crashed since the speed was: {1}".ToUpper(), e.N, e.S);
        }

        
    }
}
