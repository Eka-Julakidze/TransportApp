using System;
using Transport;
using static Transport.Transport;

namespace TransportDriver
{

    class Program
    {
        static void Main(string[] args)
        {           
            var trainA = new Train("A", 80);
            trainA.IncreaseSpeed(1); // no event
            trainA.IncreaseSpeed(4); // raise event
                                     //Console.WriteLine(trainA.ToString()+"\n"); 
                                      
            Console.WriteLine();

            var bussB = new Buss("B", 50);
            bussB.IncreaseSpeed(2); // no event
            bussB.IncreaseSpeed(50); // raise event
            //Console.WriteLine(bussB.ToString());
      
        }
    }
}
