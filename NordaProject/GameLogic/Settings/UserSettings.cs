using OpenTK.Windowing.Common;

namespace NordaProject.GameCore.Settings;

internal class UserSettings
{
    public static void SetUserSettings(Window window)
    {
        window.VSync = VSyncMode.On;
        window.CursorState = CursorState.Hidden;
    }
}

