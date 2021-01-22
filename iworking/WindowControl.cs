using System.Diagnostics;
using System.Text;

namespace Hook
{
    public static class WindowControl
    {
        public static string GetTopWindowTitle()
        {
            const int nChars = 256;
            int handle = 0;
            StringBuilder Buff = new StringBuilder(nChars);
            handle = WinAPI.GetForegroundWindow();
            if (WinAPI.GetWindowText(handle, Buff, nChars) > 0)
            {
                //trace("handle", handle.ToString());
                return Buff.ToString();
            }

            return "";
        }

        public static Process GetTopWindowProcess()
        {
            int handle = WinAPI.GetForegroundWindow();

            Process[] ps = Process.GetProcesses();

            for (int i = 0; i < ps.Length; i++)
            {
                Process p = ps[i];
                if (p.MainWindowHandle == (System.IntPtr)handle)
                {
                    return p;
                }
            }

            return null;
        }
    }
}
