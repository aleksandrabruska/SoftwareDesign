using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StocksExercise
{
    internal class Stock : Subject
    {
        private float value;
        private String name;

        public Stock(String name, float value)
        {
            this.name = name;
            this.value = value;
        }

        public String getName()
        {
            return this.name;
        }

        public float getValue()
        {
            return value;
        }

        public void setValue(float value)
        {
            this.value = value;
            Notify();
        }


    }
}
