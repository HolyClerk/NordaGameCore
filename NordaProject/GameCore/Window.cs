﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenTK;
using OpenTK.Windowing;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;

using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;

using NordaProject.GameCore.UI;
using NordaProject.GameCore.Keyboard;
using NordaProject.GameCore.Primitives;
using NordaProject.GameCore.Primitives.Types;

namespace NordaProject.GameCore;

public sealed class Window : GameWindow
{
    private UserInterface _UI;
    private KeyEventsHandler _defaultKBevents;

    public Window(GameWindowSettings gameWindowSettings, NativeWindowSettings nativeWindowSettings) : base(gameWindowSettings, nativeWindowSettings)
    {
        _UI = new(this);
        _defaultKBevents = new(this);
    }

    protected override void OnLoad()
    {
        base.OnLoad();

        GL.ClearColor(Color4.White);
    }

    protected override void OnResize(ResizeEventArgs e)
    {
        base.OnResize(e);
    }

    protected override void OnUpdateFrame(FrameEventArgs args)
    {
        base.OnUpdateFrame(args);

        _UI.Update();
        _UI.ShowFPSinTitle();
        _UI.ShowMouseCoordInTitle();

        PrimitiveImplementer.CreatePoint(MousePosition, 10);
    }

    protected override void OnRenderFrame(FrameEventArgs args)
    {
        base.OnRenderFrame(args);

        GL.Clear(ClearBufferMask.ColorBufferBit);

        Triangle triangleTemplate = new(
            (Vector2)(-0.6f, -0.4f),
            (Vector2)(0.0f, 0.3f),
            (Vector2)(0.4f, 0.1f));

        PrimitiveImplementer.CreateTriangle(triangleTemplate);

        PrimitiveImplementer.CreatePoint(new Point(0.0f, 0.5f, 10));

        SwapBuffers();
    }

    protected override void OnUnload()
    {
        base.OnUnload();
    }
}