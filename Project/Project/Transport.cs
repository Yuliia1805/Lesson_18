using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    
        public abstract class Transport
        {
            protected int speed;
            protected string manufacturer;
            protected double weight;
            protected double height;
            protected Engine engine;
            protected int amount;

            public Transport()
            {
                manufacturer = "unknown";
            }

            public Transport(int speed, string manufacturer, double weight, double height, Engine engine, int amount)
            {
                this.speed = speed;
                this.manufacturer = manufacturer;
                this.weight = weight;
                this.height = height;
                this.engine = engine;
                this.amount = amount;

            }

            public int Speed
            {
                get
                {
                    return speed;
                }
                set
                {
                    speed = value;
                }
            }
            public string Manufacturer
            {
                get
                {
                    return manufacturer;
                }
                set
                {
                    manufacturer = value;
                }
            }
            public double Weight
            {
                get
                {
                    return weight;
                }
                set
                {
                    weight = value;
                }
            }
            public double Height
            {
                get
                {
                    return height;
                }
                set
                {
                    height = value;
                }
            }
            public Engine Egine
            {
                get
                {
                    return engine;
                }
                set
                {
                    engine = value;
                }
            }
            public int Amount
            {
                get
                {
                    return amount;
                }
                set
                {
                    amount = value;
                }
            }

            public string getInformation()
            {
                return "Manufacturer: " + manufacturer
                    + "  , speed: " + speed
                    + " , weight: " + weight
                    + " , height: " + height
                    + " , engine: " + engine.getInformation()
                    + " , amount: " + amount;
            }


        }

        public abstract class WaterTransport : Transport
        {
            public WaterTransport() : base()
            {

            }
            public WaterTransport(int speed, string manufacturer, double weight, double height, Engine engine, int amount) : base(speed, manufacturer, weight, height, engine, amount)
            {

            }


        }

        public abstract class AirTransport : Transport
        {
            public AirTransport() : base()
            {

            }
            public AirTransport(int speed, string manufacturer, double weight, double height, Engine engine, int amount) : base(speed, manufacturer, weight, height, engine, amount)
            {

            }
        }

        public abstract class LandTransport : Transport
        {
            public LandTransport() : base()
            {

            }
            public LandTransport(int speed, string manufacturer, double weight, double height, Engine engine, int amount) : base(speed, manufacturer, weight, height, engine, amount)
            {

            }

        }

        public class Car : LandTransport
        {
            private string transmission;
            private string body;

            public Car() : base()
            {
                transmission = "unknown";
                body = "unknown";
            }
            public Car(int speed, string manufacturer, double weight, double height, Engine engine, int amount, string transmission, string body) : base(speed, manufacturer, weight, height, engine, amount)
            {
                this.transmission = transmission;
                this.body = body;

            }

            public string Transmission
            {
                get
                {
                    return transmission;
                }
                set
                {
                    transmission = value;
                }
            }
            public string Body
            {
                get
                {
                    return body;
                }
                set
                {
                    body = value;
                }
            }
        }

    public class Airplane : AirTransport
    {
        private string planebody;
        private string wings;


        public Airplane() : base()
        {
            planebody = "unknown";
            wings = "unknown";

        }

        public Airplane(int speed, string manufacturer, double weight, double height, Engine engine, int amount, string planebody, string wings) : base(speed, manufacturer, weight, height, engine, amount)
        {
            this.planebody = planebody;
            this.wings = wings;
        }
        public string Planebody
        {
            get
            {
                return planebody;
            }
            set
            {
                planebody = value;
            }
        }
        public string Wings
        {
            get
            {
                return wings;
            }
            set
            {
                wings = value;
            }
        }
    }

    public class Ship : WaterTransport
    {
        private string shipbody;

        public Ship() : base()
        {
            shipbody = "unknown";
        }

        public Ship(int speed, string manufacturer, double weight, double height, Engine engine, int amount, string shipbody) : base(speed, manufacturer, weight, height, engine, amount)
        {
            this.shipbody = shipbody;
        }
        public string Shipbody
        {
            get
            {
                return shipbody;
            }
            set
            {
                shipbody = value;
            }
        }
    }

    public class Train : LandTransport
    {
        private string loadtype;
        private string distance;

        public Train() : base()
        {
            loadtype = "unknown";
            distance = "unknown";
        }

        public Train(int speed, string manufacturer, double weight, double height, Engine engine, int amount, string loadtype, string distance) : base(speed, manufacturer, weight, height, engine, amount)
        {
            this.loadtype = loadtype;
            this.distance = distance;
        }

        public string Loadtype
        {
            get
            {
                return loadtype;
            }
            set
            {
                loadtype = value;
            }
        }

        public string Distance
        {
            get
            {
                return distance;
            }
            set
            {
                distance = value;
            }
        }
    }
    public class Bike : LandTransport
  {
        private string bodytype;

        public Bike() : base()
        {
            bodytype = "unknown";
        }

        public Bike(int speed, string manufacturer, double weight, double height, Engine engine, int amount, string bodytype) : base(speed, manufacturer, weight, height, engine, amount)
        {
            this.bodytype = bodytype;

        }
        public string Bodytype
        {
            get
            {
                return bodytype;
            }
            set
            {
                bodytype = value;
            }
        }
    }
        public abstract class Engine
        {
            protected int power;
            protected string manufacturer;

            public Engine()
            {
                manufacturer = "unknown";
            }
            public Engine(int power, string manufacturer)
            {
                this.power = power;
                this.manufacturer = manufacturer;
            }

            public int Power
            {
                get
                {
                    return power;
                }
                set
                {
                    power = value;
                }
            }
            public string Manufacturer
            {
                get
                {
                    return manufacturer;
                }
                set
                {
                    manufacturer = value;
                }
            }

            public string getInformation()
            {
                return "Power: " + power
                    + " , manufacturer: " + manufacturer;
            }
        }

        public class PetrolEngine : Engine
        {

        }

        public class Disel : Engine
        {

        }

        public class ReactiveEngine : Engine
        {

        }
}
