using OpenTK.Graphics.OpenGL4;

namespace NordaProject.GameCore.Rendering.Buffering;

public sealed class VertexArray : IDisposable, IBindable
{
    public VertexArray() => VAO = GL.GenVertexArray();

    public int VAO
    {
        get; private set;
    }

    public bool IsBinded
    {
        get; private set;
    }

    public void Bind()
    {
        IsBinded = true;
        GL.BindVertexArray(VAO);
    }

    public void Unbind()
    {
        IsBinded = false;
        GL.BindVertexArray(IBindable.NULL_POINT);
    }

    public void SetAttributesPointers()
    {
        GL.EnableVertexAttribArray(0);
        GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 3 * sizeof(float), 0);
    }

    public void SetAttributesPointers(int index, int stride, int offset, int size = 3, VertexAttribPointerType type = VertexAttribPointerType.Float, bool normalized = false)
    {
        GL.EnableVertexAttribArray(index);
        GL.VertexAttribPointer(index, size, type, normalized, stride * sizeof(float), offset);
    }

    private void DeleteVAO()
    {
        if (VAO == IBindable.INCORRECT_CODE)
        {
            return;
        }

        Unbind();
        GL.DeleteVertexArray(VAO);

        VAO = IBindable.INCORRECT_CODE;
    }

    public void Dispose()
    {
        DeleteVAO();
        GC.SuppressFinalize(this);
    }
}