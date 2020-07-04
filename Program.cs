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

            String outcome = Outcome();

            Console.WriteLine("\n " + outcome + "? Press ENTER to continue.");
            Console.ReadLine();

            Toggle();
            Console.ReadLine();
        }

        // Method to return answer for user outcome interface.
        static public string Outcome()
        {
            string outcome = Console.ReadLine();
            return outcome = outcome.ToUpper();
        }

        // Toggle Autoconfig setting on or off.
        static void Toggle()
        {
            string toggleOn = "/c netsh wlan set autoconfig enabled=yes interface=\"Wi-Fi 4\"";
            string toggleOff = "/c netsh wlan set autoconfig enabled=no interface=\"Wi-Fi 4\"";
            string outcome = Outcome();

            if (outcome == "ON")
            {
                Console.WriteLine("Autoconfig Enabled. You can detect wireless routers now.");
                System.Diagnostics.Process.Start("CMD.exe", toggleOn);
                Console.ReadLine();
            }
            else if (outcome == "OFF")
            {
                Console.WriteLine("Autoconfig Disabled. You are connected to wireless but unable to detect new routers.");
                System.Diagnostics.Process.Start("CMD.exe", toggleOff);
                Console.ReadLine();
            }
            else if (outcome == "QUIT")
            {
                Console.WriteLine("Goodbye!");
                Console.Write("Press Enter to Exit ");
                Console.ReadLine();
                Environment.Exit(0);
            }
        }

    }
}
