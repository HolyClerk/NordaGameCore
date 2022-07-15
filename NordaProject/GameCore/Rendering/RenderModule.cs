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
    }

    public void LoadResources()
    {
        _shaderProgram = new ShaderProgram(SHADER_SOURCE + "shader.vert", SHADER_SOURCE + "shader.frag");
        
        _VAO = new();
        _VBO = new();

        // ..:: Initialization code (done once (unless your object frequently changes)) :: ..
        // 1. bind Vertex Array Object
        _VAO.Bind();

        // 2. copy our vertices array in a buffer for OpenGL to use
        _VBO.Bind(); // Bind buffer
        _VBO.InitializeDataStore(vertices, BufferTarget.ArrayBuffer);

        // 3. then set our vertex attributes pointers
        _VAO.SetAttributesPointers();
    }

    public void RenderFrame(FrameEventArgs? args = null)
    {
        _shaderProgram.Use();
        _VAO.Bind();
        Draw();
    }

    bool _isLower = false;

    private void Draw()
    {
        _VBO.InitializeDataStore(vertices, BufferTarget.ArrayBuffer);

        _isLower = vertices[0] switch
        {
            >= 0.5f     => false,
            <= -1.0f    => true,
            _           => _isLower,
        };

        vertices[0] += _isLower switch
        {
            true    => 0.01f,
            false   => -0.1f,
        };

        GL.DrawArrays(PrimitiveType.Triangles, 0, 3);
    }

    public void UnloadResources()
    {
        _VAO.UnBind();
        _VBO.Unbind();
        _shaderProgram.Dispose();
    }
}