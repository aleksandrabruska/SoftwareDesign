using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheStatePattern
{
    internal class Solid : On
    {
        public override void HandleMode(FlashLight context)
        {
            context.SetState(context.GetFlashingState());
            context.StartFlashing();
        }
    }
}
