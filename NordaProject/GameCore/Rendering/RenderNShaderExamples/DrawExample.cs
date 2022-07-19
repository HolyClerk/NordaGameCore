using NordaProject.GameCore.Rendering.Buffering;
using OpenTK.Graphics.OpenGL4;
using System.Diagnostics;

namespace NordaProject.GameCore.Rendering.RenderNShaderExamples;

public class DrawExample
{
    private const string SHADER_SOURCE = @"C:\Users\PHPpr\Documents\Development\MainProjects\Norda\NordaProject\GameCore\Rendering\Shaders\";

    private float[] _vertices =
    {
         0.5f,  0.5f, 0.0f,  // Top right
         0.5f, -0.5f, 0.0f,  // Bottom right
        -0.5f, -0.5f, 0.0f,  // Bottom left
        -0.5f,  0.5f, 0.0f,  // Top left
    };

    private uint[] _indices =
    {
        0, 3, 1,    // 1 T
        3, 2, 1,    // 2 T
    };

    private VertexBuffer _VBO;
    private ElementBuffer _EBO;
    private VertexArray _VAO;

    private ShaderProgram _shaderProgram;

    private Stopwatch _timer;

    public DrawExample()
    {
        _timer = new Stopwatch();
        _timer.Start();
        _shaderProgram = new ShaderProgram(SHADER_SOURCE + "shader.vert", SHADER_SOURCE + "shader.frag");

        _VAO = new();
        _VBO = new();
        _EBO = new();

        // 1. Биндим VAO
        _VAO.Bind();

        // 2. Копируем вершинные массивы в буфер 
        _VBO.Bind();
        _VBO.InitializeDataStore(_vertices, BufferTarget.ArrayBuffer);

        _EBO.Bind();
        _EBO.InitializeDataStore(_indices);

        // 3. Устанавливаем точки аттрибутов вершин
        _VAO.SetAttributesPointers();
    }

    public void ChangeColor()
    {
        // be sure to activate the shader
        _shaderProgram.Use();

        // update the uniform color
        double timeValue = _timer.Elapsed.TotalSeconds;
        float greenValue = ((float)Math.Sin(timeValue) / 2f) + 0.5f;
        int vertexColorLocation = GL.GetUniformLocation(_shaderProgram.Handle, "ourColor");
        GL.Uniform4(vertexColorLocation, 0.0f, greenValue, 0.0f, 1.0f);
        Console.WriteLine(greenValue);
        _VAO.Bind();
        GL.DrawElements(PrimitiveType.Triangles, _indices.Length, DrawElementsType.UnsignedInt, 0);
    }
}

