using System.Runtime.InteropServices;

namespace PostBlog
{
    public class PInvokeEntity
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct SECURITY_ATTRIBUTES
        {
            public int nLength;
            public int lpSecurityDescriptor;
            public bool bInheritHandle;
        }
    }
}
