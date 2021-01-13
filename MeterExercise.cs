using System;

namespace MeterExercise
{
    abstract class Meter
    {
        public abstract void Speed(double space, double time);
        public abstract void ConvertSpeed(double speed);
    }

    class EuMeter : Meter
    {
        public EuMeter(){}
        public override void Speed(double meters, double seconds)
        {
            Console.WriteLine($"\nYour speed is {(meters/1000)/(seconds/3600)} Km/h");
        }
        public override void ConvertSpeed(double speed)
        {
            Console.WriteLine($"\n{speed} Mph equals {speed*1.609344} Km/h");
        }
    }

    class UsaMeter : Meter
    {
        public UsaMeter(){}
        public override void Speed(double miles, double seconds)
        {
            Console.WriteLine($"\nYour speed is {miles/(seconds/3600)} Mph");
        }
        public override void ConvertSpeed(double speed)
        {
            Console.WriteLine($"\n{speed} Km/h equals {speed/1.609344} Mph");
        }
    }
}