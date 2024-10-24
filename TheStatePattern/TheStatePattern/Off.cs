using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheStatePattern
{
    internal class Off : FlashLightState
    {
        public override void HandlePower(FlashLight context)
        {
            context.SetState(context.GetSolidState());
            context.StartSolid();
        }

        public override void HandleMode(FlashLight context) { }

    }
}
