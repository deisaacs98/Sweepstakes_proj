using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sweepstakes_proj
{
    public interface ISubscriber
    {
        string EmailAddress { get; set; }
        void Notify(ISubscriber subscriber, Sweepstakes sweepstakes,Contestant winner);
    }
}
