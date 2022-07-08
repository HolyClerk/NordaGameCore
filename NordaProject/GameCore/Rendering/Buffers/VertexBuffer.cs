using OpenTK.Graphics.OpenGL4;

namespace NordaProject.GameCore.Rendering.Buffers;

public sealed class VertexBuffer
{
    public VertexBuffer(float[] vertices, BufferUsageHint hint = BufferUsageHint.StaticDraw, BufferTarget target = BufferTarget.ArrayBuffer)
    {
        VertexBufferObject = GL.GenBuffer();

        GL.BufferData(target, 
            vertices.Length * sizeof(float), 
            vertices,
            hint);
    }

    public readonly int VertexBufferObject;

    public bool IsBinded
    {
        get; private set;
    }

    public void Run()
    {
        IsBinded = true;
        GL.BindBuffer(BufferTarget.ArrayBuffer, VertexBufferObject);
    }

    public void Dispose()
    {
        IsBinded = false;
        GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
        GL.DeleteBuffer(VertexBufferObject);
    }
}