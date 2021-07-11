using NMS_ModHelper.Api;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace NMS_ModHelper.Devices
{
    internal class Mouse
    {
        static List<MouseButton> pressedKeys = new List<MouseButton>();

        const int KEY_PRESSED = 0x8000;

        [DllImport("USER32.dll")]
        static extern short GetKeyState(MouseButton mouseButton);

        internal static bool IsButtonDown(MouseButton mouseButton)
        {
            bool isPressed = Convert.ToBoolean(GetKeyState(mouseButton) & KEY_PRESSED);

            if (isPressed && !pressedKeys.Contains(mouseButton))
                pressedKeys.Add(mouseButton);

            return isPressed;
        }
    }
}
