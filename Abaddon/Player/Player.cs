using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abaddon.Player
{
    static class Player
    {
        internal static string GetCurrentPlayer()
        {
            byte[] Base = new byte[4];
            byte[] Player = new byte[4];

            int Base_Size = 0;
            int Player_Size = 0;

            //Find Where To Read Player.
            pInvoke.ReadProcessMemory(pInvoke.Game.Handle.ToInt32(), (pInvoke.Game.MainModule.BaseAddress + 0x0053A0E0).ToInt32(), Base, 4, ref Base_Size);

            //Find Player.
            pInvoke.ReadProcessMemory(pInvoke.Game.Handle.ToInt32(), BitConverter.ToInt32(Base, 0) + 0x8ECD8, Player, 4, ref Player_Size);

            switch (BitConverter.ToInt32(Player, 0))
            {
                case 0:
                    return "Isaac";
                case 1:
                    return "Magdalene";
                case 2:
                    return "Cain";
                case 3:
                    return "Judas";
                case 4:
                    return "??? (Blue Baby)";
                case 5:
                    return "Eve";
                case 6:
                    return "Samson";
                case 7:
                    return "Azazel";
                case 8:
                    return "Lazarus";
                case 9:
                    return "Eden";
                case 10:
                    return "The Lost";
                case 11:
                    return "Lazarus Risen";
                case 12:
                    return "Black Judas";
                case 13:
                    return "Lilith";
                case 14:
                    return "Keeper";
                case 15:
                    return "Appolyon";
                case 16:
                    return "The Forgotten";
                case 17:
                    return "The Soul";
                default:
                    return "[[NO ONE]]";
            }
        }
    }
}
