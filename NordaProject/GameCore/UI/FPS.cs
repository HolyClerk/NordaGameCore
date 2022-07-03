using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NordaProject.GameCore.UI;

internal class FPS
{
    private float _frameTime;
    private float _fps;
    private float _lastFps;

    public FPS() 
    { 
        _frameTime = 0.0f;
        _fps = 0.0f;
        _lastFps = 0.0f;
    }

    public void IncreaseFrameTime(double frameTime)
    {
        _frameTime += (float)frameTime;
        _fps++;
    }
    
    public float GetFPS()
    {
        // 1.0f обозначает одну секунду
        if (_frameTime >= 1.0f)
        {
            _lastFps = _fps;
            _frameTime = 0.0f;
            _fps = 0.0f;
        }

        return _lastFps;
    }
}

