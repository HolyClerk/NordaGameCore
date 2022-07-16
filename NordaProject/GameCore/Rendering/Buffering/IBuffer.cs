using OpenTK.Graphics.OpenGL4;
namespace NordaProject.GameCore.Rendering.Buffering;

internal interface IBuffer
{
    protected const int INCORRECT_CODE = -1;
    protected const int NULL_POINT = 0;

    /// <summary>
    /// Привязка объекта к идентификатору Gen Buffer
    /// </summary>
    public abstract void Bind();

    /// <summary>
    /// Отвязка объекта от идентификатора, object будет указывать на
    /// 0.
    /// </summary>
    public abstract void Unbind();

    /// <summary>
    /// Создает и инициализирует данные объекта буффера.
    /// </summary>
    /// <typeparam name="T">Структурный тип</typeparam>
    /// <param name="vertices">Массив вершин</param>
    /// <param name="target">Таргет, в который обработаются входящие данные</param>
    /// <param name="hint">Тип отрисовки</param>
    public abstract void InitializeDataStore<T>(T[] vertices, BufferTarget target, BufferUsageHint hint = BufferUsageHint.StaticDraw) 
        where T : struct;

    /// <summary>
    /// Удаление и высвобождение ресурсов Buffer Object
    /// </summary>
    protected virtual void DeleteBuffer() { }
}

