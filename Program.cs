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

            static string Outcome()
            {
                return Console.ReadLine();
            }

            string outcome = Outcome();
            outcome = outcome.ToUpper();
            Console.WriteLine("\n " + outcome + "? Press ENTER to continue.");
            Console.ReadLine();

            string toggleOn = "/c netsh wlan set autoconfig enabled=yes interface=\"Wi-Fi 4\"";
            string toggleOff = "/c netsh wlan set autoconfig enabled=no interface=\"Wi-Fi 4\"";

            static void Toggle()
            {
                string outcome = Outcome();
                outcome = outcome.ToUpper();
                if (outcome == "ON")
                {
                    System.Diagnostics.Process.Start("CMD.exe", toggleOn);
                }
                else (outcome == "OFF")
                {
                    System.Diagnostics.Process.Start("CMD.exe", toggleOff);
                }
            }

            Toggle();
            Console.ReadLine();
        }
    }
}
