using System;
using System.Collections.Generic;
using System.Text;

namespace Home8
{
    public class Television : IRemoteControl
    {
        private bool isOn = false;
        private int currentChannel = 1;

        public void TurnOn()
        {
            isOn = true;
            Console.WriteLine("Television is ON");
        }
        public void TurnOff()
        {
            isOn = false;
            Console.WriteLine("Television is OFF");
        }
        public void SetChannel(int channel)
        {
            if (isOn)
            {
                currentChannel = channel;
                Console.WriteLine($"Television switched to channel: {currentChannel}");
            }
            else Console.WriteLine("Television is OFF");
        }
    }
}
