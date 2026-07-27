using System;
using System.Runtime.InteropServices;
using System.Text;

namespace ClickerPassword
{

    public class Window
    {

        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);

        private static string GetActiveWindowTitle(IntPtr hWnd)
        {
            const int nChars = 256;
            StringBuilder buffer = new StringBuilder(nChars);

            if (GetWindowText(hWnd, buffer, nChars) > 0)
            {
                return buffer.ToString();
            }
            return null;
        }

        private static uint GetActiveWindowProcessId(IntPtr hWnd)
        {
            GetWindowThreadProcessId(hWnd, out uint processId);
            return processId;
        }

        public static string getActiveWindowTitle()
        {
            IntPtr activeWindow = GetForegroundWindow();
            string windowTitle = GetActiveWindowTitle(activeWindow);
            return RemoveBrowserName(windowTitle);
        }

        public static string RemoveBrowserName(string windowTitle)
        {
            if (string.IsNullOrEmpty(windowTitle))
            {
                return windowTitle;
            }

            string[] parts = windowTitle.Split(new[] { " - " }, StringSplitOptions.None);

            if (parts.Length > 1)
            {
                return string.Join(" - ", parts, 0, parts.Length - 1);
            }

            return windowTitle;
        }

    }
}
