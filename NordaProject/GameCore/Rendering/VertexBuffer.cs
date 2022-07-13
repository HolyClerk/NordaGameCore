using OpenTK.Graphics.OpenGL4;
using System.Runtime.InteropServices;

namespace NordaProject.GameCore.Rendering;

public sealed class VertexBuffer : IDisposable
{
    private const int INCORRECT_CODE = -1;

    public VertexBuffer() => VBOID = GL.GenBuffer();

    public VertexBuffer(float[] vertices, BufferTarget target, BufferUsageHint hint = BufferUsageHint.StaticDraw)
    {
        VBOID = GL.GenBuffer();

        GL.BufferData(target,
            vertices.Length * sizeof(float),
            vertices,
            hint);
    }

    public int VBOID
    {
        get; private set;
    }

    public bool IsBinded
    {
        get; private set;
    }

    public void InitializeDataStore<T>(T[] vertices, BufferTarget target, BufferUsageHint hint = BufferUsageHint.StaticDraw)
    where T : struct
    {
        if (vertices.Length < 1)
        {
            throw new ArgumentException("Массив вершин должен содержать хотя-бы одну вершину.", nameof(vertices));
        }

        GL.BufferData(target, (IntPtr)(vertices.Length * Marshal.SizeOf(typeof(T))), vertices, hint);
    }

    private void Bind()
    {
        IsBinded = true;
        GL.BindBuffer(BufferTarget.ArrayBuffer, VBOID);
    }

    private void Unbind()
    {
        IsBinded = false;
        GL.BindBuffer(BufferTarget.ArrayBuffer, 0); // nullptr
    }

    public void Run() => Bind();

    public void Stop() => Unbind();

    private void DeleteBuffer()
    {
        if (VBOID == INCORRECT_CODE)
        {
            return;
        }

        Unbind();
        GL.DeleteBuffer(VBOID);

        VBOID = INCORRECT_CODE;
    }

    public void Dispose()
    {
        DeleteBuffer();
        GC.SuppressFinalize(this);
    }
}