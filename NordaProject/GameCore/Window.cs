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
using NordaProject.GameCore.Rendering;
using NordaProject.GameCore.Rendering.Buffering;

namespace NordaProject.GameCore;

public sealed class Window : GameWindow
{
    private RenderModule _gameRender;
    private UserInterface _UI;
    private KeyEventsHandler _defaultKBevents;

    public Window(GameWindowSettings gameWindowSettings, NativeWindowSettings nativeWindowSettings) : base(gameWindowSettings, nativeWindowSettings)
    {
        _gameRender = new(this);
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

        _gameRender.RenderFrame();

        SwapBuffers();
    }

    protected override void OnUnload()
    {
        base.OnUnload();
    }
}