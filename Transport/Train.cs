using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportNameSpace
{
   public class Train : Transport
    {
        public Train(string name, double speed):
            base(name,speed)
        {
            SpeedLimitReached += _OnSpeedLimitReached;

            if(this.Speed > 250)
            {
                Console.WriteLine($"Train Name: {this.TransportName}, Train Speed: {this.Speed}. Already has high speed...");
                _OnSpeedLimitReached(this, new SpeedEventArgs { N = this.TransportName, S = this.Speed });
                Console.WriteLine();
            }
        }

        public override double IncreaseSpeed(double now)
        {
            Console.WriteLine($"\nSpeed of train was {Speed}");
            Console.WriteLine($"### Increasing speed of train by *{now}");
            Speed *= now;
            if (this.Speed > 250)
            {
                _OnSpeedLimitReached(this, new SpeedEventArgs {N=this.TransportName, S=this.Speed});
            }

            return Speed;
        }

        protected override void _OnSpeedLimitReached(object source, SpeedEventArgs e)
        {
            NumberOfTransportCrash++;
            Console.WriteLine("{0}. The Train '{1}' is crashed since the speed was: {2}".ToUpper(), NumberOfTransportCrash, e.N, e.S);
        }


    }
}
