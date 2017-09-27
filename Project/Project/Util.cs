using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using System.IO;

namespace Util
{
    public class FileWork
    {
        private const string fileName = "file.txt";
        public void WriteAllToFile(List<Transport> list)
        {
            StreamWriter sw = new StreamWriter(fileName, true);
            foreach (Transport t in list)
            {
                sw.WriteLine(t.infoToWrite());
            }
            sw.Close();
        }

        public List<Transport> readAllFromFile()
        {
            List<Transport> result = new List<Transport>();

            string[] fromFile = File.ReadAllLines(fileName);

            foreach (string s in fromFile)
            {
                string[] items = s.Split('\t');

                switch (items[1])
                {
                    case "Car":
                        {
                            result.Add(getCarObject(items));
                            break;
                        }

                    case "AirPlane":
                        {
                            result.Add(getPlaneObject(items));
                            break;
                        }

                    case "Ship":
                        {
                            result.Add(getShipObject(items));
                            break;
                        }
                    case "Train":
                        {
                            result.Add(getTrainObject(items));
                            break;
                        }
                    case "Bike":
                        {
                            result.Add(getBikeObject(items));
                            break;
                        }
                }
            }

            return result;
        }

        private Car getCarObject(string[] items)
        {
            Car car = new Car();

            car.Manufactor = items[2];
            car.Speed = int.Parse(items[3]);
            car.Width = double.Parse(items[4]);
            car.Height = double.Parse(items[5]);
            car.Engine = getEngine(items);
            car.Amount = int.Parse(items[10]);
            car.Transmisson = items[11];
            car.Body = items[12];

            Console.WriteLine(car.getInformation());

            return car;
        }

        private AirPlane getPlaneObject(string[] items)
        {
            AirPlane plane = new AirPlane();

            plane.Manufactor = items[2];
            plane.Speed = int.Parse(items[3]);
            plane.Width = double.Parse(items[4]);
            plane.Height = double.Parse(items[5]);
            plane.Engine = getEngine(items);
            plane.Amount = int.Parse(items[10]);
            plane.WingSpan = double.Parse(items[11]);
            plane.TakeOffWeight = double.Parse(items[12]);

            Console.WriteLine(plane.getInformation());

            return plane;
        }

        private Ship getShipObject(string[] items)
        {
            Ship ship = new Ship();

            ship.Manufactor = items[2];
            ship.Speed = int.Parse(items[3]);
            ship.Width = double.Parse(items[4]);
            ship.Height = double.Parse(items[5]);
            ship.Engine = getEngine(items);
            ship.Amount = int.Parse(items[10]);
            ship.Displacement = double.Parse(items[11]);
            ship.NavigationArea = items[12];

            Console.WriteLine(ship.getInformation());

            return ship;
        }

        private Train getTrainObject(string[] items)
        {
            Train train = new Train();

            train.Manufactor = items[2];
            train.Speed = int.Parse(items[3]);
            train.Width = double.Parse(items[4]);
            train.Height = double.Parse(items[5]);
            train.Engine = getEngine(items);
            train.Amount = int.Parse(items[10]);
            train.RollingStock = items[11];
            train.Regular = items[12];

            Console.WriteLine(train.getInformation());

            return train;
        }

        private Bike getBikeObject(string[] items)
        {
            Bike bike = new Bike();

            bike.Manufactor = items[2];
            bike.Speed = int.Parse(items[3]);
            bike.Width = double.Parse(items[4]);
            bike.Height = double.Parse(items[5]);
            bike.Engine = getEngine(items);
            bike.Amount = int.Parse(items[10]);
            bike.Model = items[11];
            bike.Brakes = items[12];

            Console.WriteLine(bike.getInformation());

            return bike;
        }

        private Engine getEngine(string[] items)
        {
            Engine engine = null;

            switch (items[6])
            {
                case "PetrolEngine":
                    {
                        engine = getPetrolEngine(items);
                        break;
                    }

                case "ReactiveEngine":
                    {
                        engine = getReactiveEngine(items);
                        break;
                    }

                case "Disel":
                    {
                        engine = getDisel(items);
                        break;
                    }
            }

            return engine;
        }

