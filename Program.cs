using System;

namespace Wi_Fi_Drop_Fix
{
    class Program
    {
        static void Main(string[] args)
        {
            // Very simple program to toggle wifi adapter setting causing high ping and lag.
            Console.WriteLine("\n Press ENTER to toggle Autoconfig ON.");
            Console.ReadLine();

            // Could use variable in place of wifi name to return a readline to work for anyone with this problem.
            // Would reimplement the config screen and have a readline for user to input wifi name as listed in settings.
            string toggleOn = "/c netsh wlan set autoconfig enabled=yes interface=\"Wi-Fi 4\"";
            string toggleOff = "/c netsh wlan set autoconfig enabled=no interface=\"Wi-Fi 4\"";

            System.Diagnostics.Process.Start("CMD.exe", toggleOn);
            Console.WriteLine("You can now detect wireless routers.");
            Console.ReadLine();

            Console.WriteLine("\n Press ENTER to toggle Autoconfig OFF.");
            Console.ReadLine();
            System.Diagnostics.Process.Start("CMD.exe", toggleOff);
            Console.WriteLine("You are now connected, but unable to detect new routers.");
            Console.ReadLine();

            Console.WriteLine("Have a nice day :-)");
            Console.ReadLine();
        }
    }
}
