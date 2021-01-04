using System;

namespace Abaddon.Player
{
    static class Money
    {
        internal static int GetCurrentMoney()
        {
            byte[] Base = new byte[4];
            byte[] Player_Money = new byte[4];

            int Base_Size =0;
            int Player_Size = 0;

            //God Damn It Edmund, Is This Intentional Or What?
            pInvoke.ReadProcessMemory(pInvoke.Game.Handle.ToInt32(), (pInvoke.Game.MainModule.BaseAddress + 0x0053A0DC).ToInt32(), Base, 4, ref Base_Size);
            pInvoke.ReadProcessMemory(pInvoke.Game.Handle.ToInt32(), BitConverter.ToInt32(Base, 0) + 0x0, Base, 4, ref Base_Size);
            pInvoke.ReadProcessMemory(pInvoke.Game.Handle.ToInt32(), BitConverter.ToInt32(Base, 0) + 0x10, Base, 4, ref Base_Size);
            pInvoke.ReadProcessMemory(pInvoke.Game.Handle.ToInt32(), BitConverter.ToInt32(Base, 0) + 0x40, Base, 4, ref Base_Size);
            pInvoke.ReadProcessMemory(pInvoke.Game.Handle.ToInt32(), BitConverter.ToInt32(Base, 0) + 0xC, Base, 4, ref Base_Size);
            pInvoke.ReadProcessMemory(pInvoke.Game.Handle.ToInt32(), BitConverter.ToInt32(Base, 0) + 0x0, Base, 4, ref Base_Size);
            pInvoke.ReadProcessMemory(pInvoke.Game.Handle.ToInt32(), BitConverter.ToInt32(Base, 0) + 0x1C, Base, 4, ref Base_Size);

            //Find Player.
            pInvoke.ReadProcessMemory(pInvoke.Game.Handle.ToInt32(), BitConverter.ToInt32(Base, 0) + 0x024E4, Player_Money, 4, ref Player_Size);

            return BitConverter.ToInt32(Player_Money, 0);
        }
    }
}
