using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

    public void UpdateUI()
    {

    }

    public void ShowFPSinTitle()
    {
        _framePerSecond.IncreaseFrameTime(_currentWindow.RenderTime);
        _currentWindow.Title = $@"Игровое окно FPS: {_framePerSecond.GetFPS()}";
    }
}

