using System;

namespace MeterExercise
{
    abstract class Speedometer
    {
        public abstract void Speed(double space, double time);
        public abstract void ConvertSpeed(double speed);
    }

    class EuSpeedometer : Speedometer
    {
        public EuSpeedometer(){}
        public override void Speed(double meters, double seconds)
        {
            Console.WriteLine($"\nYour speed is {(meters/1000)/(seconds/3600)} Km/h");
        }
        public override void ConvertSpeed(double speed)
        {
            Console.WriteLine($"\n{speed} Mph equals {speed*1.609344} Km/h");
        }
    }

    class UsaSpeedometer : Speedometer
    {
        public UsaSpeedometer(){}
        public override void Speed(double feets, double seconds)
        {
            Console.WriteLine($"\nYour speed is {(feets/5280)/(seconds/3600)} Mph");
        }
        public override void ConvertSpeed(double speed)
        {
            Console.WriteLine($"\n{speed} Km/h equals {speed/1.609344} Mph");
        }
    }
}