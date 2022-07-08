using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;

using NordaProject.GameCore.Primitives;
using NordaProject.GameCore.Primitives.Types;

namespace NordaProject.GameCore.Rendering;

public sealed class VertexBuffer
{
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

    public void CreateArrayBuffer(float[] vertices) 
    {
        GL.BufferData(BufferTarget.ArrayBuffer, vertices.Length * sizeof(float), vertices, BufferUsageHint.StaticDraw);
    }

    /// <summary>
    /// Bind Buffer
    /// </summary>
    public void Bind() 
    {
        GL.BindBuffer(_type, BufferObjName);
        IsBinded = true;
    }

    /// <summary>
    /// Bind Buffer
    /// </summary>
    public void Unbind()
    {
        GL.BindBuffer(_type, 0);
        IsBinded = false;
    }

    public void Draw()
    {
        GL.EnableClientState(ArrayCap.VertexArray);
        {
            GL.BindBuffer(BufferTarget.ArrayBuffer, BufferObjName);
            GL.VertexPointer(3, VertexPointerType.Float, 0, 0);
            GL.DrawArrays(PrimitiveType.TriangleStrip, 0, 4);
        }
        GL.DisableClientState(ArrayCap.VertexArray);
    }
}