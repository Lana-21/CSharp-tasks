using System;
using System.Collections.Generic;
using System.Text;

namespace Home8
{
    public interface IRemoteControl
    {
        void TurnOn();
        void TurnOff();
        void SetChannel(int channel);
    }
}
