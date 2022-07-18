using OpenTK.Graphics.OpenGL4;
using System.Runtime.InteropServices;

namespace NordaProject.GameCore.Rendering.Buffering;

internal interface IBindable
{
    protected const int INCORRECT_CODE = -1;
    protected const int NULL_POINT = 0;

    /// <summary>
    /// Привязка объекта к идентификатору Gen Buffer
    /// </summary>
    public abstract void Bind();

    /// <summary>
    /// Отвязка объекта от идентификатора, object будет указывать на 0.
    /// </summary>
    public abstract void Unbind();
}

