using OpenTK.Graphics.OpenGL4;
using System.Runtime.InteropServices;

namespace NordaProject.GameCore.Rendering.Buffering;

public class ElementBuffer : IDisposable, IBuffer
{
    public ElementBuffer()
    { 
        
    }

    public int EBO 
    { 
        get; private set;
    }

    public bool IsBinded
    {
        get; private set;
    }

    public void InitializeDataStore<T>(T[] indices, BufferTarget target, BufferUsageHint hint = BufferUsageHint.StaticDraw)
    where T : struct
    {
        if (indices.Length < 1)
        {
            throw new ArgumentException("Массив вершин должен содержать хотя-бы одну вершину.", nameof(indices));
        }
        GL.BufferData(BufferTarget.ElementArrayBuffer, indices.Length * sizeof(uint), indices, BufferUsageHint.StaticDraw);
        GL.BufferData(target, (IntPtr)(indices.Length * Marshal.SizeOf(typeof(T))), indices, hint);
    }

    public void Bind()
    {
        throw new NotImplementedException();
    }

    public void UnBind()
    {
        throw new NotImplementedException();
    }

    public void Delete()
    {
        if (EBO == IBuffer.INCORRECT_CODE)
        {
            return;
        }

        UnBind();
        GL.DeleteVertexArray(EBO);

        EBO = IBuffer.INCORRECT_CODE;
    }

    public void Dispose()
    {
        Delete();
        GC.SuppressFinalize(this);
    }
}

