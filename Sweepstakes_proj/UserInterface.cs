using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sweepstakes_proj
{
    public static class UserInterface
    {
        public static string GetUserInputFor(string prompt)
        {
            string userInput;
            switch(prompt)
            {
                case "sweepstakes name":
                    Console.WriteLine("Name of Sweepstakes: ");
                    userInput = Console.ReadLine();
                    return userInput;
                case "first name":
                    Console.WriteLine("First Name: ");
                    userInput = Console.ReadLine();
                    return userInput;
                case "last name":
                    Console.WriteLine("Last Name: ");
                    userInput = Console.ReadLine();
                    return userInput;
                case "email":
                    Console.WriteLine("Email Address: ");
                    userInput = Console.ReadLine();
                    return userInput;
                case "firm email":
                    Console.WriteLine("What is the email address for the marketing firm?");
                    Console.WriteLine("Email Address: ");
                    userInput = Console.ReadLine();
                    return userInput;
                case "manager":
                    Console.WriteLine("What kind of sweepstakes manager would you like to use?");
                    Console.WriteLine("Stack or Queue: ");
                    userInput = Console.ReadLine();
                    return userInput;
                default:
                    return null;
            }
        }

        public static void AssignRegistrationNumber(Contestant contestant,int totalAdded)
        {
            contestant.RegistrationNumber = totalAdded+1;
        }

        public static bool WillContinue(string prompt)
        {
            string userInput;
            switch(prompt)
            {
                case "add contestant":
                    Console.WriteLine("Would you like to add a contestant? (Y/N)");
                    userInput = Console.ReadLine();
                    if (userInput.ToLower() == "y")
                    {
                        return true;
                    }    
                    else
                    {
                        return false;
                    }
                case "add sweepstakes":
                    Console.WriteLine("Would you like to add a sweepstakes? (Y/N)");
                    userInput = Console.ReadLine();
                    if (userInput.ToLower() == "y")
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case "pick winner":
                    Console.WriteLine("Would you like to pick a sweepstakes winner? (Y/N)");
                    userInput = Console.ReadLine();
                    if (userInput.ToLower() == "y")
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                default:
                    return false;
            }
        }
    }
}
