using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlashlightSwitchCase
{
    class Program
    {
        static void Main(string[] args)
        {
            var light = new Flashlight();

            for (int i = 0; i < 10000; i++)
            {
                light.HandleEvent(Flashlight.FlashLightEvent.PowerBtnPressed);
            }
        }
    }
}
