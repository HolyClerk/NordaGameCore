using OpenTK.Graphics.OpenGL4;

namespace NordaProject.GameCore.Rendering;

internal class ShaderProgram
{
    private const int IncorrectErrorCode = 0;

    private readonly int _vertexShader = 0;
    private readonly int _fragmentShader = 0;

    private readonly int _program = 0;

    public ShaderProgram(string vertexShaderPath, string fragmentShaderPath)
    {
        _vertexShader = CreateNewShader(ShaderType.VertexShader, vertexShaderPath);
        _fragmentShader = CreateNewShader(ShaderType.FragmentShader, fragmentShaderPath);

        _program = GL.CreateProgram();
        GL.AttachShader(_program, _vertexShader);
        GL.AttachShader(_program, _fragmentShader);

        GL.LinkProgram(_program);

        GL.GetProgram(_program, GetProgramParameterName.LinkStatus, out int resultCode);

        if (resultCode == IncorrectErrorCode)
        {
            var infoLog = GL.GetProgramInfoLog(_program);
            throw new Exception($"Произошла ошибка при компиляции программы шейдера \nID: {_program}, Code: {resultCode} \n{infoLog}");
        }

        DeleteShader(_vertexShader);
        DeleteShader(_fragmentShader);
    }
    private int CreateNewShader(ShaderType shaderType, string shaderPath = @"C:\Users\PHPpr\Documents\Development\MainProjects\Norda\NordaProject\GameCore\Rendering\Shaders\shader.vert")
    {
        var shaderCode = File.ReadAllText(shaderPath);
        var shaderID = GL.CreateShader(shaderType);

        GL.ShaderSource(shaderID, shaderCode);
        GL.CompileShader(shaderID);

        GL.GetShader(shaderID, ShaderParameter.CompileStatus, out var resultCode);

        if (resultCode == IncorrectErrorCode)
        {
            var infoLog = GL.GetShaderInfoLog(shaderID);
            throw new Exception($"Произошла ошибка при компиляции шейдера \nID: {shaderID}, Code: {shaderCode} \n{infoLog}");
        }

        return shaderID;
    }

    public void Run() => GL.UseProgram(_program);

    public void Stop() => GL.UseProgram(0);

    public void Destroy() => GL.DeleteProgram(_program);

    private void DeleteShader(int shader)
    {
        GL.DetachShader(_program, shader);
        GL.DeleteShader(shader);
    }
}