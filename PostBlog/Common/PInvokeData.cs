using System;

namespace PostBlog
{
    public class PInvokeData
    {
        public const int SPDRP_DEVICEDESC = 0x00000000;
        public const int SPDRP_CAPABILITIES = 0x0000000F;
        public const int SPDRP_CLASS = 0x00000007;
        public const int SPDRP_CLASSGUID = 0x00000008;
        public const int SPDRP_FRIENDLYNAME = 0x0000000C;

        public const int INVALID_HANDLE_VALUE = -1;
        public const int GENERIC_READ = unchecked((int)0x80000000);
        public const int GENERIC_WRITE = 0x40000000;
        public const int GENERIC_ALL = 0x10000000;
        public const int OPEN_EXISTING = 3;

        public const String GUID_DEVINTERFACE_VOLUME = "53f5630d-b6bf-11d0-94f2-00a0c91efb8b";
        public const String GUID_DEVINTERFACE_DISK = "53f56307-b6bf-11d0-94f2-00a0c91efb8b";
        public const int IOCTL_VOLUME_GET_VOLUME_DISK_EXTENTS = 0x00560000;


        public const int NO_ERROR = 0;
        public const int ERROR_NO_MORE_ITEMS = 259;
        public const int ERROR_INSUFFICIENT_BUFFER = 122;
        public const int ERROR_INVALID_DATA = 13;

        public const UInt32 INFINITE = 0xFFFFFFFF;
        public const UInt32 WAIT_ABANDONED = 0x00000080;
        public const UInt32 WAIT_OBJECT_0 = 0x00000000;
        public const UInt32 WAIT_TIMEOUT = 0x00000102;
    }
}
