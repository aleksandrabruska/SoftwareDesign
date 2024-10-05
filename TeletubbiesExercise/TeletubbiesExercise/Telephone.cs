using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeletubbiesExercise
{
    enum DayPart { MORNING, NIGHT, AFTERNOON, EVENING }
    
    internal class Telephone : Subject
    {
        DayPart current;
        public Telephone() {
            current = DayPart.MORNING;
        }
        public override void Notify()
        {
            foreach (IObserver observer in observers)
            {
                observer.Update(current);
            }
        }
        public void SetTime(DayPart newDayPart)
        {
            current = newDayPart;
        }

    }
}
