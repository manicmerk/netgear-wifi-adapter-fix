using System;

namespace Wi_Fi_Drop_Fix
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {// Initiate CMD prompt to display autoconfig setting causing lag bombs.
                string destination = "/c netsh wlan show settings";
                System.Diagnostics.Process.Start("CMD.exe", destination);
                Console.ReadLine();

                Console.WriteLine("\n Do you want to toggle AutoConfig setting for your Wi-Fi Adapter?");
                Console.Write("\n Please input On, Off, Help or Quit? ");

                string outcome = GetUserInput();

                if (outcome == "ON" || outcome == "OFF")
                {
                    Console.WriteLine("\n " + outcome + "? Press ENTER to continue.");
                    Console.ReadLine();
                    Console.Write("\n Enter your Wi-Fi adapter name here: ");
                    string adapter = GetUserInput();

                    if (outcome == "ON")
                    {
                        Console.WriteLine("You can now detect wireless routers.");
                        ToggleOn(adapter);
                        // Log event to log file.
                    }
                    else if (outcome == "OFF")
                    {
                        ToggleOff(adapter);
                        Console.WriteLine("You are connected to wireless but unable to detect new routers.");
                        // Log event to log file.
                    }

                }
                else if (outcome == "QUIT")
                {
                    Console.WriteLine("\n Goodbye!");
                    break;
                }

                // Better placement for log. Give timestamp and log outcome (option).

                Console.ReadLine();
            }
        }

        // Method to return answer for user outcome interface.
        static public string GetUserInput()
        {
            string outcome = Console.ReadLine();
            return outcome.ToUpper();
        }

        // Toggle Autoconfig setting on or off.
        static void ToggleOn(string adapter)
        {
            string toggleOn = "/c netsh wlan set autoconfig enabled=yes interface=\"" + adapter + "\"";
            System.Diagnostics.Process.Start("CMD.exe", toggleOn);
        }

        static void ToggleOff(string adapter)
        {
            string toggleOff = "/c netsh wlan set autoconfig enabled=no interface=\"" + adapter + "\"";
            System.Diagnostics.Process.Start("CMD.exe", toggleOff);
        }

    }
}
