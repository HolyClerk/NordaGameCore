using OpenTK.Graphics.OpenGL4;

namespace NordaProject.GameCore.Rendering;

internal class ShaderProgram
{
    private const int IncorrectErrorCode = 0;

    private int _vertexShader = 0;

    public ShaderProgram()
    {

    }

    private int CreateNewShader(ShaderType shaderType, string shaderPath)
    {
        var shaderCode = File.ReadAllText(@"");
        var shaderID = GL.CreateShader(shaderType);

        GL.ShaderSource(shaderID, shaderCode);
        GL.CompileShader(shaderID);

        GL.GetShader(shaderID, ShaderParameter.CompileStatus, out var resultCode);

        if (resultCode == IncorrectErrorCode)
        {
            var infoLog = GL.GetShaderInfoLog(shaderID);
            throw new Exception($"Произошла ошибка при компиляции шейдера ID: {shaderID}, Code: {shaderCode} \n{infoLog}");
        }

        return shaderID;
    }
}

