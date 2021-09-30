using System;
using System.Collections.Generic;
using System.Linq;
using TransportNameSpace;
using static TransportNameSpace.Transport;
using System.IO;

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
                }

                using (StreamWriter writer = File.CreateText(outputPath))
                {
                    writer.WriteLine("### OUTPUT DATA FOR ALL TRANSPORT ###");
                    foreach (var v in vehicles)
                    {
                        writer.Write(v.GetType().Name + " ");
                        writer.WriteLine(v.ToString());
                    }                  
                }

                using(StreamReader reader = File.OpenText(outputPath))
                {
                    Console.WriteLine("\n### READING OUTPUT DATA FOR ALL TRANSPORT ###");
                    Console.WriteLine(reader.ReadToEnd().ToString());
                }               
            }
            catch (IOException e)
            {
                Console.WriteLine("Error reading the file");
                Console.WriteLine(e.Message);
            }

           

           

        }
    }
}


