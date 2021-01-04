using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;


namespace Abaddon
{
    class Program
    {
        static void Main()
        {
            Console.Title = "Abaddon";
            Console.CursorVisible = false;

            Console.Write("Game Found: ");
            var Game = Process.GetProcessesByName("isaac-ng");
            pInvoke.Game = Game[0];
            var Handle = pInvoke.OpenProcess(pInvoke.PROCESS_WM_READ, false, pInvoke.Game.Id);

            if (Game.Count() == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No");
                Console.ResetColor();
                Console.WriteLine("Please Start The Game & Try Again.");
                Console.ReadLine();
                Environment.Exit(1);
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Yes");
            Console.ResetColor();

            Console.WriteLine("\n---Game Information---");
            Console.WriteLine();


            Task.Run(() =>
            {
                do
                {
                    Console.SetCursorPosition(0, 4);
                    Console.WriteLine($"Character: {Player.Player.GetCurrentPlayer()}     \nHealth: {Player.Health.GetCurrentHealth()}\nMoney: {Player.Money.GetCurrentMoney()}\nBombs: {Player.Bombs.GetCurrentBombs()}\nKeys: {Player.Keys.GetCurrentKeys()}");
                    Task.Delay(TimeSpan.FromSeconds(.5)).Wait();
                } while (true);
            });

            Console.SetCursorPosition(0, 10);
            Console.WriteLine("Press Any Key To Quit...");
            Console.ReadKey(true);

            pInvoke.CloseHandle(Handle);
        }
    }
}
