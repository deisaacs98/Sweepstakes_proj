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
    public class Contestant : ISubscriber
    {
        private string firstName;
        private string lastName;
        private string emailAddress;
        private int registrationNumber;

        public Contestant()
        {

        }
        public void Notify(ISubscriber subscriber, Sweepstakes sweepstakes,Contestant winner)
        {
            StringBuilder name = new StringBuilder();
            name.Append(FirstName);
            name.Append(" ");
            name.Append(LastName);
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(sweepstakes.Name, APIKeys.Email));
            message.To.Add(new MailboxAddress(name.ToString(), subscriber.EmailAddress));
            if (subscriber == winner)
            {
                message.Subject = "Congratulations!";
                message.Body = new TextPart("plain")
                {
                    Text = @"Congratulations,

You've won the sweepstakes! Take some money!"
                };
            }
            else
            {
                message.Subject = "Sweepstakes Winner Announced!";
                message.Body = new TextPart("plain")
                {
                    Text = @"Hello,

The winner of the sweepstakes is " + winner.FirstName + " " + winner.LastName + "."
                };
            }

            using (var client = new SmtpClient())
            {
                client.Connect("smtp.gmail.com", 587, false);
                client.Authenticate(APIKeys.Email, APIKeys.Password);
                client.Send(message);
                client.Disconnect(true);
            }


        }
        public string FirstName
        {
            get
            {
                return firstName;
            }
            set
            {
                firstName = value;
            }
        }
        public string LastName
        {
            get
            {
                return lastName;
            }
            set
            {
                lastName = value;
            }
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

        public int RegistrationNumber
        {
            get
            {
                return registrationNumber;
            }
            set
            {
                registrationNumber = value;
            }
        }
    }
}
