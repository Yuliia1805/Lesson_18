using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Util;

namespace Project
{
    class Program
    {
        static void Main(string[] args)
        {
            Transport car = new Car();
            //  Console.WriteLine(car.getInformation());

            Transport plane = new AirPlane();
            //  Console.WriteLine(plane.getInformation());
            Transport ship = new Ship();
            Transport train = new Train();
            Transport bike = new Bike();

            List<Transport> list = new List<Transport>();
            list.Add(car);
            list.Add(plane);
            list.Add(ship);
            list.Add(train);
            list.Add(bike);

            foreach (Transport t in list)
            {
                //     Console.WriteLine(t.infoToWrite());
            }
            /* foreach (Transport t in list)
             {
                 Console.WriteLine(t.getInformation());
             }*/

            FileWork fw = new FileWork();
            //fw.WriteAllToFile(list);
            //fw.readAllFromFile();

            PrintWork.printByCategory(list, "   Car"); //  Thank for Trim(); - he deletes spaces

            Console.ReadLine();
        }
    }
}