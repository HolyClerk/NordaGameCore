using OpenTK.Graphics.OpenGL4;
namespace NordaProject.GameCore.Rendering.Buffering;

internal interface IBuffer
{
    protected const int INCORRECT_CODE = -1;
    protected const int NULL_POINT = 0;

    public abstract void Bind();

    public abstract void UnBind();

    public abstract void InitializeDataStore<T>(T[] vertices, BufferTarget target, BufferUsageHint hint = BufferUsageHint.StaticDraw) 
        where T : struct;

    public abstract void Delete();
}

