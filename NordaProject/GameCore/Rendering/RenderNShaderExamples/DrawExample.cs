using NordaProject.GameCore.Rendering.Buffering;
using OpenTK.Graphics.OpenGL4;
using System.Diagnostics;

namespace NordaProject.GameCore.Rendering.RenderNShaderExamples;

public class DrawExample
{
    private const string SHADER_SOURCE = @"C:\Users\PHPpr\Documents\Development\MainProjects\Norda\NordaProject\GameCore\Rendering\Shaders\";

    private readonly float[] _vertices =
    {
        // positions        // colors
         0.5f, -0.5f, 0.0f,  1.0f, 0.0f, 0.0f,   // bottom right
        -0.5f, -0.5f, 0.0f,  0.0f, 1.0f, 0.0f,   // bottom left
         0.0f,  0.5f, 0.0f,  0.0f, 0.0f, 1.0f    // top 
    };

    private uint[] _indices =
    {
        0, 3, 1,    // 1 T
        3, 2, 1,    // 2 T
    };

    private VertexArray _VAO;
    private VertexBuffer _VBO;
    private ElementBuffer _EBO;

    private ShaderProgram _shaderProgram;

    private static Stopwatch _timer;

    public DrawExample()
    {
        _timer = new Stopwatch();
        _timer.Start();
        _shaderProgram = new ShaderProgram(SHADER_SOURCE + "shader.vert", SHADER_SOURCE + "shader.frag");

        _VAO = new();
        _VBO = new();
        _EBO = new();

        // Биндим VAO
        _VAO.Bind();

        // Копируем вершинные массивы в буфер 
        _VBO.Bind();
        _VBO.InitializeDataStore(_vertices, BufferTarget.ArrayBuffer, BufferUsageHint.DynamicDraw);

        _EBO.Bind();
        _EBO.InitializeDataStore(_indices, BufferUsageHint.DynamicDraw);

        // Устанавливаем точки аттрибутов вершин
        _VAO.SetAttributesPointers();
    }

    /*----------------------------COLOR----------------------------*/

    private float[] _verticesEx1 =
    {
         0.5f,  0.5f, 0.0f,  // Top right
         0.5f, -0.5f, 0.0f,  // Bottom right
        -0.5f, -0.5f, 0.0f,  // Bottom left
        -0.5f,  0.5f, 0.0f,  // Top left
    };

    private uint[] _indicesEx1 =
    {
        0, 3, 1,    // 1 T
        3, 2, 1,    // 2 T
    };

    bool _isLower = false;

    public void ChangeColor()
    {
        _shaderProgram.Use();

        double timeValue = _timer.Elapsed.TotalSeconds;
        float valueWithinOne = ((float)Math.Sin(timeValue) / 2f) + 0.5f;
        int vertexColorLocation = GL.GetUniformLocation(_shaderProgram.Handle, "ourColor");
        GL.Uniform4(vertexColorLocation, valueWithinOne, 0.0f, 0.0f, 1.0f);
        _VBO.InitializeDataStore(_verticesEx1, BufferTarget.ArrayBuffer);
        ScaleVertex(ref _verticesEx1[10]);
        ScaleVertex(ref _verticesEx1[1]);

        GL.DrawElements(PrimitiveType.Triangles, _indicesEx1.Length, DrawElementsType.UnsignedInt, 0);
    }

    public static void ScaleVertex(ref float vert)
    {
        float scaleValue = ((float)Math.Sin(_timer.Elapsed.TotalSeconds) / 2f) + 0.5f;
        vert = scaleValue;
    }
}

