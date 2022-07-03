using OpenTK.Windowing.Common;
using OpenTK.Windowing.GraphicsLibraryFramework;

namespace NordaProject.GameCore;

internal class KeyEventsHandler
{
    private Window _window;

    public KeyEventsHandler(Window currentWindow)
    {
        _window = currentWindow;

        _window.KeyDown += OnKeyDown;
        _window.KeyUp += OnKeyUp;
    }

    private void OnKeyUp(KeyboardKeyEventArgs obj)
    {
        if (obj.Key == Keys.Escape)
        {
            _window.Close();
        }
    }

    private void OnKeyDown(KeyboardKeyEventArgs obj)
    {
        
    }
}
