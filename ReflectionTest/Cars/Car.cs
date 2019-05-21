using System;
using System.Collections.Generic;
using System.Text;

namespace ReflectionTest.Cars
{
    class Car : ICar
    {
        public string Color;

        private int _speed;

        public int Speed { get { return _speed; } }

        public void Accelerate(int accelerateBy)
        {
            _speed += accelerateBy;
        }

        public bool IsMoving()
        {
            return Speed != 0;
        }

        public Car()
        {
            Color = "White";
            _speed = 0;
        }

        public Car(string color, int speed)
        {
            Color = color;
            _speed = speed;
        }

        public double CalculateMPG(int startMiles, int endMiles, double gallons)
        {
            return (endMiles - startMiles) / gallons;
        }
    }
}
