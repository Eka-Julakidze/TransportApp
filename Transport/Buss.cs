using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportNameSpace
{
    public class Buss: Transport
    {
        public Buss(char transportType, string name, double speed)
            :base(transportType,name,speed)
        {
            SpeedLimitReached += _OnSpeedLimitReached;

            if(this.Speed > 80)
            {
                Console.WriteLine($"Buss Name: {this.TransportName}, Buss Speed: {this.Speed}. Already has high speed...");
                _OnSpeedLimitReached(this, new SpeedEventArgs{ N = this.TransportName, S=this.Speed});
                Console.WriteLine();
            }
        }

        public override double IncreaseSpeed(double now)
        {
            Console.WriteLine($"\nSpeed of buss was {Speed}");
            Console.WriteLine($"### Increasing speed of buss by +{now}");
            Speed += now;

            if (Speed > 80)
            {
                _OnSpeedLimitReached(this, new SpeedEventArgs { N=this.TransportName, S=this.Speed});
            }
            return Speed;
        }

        protected override void _OnSpeedLimitReached(object source, SpeedEventArgs e)
        {
            NumberOfTransportCrash++;
            Console.WriteLine("{0}. The Buss '{1}' is crashed since the speed was: {2}".ToUpper(),NumberOfTransportCrash, e.N, e.S);
        }

        
    }
}
