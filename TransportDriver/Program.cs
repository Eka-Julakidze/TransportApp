using System;
using System.Collections.Generic;
using TransportNameSpace;
using static TransportNameSpace.Transport;
using System.IO;
using System.Linq;
using System.Threading;

namespace TransportDriver
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Transport> vehicles = new List<Transport>();
            string inputPath = @"C:\Users\ejulakidze\source\repos\TransportApp\input_data.csv.txt";
            string outputPath = @"C:\Users\ejulakidze\source\repos\TransportApp\output_data.txt";
            //char transportType;
            string name;
            double speed;

            try
            {
                using (StreamReader reader = File.OpenText(inputPath))
                {
                    // Read transport data from input file
                    Console.WriteLine("Reading data from input_data.csv.txt ...");
                    Thread.Sleep(3000);

                    string s;
                    while ((s = reader.ReadLine()) != null)
                    {
                        name = s.Substring(2, s.LastIndexOf(',')-2);
                        speed = Convert.ToDouble(s.Substring(s.LastIndexOf(',') + 1));
                        if (s[0] == 'T')
                        {

                            vehicles.Add(new Train(s[0], name, speed));
                        }
                        else
                        {
                            vehicles.Add(new Buss(s[0], name, speed));                           
                        }
                        
                    }
                    Console.WriteLine("### reading: DONE");
                    Console.WriteLine("\n### ALL THE VEHICLES ###");
                    foreach (var vehicle in vehicles)
                    {
                        Console.WriteLine(vehicle.ToString());
                    }
                }

                Console.WriteLine("\n### FILTERING DATA FOR HIGH SPEED VEHICLES ...");
                Thread.Sleep(2000);
                // look for high speed trains and busses
                vehicles = vehicles.Where(x =>
                (x.TransportType == 'T' && x.Speed > 250) || // train
                (x.TransportType == 'B' && x.Speed > 80)).ToList(); // buss
                Console.WriteLine("### filtering: DONE");

                // write data about high speed vehicles into a new file
                Console.WriteLine("\n### Writing filtered data to output_data.txt ...");
                Thread.Sleep(3000);
                using (StreamWriter writer = File.CreateText(outputPath))
                {
                    //writer.WriteLine("### OUTPUT DATA For HIGH SPEED###");
                    foreach (var v in vehicles)
                    {
                        writer.Write(v.GetType().Name + " ");
                        writer.WriteLine(v.ToString());
                    }                  
                }
                Console.WriteLine("### writing: DONE");

                // print out the data from newly created file to the console
                using (StreamReader reader = File.OpenText(outputPath))
                {
                    Console.WriteLine("\n### READING FROM output_data.txt; THESE ARE HIGH SPEED VEHICLES ONLY ###");
                    Thread.Sleep(2500);
                    Console.WriteLine(reader.ReadToEnd().ToString());
                    Console.WriteLine("### reading: DONE");
                }               
            }
            catch (IOException e)
            {
                Console.WriteLine("Error reading the file");
                Console.WriteLine(e.Message);
            }
            catch(ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }

            




        }
    }
}


