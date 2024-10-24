using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telephone
{
    internal class Phone
    {
        PhoneState state;
        public void SetState(PhoneState state)
        {
            this.state = state;
        }
        public void Idle()
        {
            Console.WriteLine("I am idle");
        }
        public void Busy()
        {
            Console.WriteLine("Busy!");
        }
        public void Call()
        {
            Console.WriteLine("I am calling");
        }
        public void Connect()
        {
            Console.WriteLine("I am connected");
        }

        public void Disconect()
        {
            Console.WriteLine("I am disconected");
        }
    }
}