        private PetrolEngine getPetrolEngine(string[] items)
        {
            PetrolEngine petrolEngine = new PetrolEngine();

            petrolEngine.Power = int.Parse(items[7]);
            petrolEngine.Manufactor = items[8];
            petrolEngine.BlendingProcess = items[9];

            return petrolEngine;
        }

        private ReactiveEngine getReactiveEngine(string[] items)
        {
            ReactiveEngine reactiveEngine = new ReactiveEngine();

            reactiveEngine.Power = int.Parse(items[7]);
            reactiveEngine.Manufactor = items[8];
            reactiveEngine.Classes = items[9];

            return reactiveEngine;
        }

        private Disel getDisel(string[] items)
        {
            Disel diselEngine = new Disel();

            diselEngine.Power = int.Parse(items[7]);
            diselEngine.Manufactor = items[8];
            diselEngine.Construction = items[9];

            return diselEngine;
        }
    }

    public static class PrintWork
    {
        public static void printAll(List<Transport> list)
        {
            foreach (Transport t in list)
            {
                Console.WriteLine(t.getInformation());
            }
        }

        public static void printByCategory(List<Transport> list, string category)
        {
            foreach (Transport t in list)
            {

                if (category.Trim().Equals(t.GetType().Name))
                {
                    Console.WriteLine(t.getInformation());
                }
                // Console.WriteLine(t.getInformation());
            }

        }
    }

    public static class SortWork
    {
        public static void sortByModel(List<Transport> list)
        {
            list.Sort((l1, l2) => l1.Manufactor.CompareTo(l2.Manufactor));
        }

        public static void sortBySpeed(List<Transport> list)
        {
            list.Sort((l1, l2) => l1.Speed.CompareTo(l2.Speed));
        }

        public static void sortByCategory(List<Transport> list)
        {
            list.Sort((l1, l2) => l1.GetType().Name.CompareTo(l2.GetType().Name));
        }
    }

    public class SalesWork
    {
        public void sellItem(Transport transport, int amount)
        {
            int currentAmount = transport.Amount;
            if (amount < 0 || amount > currentAmount)
            {
                throw new ArithmeticException();
            }

            transport.Amount -= amount;
        }

        public void buyItem(Transport transport, int amount)
        {
            transport.Amount += amount;
        }
    }

    public class Menu
    {
        public void use()
        {
            SalesWork sr = new SalesWork();
            FileWork fw = new FileWork();
            List<Transport> workList = new List<Transport>();
            bool flag = true;
            bool readFromFileFlag = false;
            string choice;
            Console.WriteLine("Welcome to our system!!!");

            do
            {
                printMenu();
                choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        {
                            readFromFileItem(ref readFromFileFlag, workList, fw);
                            break;
                        }
                    case "2":
                        {
                            printAllInformationItem(workList);
                            break;
                        }
                }

            } while (flag);

        }

        private void printMenu()
        {
            Console.WriteLine("Make choice:");
            Console.WriteLine("1. Read all information from file");
            Console.WriteLine("2. Print all information");
            Console.WriteLine("3. Sorting: ");
            Console.WriteLine("3.1. \tSorting by model");
            Console.WriteLine("3.2. \tSorting by speed");
            Console.WriteLine("3.3. \tSorting by category");
            Console.WriteLine("4. Sell items");
            Console.WriteLine("5. Buy items");
            Console.WriteLine("6. Add new items");
            Console.WriteLine("0. Exit");
        }

        private void readFromFileItem(ref bool readFromFileFlag, List<Transport> workList, FileWork fw)
        {
            if (!readFromFileFlag)
            {
                workList.AddRange(fw.readAllFromFile());
                readFromFileFlag = true;
                Console.WriteLine("Database loaded");
            }
            else
            {
                Console.WriteLine("Database isup to data");
            }
        }

        private void printAllInformationItem(List<Transport> workList)
        {
            if (workList.Count == 0)
            {
                Console.WriteLine("List is empty");
            }
            else
            {
                PrintWork.printAll(workList);
            }
        }
    }
}