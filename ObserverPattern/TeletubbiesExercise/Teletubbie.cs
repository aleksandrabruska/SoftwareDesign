using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeletubbiesExercise
{
    internal class Teletubbie: IObserver
    {
        public void Update(DayPart dayPart)
        {
            switch (dayPart)
            {
                case DayPart.MORNING: WakeUp();
                    break;
                case DayPart.AFTERNOON: WatchTv();
                    break;
                case DayPart.EVENING: EatDinner();
                    break;
                case DayPart.NIGHT: ByeBye();
                    break;
                default: 
                    break;
            }
        }
        public void EatDinner()
        {
            Console.WriteLine("I am eating dinner omnom");
        }
        public void WatchTv()
        {
            Console.WriteLine("I am watching TV ....");
        }
        public void WakeUp()
        {
            Console.WriteLine("I am up yawn");
        }
        public void ByeBye()
        {
            Console.WriteLine("Bye bye");
        }

    }
}
