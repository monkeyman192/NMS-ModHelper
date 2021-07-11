using NMS_ModHelper.Api;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace NMS_ModHelper.Devices
{
    internal class Keyboard
    {
        static List<KeyCode> pressedKeys = new List<KeyCode>();

        const int KEY_PRESSED = 0x8000;

        [DllImport("USER32.dll")]
        static extern short GetKeyState(KeyCode keyCode);

        internal static bool IsKeyDown(KeyCode keyCode)
        {
            bool isPressed = Convert.ToBoolean(GetKeyState(keyCode) & KEY_PRESSED);

            if (isPressed && !pressedKeys.Contains(keyCode))
                pressedKeys.Add(keyCode);

            return isPressed;
        }
    }
}
