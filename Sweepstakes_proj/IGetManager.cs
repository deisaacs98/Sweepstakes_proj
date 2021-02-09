using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sweepstakes_proj
{
    interface IGetManager
    {
        ISweepstakesManager GetSweepstakesManager(string manager);
    }
}
