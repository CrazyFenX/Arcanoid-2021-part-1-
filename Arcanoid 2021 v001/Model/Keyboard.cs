using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Arcanoid_2021_v001.Model
{
    /// <summary>
    /// Обработка клавиатуры
    /// </summary>
    class Keyboard
    {
        private enum KeyStates
        {
            None = 0,
            Down = 1,
            Toggled = 2
        }
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        private static extern short GetKeyState(int keyCode);

        private static KeyStates GetKeyState(Keys key)
        {
            KeyStates state = KeyStates.None;

            short retVal = GetKeyState((int)key);

            if ((retVal & 0x800) == 0x800)
                state |= KeyStates.Down;

            if ((retVal & 1) == 1)
                state |= KeyStates.Toggled;

            return state;
        }

        public static bool IsKeyDown(Keys key)
        {
            return KeyStates.Down == (GetKeyState(key) & KeyStates.Down);
        }
        public static bool IsKeyToggled(Keys key)
        {
            return KeyStates.Toggled == (GetKeyState(key) & KeyStates.Toggled);
        }
    }
}
