using System;
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

        GL.ClearColor(Color4.Black);
        GL.Enable(EnableCap.CullFace);
        GL.CullFace(CullFaceMode.Back);
        // GL.PolygonMode(MaterialFace.Front, PolygonMode.Line);
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
    }

    protected override void OnRenderFrame(FrameEventArgs args)
    {
        base.OnRenderFrame(args);

        GL.Clear(ClearBufferMask.ColorBufferBit);

        Triangle triangleTemplate = new(
            (Vector2)(-0.2f, -0.2f),
            (Vector2)( 0.2f, -0.2f),
            (Vector2)(-0.2f,  0.2f));

        // GL.Rotate(0.3f, 0.0f, 1.0f, 0.0f);

        PrimitiveRenderer.CreateStripedTriangle(triangleTemplate, new Vector2[] 
        { 
            (Vector2)(0.2f, 0.2f),
            (Vector2)(0.2f, 0.6f),
            (Vector2)(-0.2f, 0.6f),

        });

        SwapBuffers();
    }

    protected override void OnUnload()
    {
        base.OnUnload();
    }
}