using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;

using NordaProject.GameCore.Settings;

namespace NordaProject.GameCore;

internal class Game
{
    private static Window? _gameWindow;

    private GameWindowSettings _gameWinSettings;
    private NativeWindowSettings _nativeWinSettings;

    public Game()
    {
        _gameWinSettings = new GameWindowSettings()
        {
            RenderFrequency = 60,
            UpdateFrequency = 60,
        };

        _nativeWinSettings = new NativeWindowSettings()
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
    }

    public void Run()
    {
        using (_gameWindow = new Window(_gameWinSettings, _nativeWinSettings))
        {
            UserSettings.SetUserSettings(_gameWindow);
            _gameWindow.Run();
        }
    }
}