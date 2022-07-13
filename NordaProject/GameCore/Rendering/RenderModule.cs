using OpenTK.Mathematics;
using OpenTK.Graphics.OpenGL4;

namespace NordaProject.GameCore.Rendering;

internal sealed class RenderModule
{
    private const string SHADER_SOURCE= @"C:\Users\PHPpr\Documents\Development\MainProjects\Norda\NordaProject\GameCore\Rendering\Shaders\";
    
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

    public ShaderProgram ShaderProgram 
    { 
        get; private set; 
    }

    public RenderModule() 
    {
        // Инициализируем шейдерную программу
        ShaderProgram = new ShaderProgram(SHADER_SOURCE + "shader.vert", SHADER_SOURCE + "shader.frag");

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

    public void RenderFrame()
    {
        var vbo = new VertexBuffer();
        vbo.InitializeDataStore(vertices, BufferTarget.ArrayBuffer);

        var ebo = new VertexBuffer();
        ebo.InitializeDataStore(vertices2, BufferTarget.ElementArrayBuffer);

        GL.EnableVertexAttribArray(vbo);
        GL.EnableVertexAttribArray(ebo);

        /*ShaderProgram.Use();

        GL.BufferData(BufferTarget.ArrayBuffer, vertices.Length * sizeof(float), vertices, BufferUsageHint.DynamicDraw);
        GL.DrawArrays(PrimitiveType.Triangles, 0, 3);*/
    }

}