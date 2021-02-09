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
    public class MarketingFirm : ISubscriber
    {

        private ISweepstakesManager _manager;
        private string emailAddress;


        //Dependency injection will be used here. Since the MarketingFirm class depends on an ISweepstakesManager class,
        //we should inject the dependent class instead of creating it. This will make the application much easier to use and
        //test because the user will only have to choose between a Queue and a Stack.
        public MarketingFirm(ISweepstakesManager manager)
        {
            _manager = manager;
        }

        public void CreateSweepstake()
        {

            Sweepstakes sweepstakes = new Sweepstakes(UserInterface.GetUserInputFor("sweepstakes name"));
            bool addContestants=UserInterface.WillContinue("add contestant"); 
            while (addContestants)
            {
                Contestant contestant = new Contestant();
                sweepstakes.RegisterContestant(contestant);
                addContestants = UserInterface.WillContinue("add contestant");
            }
            _manager.InsertSweepstakes(sweepstakes);
        }


        public string EmailAddress
        {
            get
            {
                return emailAddress;
            }
            set
            {
                emailAddress = value;
            }
        }
        public void Notify(ISubscriber subscriber, Sweepstakes sweepstakes, Contestant winner)
        {
            StringBuilder name = new StringBuilder();
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(sweepstakes.Name, APIKeys.Email));
            message.To.Add(new MailboxAddress("Marketing Firm", subscriber.EmailAddress));
            message.Subject = "Sweepstakes Winner Announced!";
            message.Body = new TextPart("plain")
            {
                Text = @"Hello,

The winner of the sweepstakes is " + winner.FirstName + " " + winner.LastName + "."
            };

            using (var client = new SmtpClient())
            {
                client.Connect("smtp.gmail.com", 587, false);
                client.Authenticate(APIKeys.Email, APIKeys.Password);
                client.Send(message);
                client.Disconnect(true);
            }

        }

    }
}
