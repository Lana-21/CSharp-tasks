using System;
using System.Collections.Generic;
using System.Text;

namespace Home8
{
    public class Radio : IRemoteControl
    {
        private bool isOn = false;
        private int currentChannel = 100;

        public void TurnOn()
        {
            isOn = true;
            Console.WriteLine("Radio is ON");
        }
        public void TurnOff()
        {
            isOn = false;
            Console.WriteLine("Radio is OFF");
        }
        public void SetChannel(int channel)
        {
            if (isOn)
            {
                currentChannel = channel;
                Console.WriteLine($"Radio tuned to channel: {currentChannel}");
            }
            else Console.WriteLine("Radio is OFF");
        }
    }
}
