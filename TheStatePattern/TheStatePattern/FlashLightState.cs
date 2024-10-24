using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheStatePattern
{
    internal abstract class FlashLightState
    {
        public abstract void HandlePower(FlashLight context);

        public abstract void HandleMode(FlashLight context);
    }
}
