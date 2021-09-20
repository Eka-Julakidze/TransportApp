using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportNameSpace
{
    public class SpeedEventArgs : EventArgs
    {
        public string N { get; set; }
        public double S { get; set; }   
    }
}
