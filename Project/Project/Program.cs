using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    class Program
    {
        static void Main(string[] args)
        {
            Transport car = new Car();
            // Console.WriteLine(car.getInformation());

            Transport plane = new Airplane();
            //Console.WriteLine(plane.getInformation());

            List<Transport> list = new List<Transport>();
            list.Add(car);
            list.Add(plane);

            foreach (Transport t in list)
            {
                //    Console.WriteLine(t.infoToWrite());
            }

            Filework fw = new Filework();
            //fw.writeAllTofile(list);
            fw.readAllFromFile();


            Console.ReadLine();
        }
    }
}
