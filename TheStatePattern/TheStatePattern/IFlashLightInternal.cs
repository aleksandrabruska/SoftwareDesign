using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheStatePattern
{
    internal interface IFlashLightInternal
    {
        public void LightOn();
        public void LightOff();
        public void StartFlashing();
        public void StartSolid();
        public void SetState(FlashLightState state);
        public FlashLightState GetOffState();
        public FlashLightState GetFlashingState();
        public FlashLightState GetSolidState();


    }
}
