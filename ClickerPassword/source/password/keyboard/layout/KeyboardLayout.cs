using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PasswordManager
{
    public class KeyboardLayout
    {
        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        private static extern uint GetWindowThreadProcessId(IntPtr hWnd, IntPtr lpdwProcessId);

        [DllImport("user32.dll")]
        private static extern IntPtr GetKeyboardLayout(uint idThread);

        [DllImport("kernel32.dll")]
        private static extern int GetLocaleInfo(uint Locale, uint LCType, StringBuilder lpLCData, int cchData);

        const uint LOCALE_SLANGUAGE = 0x00000002;

        // Import WinAPI
        [DllImport("user32.dll")]
        private static extern IntPtr LoadKeyboardLayout(string pwszKLID, uint Flags);

        [DllImport("user32.dll")]
        private static extern IntPtr ActivateKeyboardLayout(IntPtr hkl, uint Flags);

        // Flagi
        const uint KLF_ACTIVATE = 0x00000001;
        const uint KLF_SETFORPROCESS = 0x00000100;

        public static String getCurrentKeyboardLayout()
        {
            // Pobierz uchwyt aktywnego okna
            IntPtr foregroundWindow = GetForegroundWindow();

            // Pobierz ID wątku
            uint threadId = GetWindowThreadProcessId(foregroundWindow, IntPtr.Zero);

            // Pobierz uchwyt do układu klawiatury
            IntPtr keyboardLayout = GetKeyboardLayout(threadId);

            // ID języka (niskie 16 bitów)
            uint localeId = (uint)keyboardLayout & 0xFFFF;

            // Pobierz nazwę języka
            StringBuilder language = new StringBuilder(256);
            GetLocaleInfo(localeId, LOCALE_SLANGUAGE, language, language.Capacity);
            //Console.WriteLine("CurrentKeyboardLayout: " + language.ToString());
            return localeId.ToString("X8");
        }

        public static void setKeyboardLayout(String layoutId)
        {
            IntPtr hkl = LoadKeyboardLayout(layoutId, KLF_ACTIVATE);

            if (hkl != IntPtr.Zero)
            {
                ActivateKeyboardLayout(hkl, KLF_SETFORPROCESS);
                Console.WriteLine("Setup ActivateKeyboardLayout as: " + layoutId);
            }
            else
            {
                MessageBox.Show("Nie udało się załadować układu.");
            }            
        }
    }
}
