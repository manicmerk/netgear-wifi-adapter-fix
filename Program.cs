using System;

namespace Wi_Fi_Drop_Fix
{
    class Program
    {
        static void Main(string[] args)
        {
            // Initiate CMD prompt to display autoconfig setting causing lag bombs.
            string destination = "/c netsh wlan show settings";
            System.Diagnostics.Process.Start("CMD.exe", destination);
            Console.ReadLine();

            Console.WriteLine("\n Do you want to toggle AutoConfig setting for your Wi-Fi Adapter?");
            Console.Write("\n Please input On, Off or Quit? ");

            string outcome = Outcome();

            Console.WriteLine("\n " + outcome + "? Press ENTER to continue.");
            Console.ReadLine();

            Toggle(outcome);
            Console.ReadLine();
            Console.Write("Goodbye!");
        }

        // Method to return answer for user outcome interface.
        static public string Outcome()
        {
            string outcome = Console.ReadLine();
            return outcome.ToUpper();
        }

        // Toggle Autoconfig setting on or off.
        static void Toggle(string outcome)
        {
            string toggleOn = "/c netsh wlan set autoconfig enabled=yes interface=\"Wi-Fi 4\"";
            string toggleOff = "/c netsh wlan set autoconfig enabled=no interface=\"Wi-Fi 4\"";

            if (outcome == "ON")
            {
                Console.WriteLine("You can now detect wireless routers.");
                System.Diagnostics.Process.Start("CMD.exe", toggleOn);
            }
            else if (outcome == "OFF")
            {
                Console.WriteLine("You are connected to wireless but unable to detect new routers.");
                System.Diagnostics.Process.Start("CMD.exe", toggleOff);
            }
            else if (outcome == "QUIT")
            {
                Console.WriteLine("Goodbye!");
                Environment.Exit(0);
            }
        }

    }
}
