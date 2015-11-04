using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlashlightSwitchCase
{
    public class Flashlight
    {
        public enum FlashLightEvent { PowerBtnPressed }
        enum FlashLightState { On, Off }

        private FlashLightState _currentState;

        public Flashlight()
        {
            _currentState = FlashLightState.Off;
            Off();
        }

        public void HandleEvent(FlashLightEvent evt)
        {
            switch (_currentState)
            {
                case FlashLightState.On:
                    _currentState = FlashLightState.Off;
                    Off();
                    break;

                case FlashLightState.Off:
                    _currentState = FlashLightState.On;
                    On();
                    break;
            }
        }

        private void Off()
        {
            Console.WriteLine("I is off");
        }

        private void On()
        {
            Console.WriteLine("I is on");
        }

    }
}
