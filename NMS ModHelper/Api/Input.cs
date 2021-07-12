using NMS_ModHelper.Devices;
using System.Drawing;
using System.Runtime.InteropServices;

namespace NMS_ModHelper.Api
{
    /// <summary>
    /// Future class to handle keyboard and mouse inputs. Styled after Unity
    /// </summary>
    public class Input
    {
        public static bool GetKey()
        {
            return false;
        }

        public static bool GetKeyUp()
        {
            return false;
        }

        public static bool GetKeyDown(KeyCode keyCode)
        {
            return Keyboard.IsKeyDown(keyCode);
        }

        public static bool GetMouse(MouseButton button)
        {
            return false;
        }

        public static bool GetMouseDown(MouseButton button)
        {
            return Mouse.IsButtonDown(button);
        }

        public static bool GetMouseUp(MouseButton button)
        {
            return false;
        }


        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool GetCursorPos(out Point lpPoint);

        public static Point GetMousePosition()
        {
            GetCursorPos(out var position);
            return position;
        }

        
    }
}
