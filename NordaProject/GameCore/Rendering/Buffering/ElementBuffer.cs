using OpenTK.Graphics.OpenGL4;
using System.Runtime.InteropServices;

namespace NordaProject.GameCore.Rendering.Buffering;

public class ElementBuffer : IDisposable, IBindable
{
    public ElementBuffer() => EBO = GL.GenBuffer();

    public int EBO 
    { 
        get; private set;
    }

    public bool IsBinded
    {
        get; private set;
    }

    public void InitializeDataStore(uint[] indices, BufferUsageHint hint = BufferUsageHint.StaticDraw)
    {
        if (indices.Length < 1)
        {
            throw new ArgumentException("Массив вершин должен содержать хотя-бы одну вершину.", nameof(indices));
        }

        GL.BufferData(BufferTarget.ElementArrayBuffer,
            indices.Length * sizeof(uint),
            indices,
            hint);
    }

    public void Bind()
    {
        IsBinded = true;
        GL.BindBuffer(BufferTarget.ElementArrayBuffer, EBO);
    }

    public void Unbind()
    {
        IsBinded = false;
        GL.BindBuffer(BufferTarget.ElementArrayBuffer, IBindable.NULL_POINT);
    }

    private void DeleteBuffer()
    {
        if (EBO == IBindable.INCORRECT_CODE)
        {
            return;
        }

        Unbind();
        GL.DeleteVertexArray(EBO);

        EBO = IBindable.INCORRECT_CODE;
    }

    public void Dispose()
    {
        DeleteBuffer();
        GC.SuppressFinalize(this);
    }
}