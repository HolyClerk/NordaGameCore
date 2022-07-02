using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;

using NordaProject.Debug;

namespace NordaProject.GameCore;

internal class Game
{
    private static Window _gameWindow;

    public static void Initialize()
    {
        var gameWindowSettings = new GameWindowSettings()
        {
            RenderFrequency = 60,
            UpdateFrequency = 60,
        };

        var nativeWindowSettings = new NativeWindowSettings()
        {
            Title = "Test Window",
            Size = new Vector2i(800, 600),
            Flags = ContextFlags.Default,
            Profile = ContextProfile.Core,
        };

        using (_gameWindow)
        {
            _gameWindow = new Window(gameWindowSettings, nativeWindowSettings);
            _gameWindow.Run();
        }
    }
}

