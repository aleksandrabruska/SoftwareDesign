using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheStatePattern
{
    internal abstract class On : FlashLightState
    {
        public override void HandlePower(FlashLight context)
        {
            context.SetState(context.GetOffState());
            context.LightOff();
        }


    }
}
