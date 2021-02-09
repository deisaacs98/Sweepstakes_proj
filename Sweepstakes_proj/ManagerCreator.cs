using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sweepstakes_proj
{
    public class ManagerCreator : IGetManager
    {
        public ISweepstakesManager GetSweepstakesManager(string manager)
        {
            switch(manager.ToLower())
            {
                case "stack":
                    return new SweepstakesStackManager();
                case "queue":
                    return new SweepstakesQueueManager();
                default:
                    throw new ApplicationException(string.Format("Not a valid manager class"));
            }
        }
    }
}
