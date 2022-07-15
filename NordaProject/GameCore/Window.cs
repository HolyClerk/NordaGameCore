using OpenTK.Windowing;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;

using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;

using NordaProject.GameCore.UI;
using NordaProject.GameCore.Input;
using NordaProject.GameCore.Rendering;

namespace NordaProject.GameCore;

public sealed class Window : GameWindow
{
    private readonly RenderModule _render;
    private readonly UserInterface _userInterface;
    private readonly KeyboardState _keyHandler;

    public Window(GameWindowSettings gameWindowSettings, NativeWindowSettings nativeWindowSettings) : base(gameWindowSettings, nativeWindowSettings)
    {
        _render = new(this);
        _userInterface = new(this);
        _keyHandler = new(this);
    }

    protected override void OnLoad()
    {
        GL.ClearColor(Color4.Black);
        GL.Enable(EnableCap.CullFace);
        GL.CullFace(CullFaceMode.Back);
        // GL.PolygonMode(MaterialFace.Front, PolygonMode.Line);
        _render.LoadResources();
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
        _render.RenderFrame();
        Context.SwapBuffers();
        base.OnRenderFrame(args);
    }

    protected override void OnUnload()
    {
        _render.UnloadResources();
        base.OnUnload();
    }
}