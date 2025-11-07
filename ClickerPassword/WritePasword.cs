using PasswordManager;
using System;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace ClickerPassword
{

    public class WritePasword
    {
        [StructLayout(LayoutKind.Sequential)]
        struct INPUT
        {
            public int type;
            public InputUnion u;
        }

        [StructLayout(LayoutKind.Explicit)]
        struct InputUnion
        {
            [FieldOffset(0)]
            public MOUSEINPUT mi;
            [FieldOffset(0)]
            public KEYBDINPUT ki;
            [FieldOffset(0)]
            public HARDWAREINPUT hi;
        }


        [StructLayout(LayoutKind.Sequential)]
        struct MOUSEINPUT
        {
            public int dx;
            public int dy;
            public uint mouseData;
            public uint dwFlags;
            public uint time;
            public IntPtr dwExtraInfo;
        }

        [StructLayout(LayoutKind.Sequential)]
        struct KEYBDINPUT
        {
            public ushort wVk;
            public ushort wScan;
            public uint dwFlags;
            public uint time;
            public IntPtr dwExtraInfo;
        }

        [StructLayout(LayoutKind.Sequential)]
        struct HARDWAREINPUT
        {
            public uint uMsg;
            public ushort wParamL;
            public ushort wParamH;
        }

        [DllImport("user32.dll", SetLastError = true)]
        static extern uint SendInput(uint nInputs, INPUT[] pInputs, int cbSize);

        const int INPUT_KEYBOARD = 1;
        const uint KEYEVENTF_KEYUP = 0x0002;
        const ushort VK_SHIFT = 0x10;
        const ushort VK_CAPITAL = 0x14; // CapsLock key

        public static void write(String password, string keyboardLayout)
        {
            INPUT[] inputs = new INPUT[password.Length * 4];

            int inputIndex = 0;

            for (int i = 0; i < password.Length; i++)
            {
                char c = password[i];
                short vKey = VkKeyScan(c);
                bool shift = (vKey & 0x0100) != 0;
                ushort vkCode = (ushort)(vKey & 0xFF);

                if (shift)
                {
                    inputs[inputIndex++] = new INPUT
                    {
                        type = INPUT_KEYBOARD,
                        u = new InputUnion
                        {
                            ki = new KEYBDINPUT
                            {
                                wVk = VK_SHIFT,
                                wScan = 0,
                                dwFlags = 0,
                                time = 0,
                                dwExtraInfo = IntPtr.Zero
                            }
                        }
                    };
                }

                inputs[inputIndex++] = new INPUT
                {
                    type = INPUT_KEYBOARD,
                    u = new InputUnion
                    {
                        ki = new KEYBDINPUT
                        {
                            wVk = vkCode,
                            wScan = 0,
                            dwFlags = 0,
                            time = 0,
                            dwExtraInfo = IntPtr.Zero
                        }
                    }
                };

                inputs[inputIndex++] = new INPUT
                {
                    type = INPUT_KEYBOARD,
                    u = new InputUnion
                    {
                        ki = new KEYBDINPUT
                        {
                            wVk = vkCode,
                            wScan = 0,
                            dwFlags = KEYEVENTF_KEYUP,
                            time = 0,
                            dwExtraInfo = IntPtr.Zero
                        }
                    }
                };

                if (shift)
                {
                    inputs[inputIndex++] = new INPUT
                    {
                        type = INPUT_KEYBOARD,
                        u = new InputUnion
                        {
                            ki = new KEYBDINPUT
                            {
                                wVk = VK_SHIFT,
                                wScan = 0,
                                dwFlags = KEYEVENTF_KEYUP,
                                time = 0,
                                dwExtraInfo = IntPtr.Zero
                            }
                        }
                    };
                }
            }
            bool isCapsLockActive = IsCapsLockActive();
            if (isCapsLockActive)
            {
                ToggleCapsLock();
            }

            uint result = SendInput((uint)inputIndex, inputs, Marshal.SizeOf(typeof(INPUT)));

            if (isCapsLockActive)
            {
                ToggleCapsLock();
            }
            if (result == 0)
            {
                MessageBox
                    .Show("Error while sending input.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        static short VkKeyScan(char ch)
        {
            return VkKeyScanA(ch);
        }

        [DllImport("user32.dll")]
        static extern short VkKeyScanA(char ch);

        public static bool IsCapsLockActive()
        {
            return Console.CapsLock;
        }

        public static void ToggleCapsLock()
        {
            INPUT[] inputDown = new INPUT[1];
            inputDown[0].type = 1;
            inputDown[0].u.ki.wVk = VK_CAPITAL;
            inputDown[0].u.ki.dwFlags = 0;

            INPUT[] inputUp = new INPUT[1];
            inputUp[0].type = 1;
            inputUp[0].u.ki.wVk = VK_CAPITAL;
            inputUp[0].u.ki.dwFlags = KEYEVENTF_KEYUP;

            SendInput(1, inputDown, Marshal.SizeOf(typeof(INPUT)));
            SendInput(1, inputUp, Marshal.SizeOf(typeof(INPUT)));
        }

        public static void WarningIfCapslockIsActive()
        {
            if (IsCapsLockActive())
            {
                MessageBox.Show("Your Caps Lock is active.",
                    "WARNING",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }
    }

}