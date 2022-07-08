using System.Text;

using OpenTK.Graphics.OpenGL;

namespace NordaProject.GameCore.Rendering;

public class Shader : IDisposable
{
    private int _vertexShader;
    private int _fragmentShader;

    private bool _disposedValue = false;

    public Shader(string vertexShaderPath, string fragmentShaderPath)
    {
        // Берем коды шейдеров из исходников.
        string VertexShaderSource;

        using (StreamReader reader = new StreamReader(vertexShaderPath, Encoding.UTF8))
        {
            VertexShaderSource = reader.ReadToEnd();
        }

        string FragmentShaderSource;

        using (StreamReader reader = new StreamReader(fragmentShaderPath, Encoding.UTF8))
        {
            FragmentShaderSource = reader.ReadToEnd();
        }

        // Привязываем шейдеры к их исходникам.
        _vertexShader = GL.CreateShader(ShaderType.VertexShader);
        GL.ShaderSource(_vertexShader, VertexShaderSource);

        _fragmentShader = GL.CreateShader(ShaderType.FragmentShader);
        GL.ShaderSource(_fragmentShader, FragmentShaderSource);

        // Компилируем.
        CompileShader(ref _vertexShader, ShaderType.VertexShader);
        CompileShader(ref _fragmentShader, ShaderType.FragmentShader);

        // Создаем и линкуем ShaderProgram.
        LinkProgram();

        // Отсоединяем шейдеры.
        Detach();
    }

    public int Handle
    {
        get; private set;
    }

    private void CompileShader(ref int shader, ShaderType shaderType)
    {
        GL.CompileShader(shader);

        GL.GetShader(shader, ShaderParameter.CompileStatus, out int success);
        if (success == 0)
        {
            string infoLog = GL.GetShaderInfoLog(shader);
            Console.WriteLine(infoLog);
        }
    }

    private void LinkProgram()
    {
        Handle = GL.CreateProgram();

        GL.AttachShader(Handle, _vertexShader);
        GL.AttachShader(Handle, _fragmentShader);

        GL.LinkProgram(Handle);

        GL.GetProgram(Handle, GetProgramParameterName.LinkStatus, out int success);
        if (success == 0)
        {
            string infoLog = GL.GetProgramInfoLog(Handle);
            Console.WriteLine(infoLog);
        }
    }

    private void Detach()
    {
        GL.DetachShader(Handle, _vertexShader);
        GL.DetachShader(Handle, _fragmentShader);
        GL.DeleteShader(_fragmentShader);
        GL.DeleteShader(_vertexShader);
    }

    public void Use()
    {
        GL.UseProgram(Handle);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!_disposedValue)
        {
            GL.DeleteProgram(Handle);

            _disposedValue = true;
        }
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    ~Shader() => GL.DeleteProgram(Handle);
}