using OpenTK.Mathematics;

namespace NordaProject.GameCore.UI;

internal class UserInterface
{
    private Window _currentWindow;
    private FPS _framePerSecond;

    public UserInterface(Window window)
    {
        _currentWindow = window;
        _framePerSecond = new FPS();
    }

    public void Update()
    {

    }

    public void ShowFPSinTitle()
    {
        _framePerSecond.IncreaseFrameTime(_currentWindow.RenderTime);
        _currentWindow.Title = $@"Игровое окно FPS: {_framePerSecond.GetFPS()} ";
    }

    public void ShowMouseCoordInTitle()
    {
        var mousePos = _currentWindow.MousePosition.Normalized();

        _currentWindow.Title = $"Mouse Pos " +
            $"X:{mousePos.X} " +
            $"Y:{mousePos.Y} ";
    }
}

