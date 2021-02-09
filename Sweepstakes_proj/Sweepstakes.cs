using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MailKit;
using MimeKit;

namespace Sweepstakes_proj
{
    public class Sweepstakes
    {
        private Dictionary<int, Contestant> contestants=new Dictionary<int,Contestant>();
        private string name;
        public int totalAdded = 0;

        public Sweepstakes(string name)
        {
            Name = name;
        }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        public void RegisterContestant(Contestant contestant)
        {
            
            string firstName = UserInterface.GetUserInputFor("first name");
            contestant.FirstName = firstName;
            string lastName = UserInterface.GetUserInputFor("last name");
            contestant.LastName = lastName;
            string emailAddress = UserInterface.GetUserInputFor("email");
            contestant.EmailAddress = emailAddress;
            UserInterface.AssignRegistrationNumber(contestant,totalAdded);
            totalAdded++;
            contestants.Add(totalAdded, contestant);
            Console.WriteLine("You added: ");
            PrintContestantInfo(contestant);
        }

        public Contestant PickWinner()
        {
            
            Random random = new Random();
            int regNumber = random.Next(1, totalAdded+1);
            if(contestants.ContainsKey(regNumber))
            {
                Contestant contestant = contestants[regNumber];
                return contestant;
            }
            else
            {
                return null;
            }
            
        }

        public void PrintContestantInfo(Contestant contestant)
        {
            StringBuilder contestantInfo = new StringBuilder();
            contestantInfo.Append(contestant.FirstName);
            contestantInfo.Append(" ");
            contestantInfo.Append(contestant.LastName);
            contestantInfo.Append(" ");
            contestantInfo.Append(contestant.EmailAddress);
            contestantInfo.Append(" ");
            contestantInfo.Append(contestant.RegistrationNumber);
            Console.WriteLine(contestantInfo);

        }

        public void NotifyUsersOfWinner(MarketingFirm marketingFirm,Contestant winner)
        {
            marketingFirm.Notify(marketingFirm, this,winner);
            foreach (KeyValuePair<int, Contestant> contestant in contestants)
            {
                contestant.Value.Notify(contestant.Value, this,winner);
            }
        }
    }
}
