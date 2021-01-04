using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Abaddon
{
    internal static class pInvoke
    {
        internal static Process Game { get; set; }

        //https://docs.microsoft.com/en-us/windows/win32/api/processthreadsapi/nf-processthreadsapi-openprocess
        [DllImport("kernel32.dll")]
        internal static extern IntPtr OpenProcess(int dwDesiredAccess, bool bInheritHandle, int dwProcessId);

        //https://docs.microsoft.com/en-us/windows/win32/api/handleapi/nf-handleapi-closehandle
        [DllImport("kernel32.dll")]
        internal static extern bool CloseHandle(IntPtr hObject);

        //https://docs.microsoft.com/en-us/windows/win32/api/memoryapi/nf-memoryapi-readprocessmemory
        [DllImport("kernel32.dll")]
        internal static extern bool ReadProcessMemory(int hProcess, int lpBaseAddress, byte[] lpBuffer, int dwSize, ref int lpNumberOfBytesRead);

        //https://docs.microsoft.com/en-us/windows/win32/procthread/process-security-and-access-rights
        internal static readonly int PROCESS_WM_READ = 0x0010;

    }
}
