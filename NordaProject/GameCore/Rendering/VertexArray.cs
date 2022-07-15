using OpenTK.Graphics.OpenGL4;

namespace NordaProject.GameCore.Rendering;

public sealed class VertexArray
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

    public void UnBind()
    {
        IsBinded = false;
        GL.BindVertexArray(0);
    }

    public void SetAttributesPointers()
    {
        GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 3 * sizeof(float), 0);
        GL.EnableVertexAttribArray(0);
    }
}