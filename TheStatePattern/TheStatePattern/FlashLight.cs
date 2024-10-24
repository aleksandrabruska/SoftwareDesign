using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheStatePattern
{
    internal class FlashLight : IFlashLight, IFlashLightInternal
    {
        FlashLightState state;

        FlashLightState offState;

        FlashLightState flashingState;
        FlashLightState solidState;
        //GUI
        public FlashLight()
        {
            flashingState = new Flashing();
            solidState = new Solid();
            offState = new Off();
            SetState(offState);
            
        }
        public void Power()
        {
            state.HandlePower(this);
        }

        public void Mode()
        {
            state.HandleMode(this);
        }

        //Internal
        public void LightOn()
        {
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.WriteLine("ON");
        }

        public void StartFlashing()
        {
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.Write(" I ");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write(" O ");
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.Write(" I \n");
        }

        public void StartSolid()
        {
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.WriteLine(" I I I ");
        }
        public void LightOff()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("OFF");
        }
        public void SetState(FlashLightState state_)
        {
            this.state = state_;
        }
        
        public FlashLightState GetOffState()
        {
            return offState;
        }

        public FlashLightState GetFlashingState()
        {
            return this.flashingState;
        }

        public FlashLightState GetSolidState()
        {
            return this.solidState;
        }

    }
}
