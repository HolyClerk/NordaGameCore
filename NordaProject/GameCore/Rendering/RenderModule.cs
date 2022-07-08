using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;

using NordaProject.GameCore.Rendering.Buffering;

namespace NordaProject.GameCore.Rendering;

internal class RenderModule
{
    private Window _currentWindow;

    float[] vertices = new float[]
    {
        -0.5f, -0.5f, 0.0f,
        0.5f, -0.5f, 0.0f,
        -0.5f, 0.5f, 0.0f,
        0.5f, 0.5f, 0.0f,
    };

    float[] colors = new float[] 
    {
        1.0f, 0.0f, 0.0f, 1.0f,
        0.0f, 1.0f, 0.0f, 1.0f,
        0.0f, 0.0f, 1.0f, 1.0f,
        0.8f, 0.6f, 0.2f, 1.0f
    };

    public RenderModule(Window window)
    {
        _currentWindow = window;
    }

    public void RenderFrame()
    {
        vboVertex = CreateVBO(vertices);
        vboColor = CreateVBO(vertices);

        DrawVBO();
        DeleteVBO();
    }


    // ТЕСТ - В БУДУЩЕМ УДАЛИТЬ
    private int vboVertex = 0;
    private int vboColor = 0;

    private void DrawVBO()
    {
        GL.EnableClientState(ArrayCap.VertexArray);
        GL.EnableClientState(ArrayCap.ColorArray);

        GL.BindBuffer(BufferTarget.ArrayBuffer, vboVertex);
        GL.VertexPointer(3, VertexPointerType.Float, 0, 0);

        GL.BindBuffer(BufferTarget.ArrayBuffer, vboColor);
        GL.ColorPointer(4, ColorPointerType.Float, 0, 0);

        GL.DrawArrays(PrimitiveType.TriangleStrip, 0, 4);

        GL.BindBuffer(BufferTarget.ArrayBuffer, 0);

        GL.DisableClientState(ArrayCap.VertexArray);
        GL.DisableClientState(ArrayCap.ColorArray);
    }

    private int CreateVBO(float[] data)
    {
        int VBO = GL.GenBuffer();

        GL.BindBuffer(BufferTarget.ArrayBuffer, VBO);

        GL.BufferData(BufferTarget.ArrayBuffer, vertices.Length * sizeof(float), data, BufferUsageHint.StaticRead);

        GL.BindBuffer(BufferTarget.ArrayBuffer, 0);

        return VBO;
    }

    private void DeleteVBO()
    {
        GL.DeleteBuffer(vboVertex);
        GL.DeleteBuffer(vboColor);
    }
}