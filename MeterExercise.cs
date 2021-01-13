using System;

namespace MeterExercise
{
    abstract class AbstractSpeedometer
    {
        public abstract double Speed(double space, double time);
        public abstract double ConvertSpeed(double speed);
    }

    interface IUsaSpeedometer
    {
        void GetMilesPerYear(double mph);
    }

    class EuSpeedometer : AbstractSpeedometer
    {
        public EuSpeedometer(){}
        
        public override double Speed(double meters, double seconds)
        {
            double result = (meters/1000)/(seconds/3600);
            Console.WriteLine($"\nYour speed is {result} Km/h");
            return result;
        }

        public override double ConvertSpeed(double speed)
        {
            double result = speed*1.609344;
            Console.WriteLine($"\n{speed} Mph equals {result} Km/h");
            return result;
        }
    }

    class UsaSpeedometer : AbstractSpeedometer, IUsaSpeedometer
    {
        public UsaSpeedometer(){}

        public override double Speed(double feets, double seconds)
        {
            double result = (feets/5280)/(seconds/3600);
            Console.WriteLine($"\nYour speed is {result} Mph");
            return result;
        }

        public override double ConvertSpeed(double speed)
        {
            double result = speed/1.609344;
            Console.WriteLine($"\n{speed} Km/h equals {result} Mph");
            return result;
        }
        
        public void GetMilesPerYear(double mph)
        {
            Console.WriteLine($"\n{mph} miles per hour equals {mph*8760} miles per year");
        }
    }
}