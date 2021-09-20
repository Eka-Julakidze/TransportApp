using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transport
{
   public class Train : Transport
    {
        public Train(string name, double speed):
            base(name,speed)
        {
            SpeedLimitReached += _OnSpeedLimitReached;
        }

        public override double IncreaseSpeed(double now)
        {
            Console.WriteLine($"\nSpeed of train was {Speed}");
            Console.WriteLine($"### Increasing speed of train by *{now}");
            Speed *= now;
            if (this.Speed > 250)
            {
                _OnSpeedLimitReached(this.TransportName,this.Speed);
            }

            return Speed;
        }

        protected void _OnSpeedLimitReached(object source, SpeedEventArgs e)
        {
            Console.WriteLine("The Train '{0}' is crashed since the speed was: {1}".ToUpper(), e.N, e.S);
        }


    }
}
