using OpenTK.Mathematics;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Windowing.Common;

namespace NordaProject.GameCore.Rendering;

internal sealed class RenderModule
{
    private const string SHADER_SOURCE = @"C:\Users\PHPpr\Documents\Development\MainProjects\Norda\NordaProject\GameCore\Rendering\Shaders\";

    private float[] vertices =
    {
        -0.5f, -0.5f, 0.0f, //Bottom-left vertex
         0.5f, -0.5f, 0.0f, //Bottom-right vertex
         0.0f,  0.5f, 0.0f  //Top vertex
    };

    private float[] vertices2 =
    {
        -0.5f, -0.5f, 0.0f, //Bottom-left vertex
         0.5f, -0.5f, 0.0f, //Bottom-right vertex
         0.0f,  0.5f, 0.0f  //Top vertex
    };

    private int _vertexBuffer = 0;
    private int _vertexArray = 0;

    private VertexBuffer _VBO;
    private VertexArray _VAO;

    private ShaderProgram _shaderProgram;

    public RenderModule(Window gameWindow)
    {
        /*// Иниц. VBO & VAO
        _vertexBufferObject = GL.GenBuffer();
        _vertexArrayObject = GL.GenVertexArray();

        // 1. Привязываем Vertex Array Object
        GL.BindVertexArray(_vertexArrayObject);

        // 2. Копируем наш vertices array в буфер openGL
        GL.BindBuffer(BufferTarget.ArrayBuffer, _vertexBufferObject);
        GL.BufferData(BufferTarget.ArrayBuffer, vertices.Length * sizeof(float), vertices, BufferUsageHint.DynamicDraw);

        // 3. then set our vertex attributes pointers
        GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 3 * sizeof(float), 0);
        GL.EnableVertexAttribArray(0);*/
    }

    public void LoadResources()
    {
        _shaderProgram = new ShaderProgram(SHADER_SOURCE + "shader.vert", SHADER_SOURCE + "shader.frag");

        // ..:: Initialization code (done once (unless your object frequently changes)) :: ..
        // 1. bind Vertex Array Object
        _VAO = new();
        _VAO.Bind();

        // 2. copy our vertices array in a buffer for OpenGL to use
        _VBO = new(vertices, BufferTarget.ArrayBuffer);
        _VBO.Run(); // Bind buffer

        // 3. then set our vertex attributes pointers
        _VAO.SetAttributesPointers();
    }

    public void RenderFrame(FrameEventArgs? args = null)
    {
        _shaderProgram.Use();
        _VAO.Bind();
        GL.DrawArrays(PrimitiveType.Triangles, 0, 3);
    }

    public void UnloadResources()
    {
        _shaderProgram.Dispose();
    }
}