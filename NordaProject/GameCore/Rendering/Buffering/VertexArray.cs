using OpenTK.Graphics.OpenGL4;

namespace NordaProject.GameCore.Rendering.Buffering;

public sealed class VertexArray : IDisposable
{
    private const int INCORRECT_CODE = -1;
    private const int NULL_POINT = 0;

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
        GL.BindVertexArray(NULL_POINT);
    }

    public void SetAttributesPointers()
    {
        GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 3 * sizeof(float), 0);
        GL.EnableVertexAttribArray(0);
    }

    private void DeleteVAO()
    {
        if (VAO == INCORRECT_CODE)
        {
            return;
        }

        Unbind();
        GL.DeleteVertexArray(VAO);

        VAO = INCORRECT_CODE;
    }

    public void Dispose()
    {
        DeleteVAO();
        GC.SuppressFinalize(this);
    }
}