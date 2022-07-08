using OpenTK.Windowing;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;

using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;

using NordaProject.GameCore.UI;
using NordaProject.GameCore.Keyboard;
using NordaProject.GameCore.Rendering;
using NordaProject.GameCore.Rendering.Buffering;

namespace NordaProject.GameCore;

public sealed class Window : GameWindow
{
    private RenderModule _render;
    private UserInterface _userInterface;
    private KeyHandler _keyHandler;

    public Window(GameWindowSettings gameWindowSettings, NativeWindowSettings nativeWindowSettings) : base(gameWindowSettings, nativeWindowSettings)
    {
        _render = new();
        _userInterface = new(this);
        _keyHandler = new(this);
    }

    protected override void OnLoad()
    {
        GL.ClearColor(Color4.Black);
        GL.Enable(EnableCap.CullFace);
        GL.CullFace(CullFaceMode.Back);
        // GL.PolygonMode(MaterialFace.Front, PolygonMode.Line);
        base.OnLoad();
    }

    protected override void OnResize(ResizeEventArgs e)
    {
        GL.Viewport(0, 0, e.Width, e.Height);
        base.OnResize(e);
    }

    protected override void OnUpdateFrame(FrameEventArgs args)
    {
        _userInterface.Update();
        _userInterface.ShowFPSinTitle();
        _userInterface.ShowMouseCoordInTitle();

        base.OnUpdateFrame(args);
    }

    protected override void OnRenderFrame(FrameEventArgs args)
    {
        GL.Clear(ClearBufferMask.ColorBufferBit);

        // Модуль рендера вынесен в отдельное окно.
        _render.RenderFrame();

        Context.SwapBuffers();
        base.OnRenderFrame(args);
    }

    protected override void OnUnload()
    {
        base.OnUnload();
    }
}