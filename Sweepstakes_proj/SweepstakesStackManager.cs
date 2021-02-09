using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sweepstakes_proj
{
    public class SweepstakesStackManager : ISweepstakesManager
    {
        private Stack<Sweepstakes> stack;

        public SweepstakesStackManager()
        {
            stack = new Stack<Sweepstakes>();
        }
        public void InsertSweepstakes(Sweepstakes sweepstakes)
        {
            stack.Push(sweepstakes);
        }

        public Sweepstakes GetSweepstakes()
        {
            if (stack.Count > 0)
            {
                Sweepstakes sweepstakes = stack.Pop();
                return sweepstakes;
            }
            else
            {
                return null;
            }

        }

    }
}
