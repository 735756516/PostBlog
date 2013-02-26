using System;
using System.Runtime.InteropServices;
using System.Threading;

namespace PostBlog
{
    public class PInvokeAPI
    {
        [DllImport("Kernel32.dll")]
        public static extern void OutputDebugString(String lpOutputString);


        [DllImport("Kernel32.dll", SetLastError = true)]
        public static extern UInt32 WaitForSingleObject(IntPtr hHandle, UInt32 dwMilliseconds);


        [DllImport("Kernel32.dll", SetLastError = true)]
        public static extern bool CloseHandle(IntPtr hObject);


        public delegate void CreateThreadProc(IntPtr lpPara);


        [DllImport("Kernel32.dll")]
        public static extern IntPtr CreateThread(ref PInvokeEntity.SECURITY_ATTRIBUTES SecurityAttributes,
            uint StackSize, ThreadStart StartFunction, IntPtr ThreadParameter,
            uint CreationFlags, out uint ThreadId);


        [DllImport("Kernel32.dll")]
        public static extern IntPtr CreateThread(ref PInvokeEntity.SECURITY_ATTRIBUTES SecurityAttributes,
            uint StackSize, CreateThreadProc StartFunction, IntPtr ThreadParameter,
            uint CreationFlags, out uint ThreadId);


        [DllImport("Kernel32.dll")]
        public static extern bool TerminateThread(IntPtr hThread, uint dwExitCode);


    }
}
