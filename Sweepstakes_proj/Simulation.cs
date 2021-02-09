using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sweepstakes_proj
{
    class Simulation
    {
        public MarketingFirm marketingFirm;
        public ISweepstakesManager manager;
        public void CreateMarketingFirmWithManager()
        {
            ManagerCreator managerCreator = new ManagerCreator();
            string managerName = UserInterface.GetUserInputFor("manager");
            manager = managerCreator.GetSweepstakesManager(managerName);
            marketingFirm = new MarketingFirm(manager);
        }

        public void Run()
        {
            CreateMarketingFirmWithManager();
            string email = UserInterface.GetUserInputFor("email");
            marketingFirm.EmailAddress = email;
            bool addSweepstakes=UserInterface.WillContinue("add sweepstakes");
            while(addSweepstakes)
            {
                marketingFirm.CreateSweepstake();
                addSweepstakes = UserInterface.WillContinue("add sweepstakes");
            }
            Sweepstakes sweepstake = manager.GetSweepstakes();
            bool pickWinner = true;
            while (pickWinner && sweepstake != null)
            {
                pickWinner = UserInterface.WillContinue("pick winner");
                Contestant winner = sweepstake.PickWinner();
                sweepstake.NotifyUsersOfWinner(marketingFirm, winner);
                sweepstake = manager.GetSweepstakes();
            } 
        }
    }
}
