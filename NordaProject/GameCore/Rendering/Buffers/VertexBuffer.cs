using System.Runtime.InteropServices;

using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;

namespace NordaProject.GameCore.Rendering.Buffering;

public sealed class VertexBuffer : IDisposable 
{
    private const int IncorrectCode = -1;

    private readonly BufferTarget _type;

    public VertexBuffer(BufferTarget bufferType)
    {
        BufferObjName = GL.GenBuffer();
        _type = bufferType;
    }

    public int BufferObjName
    {
        get;
        private set;
    }

    public bool IsBinded
    {
        get;
        private set;
    }

    public void Bind()
    {
        GL.BindBuffer(_type, BufferObjName);
        IsBinded = true;
    }

    public void Unbind()
    {
        GL.BindBuffer(_type, 0);
        IsBinded = false;
    }

    public void SetBufferData<T>(T[] data, BufferUsageHint hint) where T : struct
    {
        if (data.Length < 1)
        {
            throw new ArgumentException("Количество данных в массиве должно быть больше 0");
        }

        Bind();

        GL.BufferData(
            _type, 
            (IntPtr)(data.Length * Marshal.SizeOf(typeof(T))), 
            data, 
            BufferUsageHint.StaticDraw);
    }

    public void DeleteBuffer()
    {
        if (BufferObjName == IncorrectCode)
        {
            return;
        }

        Unbind();

        GL.DeleteBuffer(BufferObjName);

        BufferObjName = IncorrectCode;
    }

    public void Dispose()
    {
        DeleteBuffer();
        GC.Collect();
    }
}