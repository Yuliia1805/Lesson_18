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
        public Engine Engine
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

        public virtual string getInformation()
        {
            return "Manufacturer: " + manufacturer
                + "  , speed: " + speed
                + " , weight: " + weight
                + " , height: " + height
                + " , engine: " + engine.getInformation()
                + " , amount: " + amount;
        }

        public virtual string infoToWrite()
        {
            return manufacturer + "\t"
                + speed + "\t"
                + weight + "\t"
                + height + "\t"
                + engine.infoToWrite() + "\t"
                + amount + "\t";
        }


    }

    public abstract class WaterTransport : Transport
    {
        public WaterTransport() : base()
        {
            engine = new Disel();
        }
        public WaterTransport(int speed, string manufacturer, double weight, double height, Engine engine, int amount) : base(speed, manufacturer, weight, height, engine, amount)
        {

        }


    }

    public abstract class AirTransport : Transport
    {
        public AirTransport() : base()
        {
            engine = new ReactiveEngine();
        }
        public AirTransport(int speed, string manufacturer, double weight, double height, Engine engine, int amount) : base(speed, manufacturer, weight, height, engine, amount)
        {

        }
    }

    public abstract class LandTransport : Transport
    {
        public LandTransport() : base()
        {
            engine = new PetrolEngine();
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
        public override string getInformation()
        {
            return base.getInformation()
                + ", transmission: " + transmission
                + ", body: " + body;
        }
        public override string infoToWrite()
        {
            return this.GetType().BaseType.Name + "\t"
                 + this.GetType().Name + "\t"
                 + base.infoToWrite()
                 + "\t" + transmission
                 + "\t" + body;
        }
    }

    public class Airplane : AirTransport
    {
        private string planebody;
        private int maxHeight;


        public Airplane() : base()
        {
            planebody = "unknown";
        }

        public Airplane(int speed, string manufacturer, double weight, double height, Engine engine, int amount, string planebody, int maxHeight) : base(speed, manufacturer, weight, height, engine, amount)
        {
            this.planebody = planebody;
            this.maxHeight = maxHeight;
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
        public int MaxHeight
        {
            get
            {
                return maxHeight;
            }
            set
            {
                maxHeight = value;
            }
        }
        public override string getInformation()
        {
            return base.getInformation()
                + ", planebody: " + planebody
                + ", maxHeiht: " + maxHeight;
        }
        public override string infoToWrite()
        {
            return this.GetType().BaseType.Name + "\t"
                 + this.GetType().Name + "\t"
                 + base.infoToWrite()
                 + "\t" + planebody
                 + "\t" + maxHeight;
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
        public override string getInformation()
        {
            return base.getInformation()
                + ", shipbody: " + shipbody;
        }
        public override string infoToWrite()
        {
            return this.GetType().BaseType.Name + "\t"
                 + this.GetType().Name + "\t"
                 + base.infoToWrite()
                 + "\t" + shipbody;
        }
    }

    public class Train : LandTransport
    {
        private string loadtype;
        private int distance;

        public Train() : base()
        {
            loadtype = "unknown";
        }

        public Train(int speed, string manufacturer, double weight, double height, Engine engine, int amount, string loadtype, int distance) : base(speed, manufacturer, weight, height, engine, amount)
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
        public int Distance
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
        public override string getInformation()
        {
            return base.getInformation()
                + ", loadtype: " + loadtype
                + ", distance: " + distance;
        }
        public override string infoToWrite()
        {
            return this.GetType().BaseType.Name + "\t"
                 + this.GetType().Name + "\t"
                 + base.infoToWrite()
                 + "\t" + loadtype
                 + "\t" + distance;
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
        public override string getInformation()
        {
            return base.getInformation()
                + ", bodytype: " + bodytype;
        }
        public override string infoToWrite()
        {
            return this.GetType().BaseType.Name + "\t"
                 + this.GetType().Name + "\t"
                 + base.infoToWrite()
                 + "\t" + bodytype;
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

        public virtual string getInformation()
        {
            return "Power: " + power
                + " , manufacturer: " + manufacturer;
        }
        public virtual string infoToWrite()
        {
            return power + "\t"
                + manufacturer + "\t";
        }
    }

    public class PetrolEngine : Engine
    {
        private int cubes;

        public PetrolEngine() : base()
        {

        }
        public PetrolEngine(int power, string manufacturer, int cubes) : base(power, manufacturer)
        {
            this.cubes = cubes;
        }

        public int Cubes
        {
            get
            {
                return cubes;
            }
            set
            {
                cubes = value;
            }
        }
        public override string getInformation()
        {
            return base.getInformation()
            + " , cubes: " + cubes;
        }
        public override string infoToWrite()
        {
            return this.GetType().Name + "\t"
                 + base.infoToWrite()
                 + "\t" + cubes;
        }
    }

    public class Disel : Engine
    {
        private int dCubes;

        public Disel() : base()
        {

        }
        public Disel(int power, string manufacturer, int dCubes) : base(power, manufacturer)
        {
            this.dCubes = dCubes;
        }

        public int DCubes
        {
            get
            {
                return dCubes;
            }
            set
            {
                dCubes = value;
            }
        }
        public override string getInformation()
        {
            return base.getInformation()
            + " , dCubes: " + dCubes;
        }
        public override string infoToWrite()
        {
            return this.GetType().Name + "\t"
                 + base.infoToWrite()
                + "\t" + dCubes;
        }
    }

    public class ReactiveEngine : Engine
    {
        private int VoiceCall;

        public ReactiveEngine() : base()
        {

        }
        public ReactiveEngine(int power, string manufacturer, int VoiceCall) : base(power, manufacturer)
        {
            this.VoiceCall = VoiceCall;
        }

        public int _VoiceCall
        {
            get
            {
                return VoiceCall;
            }
            set
            {
                VoiceCall = value;
            }
        }
        public override string getInformation()
        {
            return base.getInformation()
            + " , VoiceCall: " + VoiceCall;
        }
        public override string infoToWrite()
        {
            return this.GetType().Name + "\t"
                 + base.infoToWrite()
                + "\t" + VoiceCall;
        }
    }
}
