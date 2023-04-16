using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Race;
delegate void CarEventHandler(Car car);

namespace Race
{
    delegate void CarEventHandler(Car car);

    abstract class Car
    {
        public string Model { get; set; }
        public int Speed { get; set; }
        public int Distance { get; set; }
        public bool Finished { get; set; }

        public Car(string model, int speed)
        {
            this.Model = model;
            this.Speed = speed;
            this.Distance = 0;
            this.Finished = false;
        }

        public void StartRace()
        {
            Console.WriteLine("{0} вышел на старт", Model);
        }

        public void Move()
        {
            Distance += Speed;
            Console.WriteLine("{0} проехал {1} км", Model, Distance);
        }

        public void FinishRace()
        {
            Console.WriteLine("{0} финишировал!", Model);
            Finished = true;
            OnFinish();
        }

        public event CarEventHandler Finish;
        protected virtual void OnFinish()
        {
            if (Finish != null)
                Finish(this);
        }
    }

    class SportsCar : Car
    {
        public SportsCar(string model, int speed) : base(model, speed)
        {
        }
    }

    class PassengerCar : Car
    {
        public PassengerCar(string model, int speed) : base(model, speed)
        {
        }
    }

    class Truck : Car
    {
        public Truck(string model, int speed) : base(model, speed)
        {
        }
    }

    class Bus : Car
    {
        public Bus(string model, int speed) : base(model, speed)
        {
        }
    }

    class Game
    {
        public static void Main(string[] args)
        {
            SportsCar sportsCar1 = new SportsCar("Ferrari", 80);
            SportsCar sportsCar2 = new SportsCar("Lamborghini", 90);
            PassengerCar passengerCar1 = new PassengerCar("Toyota", 50);
            PassengerCar passengerCar2 = new PassengerCar("BMW", 60);
            Truck truck1 = new Truck("Volvo", 40);
            Truck truck2 = new Truck("MAN", 30);
            Bus bus1 = new Bus("Mercedes", 20);
            Bus bus2 = new Bus("Neoplan", 25);

            CarEventHandler finishHandler = delegate (Car car)
            {
                Console.WriteLine("Победитель: {0}", car.Model);
            };

            sportsCar1.Finish += finishHandler;
            sportsCar2.Finish += finishHandler;
            passengerCar1.Finish += finishHandler;
            passengerCar2.Finish += finishHandler;
            truck1.Finish += finishHandler;
            truck2.Finish += finishHandler;
            bus1.Finish += finishHandler;
            bus2.Finish += finishHandler;

            Console.WriteLine("Старт гонки!");

            while (true)
            {
                sportsCar1.Move();
                sportsCar2.Move();
                passengerCar1.Move();
                passengerCar2.Move();
                truck1.Move();
                truck2.Move();
                bus1.Move();
                bus2.Move();

                if (sportsCar1.Distance >= 100)
                {
                    sportsCar1.FinishRace();
                }
                if (sportsCar2.Distance >= 100)
                {
                    sportsCar2.FinishRace();
                }
                if (passengerCar1.Distance >= 100)
                {
                    passengerCar1.FinishRace();
                }

                if (sportsCar1.Finished && sportsCar2.Finished && passengerCar1.Finished && passengerCar2.Finished && truck1.Finished && truck2.Finished && bus1.Finished && bus2.Finished);


             }
        }
    }
}