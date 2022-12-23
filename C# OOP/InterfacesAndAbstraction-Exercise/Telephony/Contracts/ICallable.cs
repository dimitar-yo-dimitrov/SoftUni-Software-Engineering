using System;
using System.Collections.Generic;
using System.Text;

namespace Telephony.Contracts
{
    interface ICallable
    {
        void Call(string number);
    }
}
