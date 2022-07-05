using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;

using NordaProject.Debug;
using NordaProject.GameCore.Settings;

namespace NordaProject.GameCore;

internal class Game
{
    private static Window? _gameWindow;

    public static void Initialize()
    {
        var gameWindowSettings = new GameWindowSettings()
        {
            RenderFrequency = 60,
            UpdateFrequency = 60,
        };

        var nativeWindowSettings = new NativeWindowSettings()
        {
            Title = "Игровое окно",

            Size = new Vector2i(800, 600),
            Location = new Vector2i(300, 300),
            MinimumSize = new Vector2i(800, 600),

            WindowBorder = WindowBorder.Resizable,
            WindowState = WindowState.Normal,

            StartVisible = true,
            StartFocused = true,

            // Flags = ContextFlags.ForwardCompatible,
            Flags = ContextFlags.Default,
            // Profile = ContextProfile.Core,
            Profile = ContextProfile.Compatability,

            API = ContextAPI.OpenGL,
            APIVersion = new Version(4, 6),
            
            NumberOfSamples = 0,
        };

        using (_gameWindow = new Window(gameWindowSettings, nativeWindowSettings))
        {
            UserSettings.SetUserSettings(_gameWindow);
            _gameWindow.Run();
        }
    }
}