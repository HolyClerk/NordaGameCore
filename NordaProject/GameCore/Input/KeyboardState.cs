using OpenTK.Windowing.Common;
using OpenTK.Windowing.GraphicsLibraryFramework;

namespace NordaProject.GameCore.Input;

internal class KeyboardState
{
    private Window _currentWindow;

    public KeyboardState(Window currentWindow)
    {
        _currentWindow = currentWindow;

        _currentWindow.KeyDown  += OnKeyDown;
        _currentWindow.KeyUp    += OnKeyUp;
    }

    private void OnKeyUp(KeyboardKeyEventArgs obj)
    {
        if (obj.Key == Keys.Escape)
        {
            _currentWindow.Close();
        }
    }

    private void OnKeyDown(KeyboardKeyEventArgs obj)
    {

    }
}
