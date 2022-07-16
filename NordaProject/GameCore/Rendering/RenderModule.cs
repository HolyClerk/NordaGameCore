using OpenTK.Mathematics;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Windowing.Common;
using NordaProject.GameCore.Rendering.Buffering;

namespace NordaProject.GameCore.Rendering;

internal sealed class RenderModule
{
    private const string SHADER_SOURCE = @"C:\Users\PHPpr\Documents\Development\MainProjects\Norda\NordaProject\GameCore\Rendering\Shaders\";

    private float[] _vertices2 =
    {
        -0.5f, -0.5f, 0.0f, //Bottom-left vertex
         0.5f, -0.5f, 0.0f, //Bottom-right vertex
         0.0f,  0.5f, 0.0f  //Top vertex
    };

    float[] _vertices = 
    {
         0.5f,  0.5f, 0.0f,  // top right
         0.5f, -0.5f, 0.0f,  // bottom right
        -0.5f, -0.5f, 0.0f,  // bottom left
        -0.5f,  0.5f, 0.0f   // top left
    };

    uint[] _indices = 
    {  // note that we start from 0!
        0, 3, 1,   // first triangle
        3, 2, 1    // second triangle
    };

    private VertexBuffer _VBO;
    private ElementBuffer _EBO;
    private VertexArray _VAO;
    

    private ShaderProgram _shaderProgram;

    // !!!
    public RenderModule(Window gameWindow) { } 

    public void LoadResources()
    {
        _shaderProgram = new ShaderProgram(SHADER_SOURCE + "shader.vert", SHADER_SOURCE + "shader.frag");
        
        _VAO = new();
        _VBO = new();
        _EBO = new();

        // ..:: Initialization code (done once (unless your object frequently changes)) :: ..
        // 1. bind Vertex Array Object
        _VAO.Bind();

        // 2. copy our vertices array in a buffer for OpenGL to use
        _VBO.Bind(); // Bind buffer
        _VBO.InitializeDataStore(_vertices, BufferTarget.ArrayBuffer);

        _EBO.Bind();
        _EBO.InitializeDataStore(_indices);

        // 3. then set our vertex attributes pointers
        _VAO.SetAttributesPointers();
    }

    public void RenderFrame(FrameEventArgs? args = null)
    {
        _shaderProgram.Use();

        _VAO.Bind();

        GL.DrawElements(PrimitiveType.Triangles, _indices.Length, DrawElementsType.UnsignedInt, 0);
    }

    bool _isLower = false;

    private void Draw()
    {
        _VBO.InitializeDataStore(_vertices, BufferTarget.ArrayBuffer);

        _isLower = _vertices[0] switch
        {
            >= 0.5f     => false,
            <= -1.0f    => true,
            _           => _isLower,
        };

        _vertices[0] += _isLower switch
        {
            true    => 0.01f,
            false   => -0.1f,
        };

        GL.DrawArrays(PrimitiveType.Triangles, 0, 3);
    }

    public void UnloadResources()
    {
        _VAO.Dispose();
        _VBO.Dispose();
        _shaderProgram.Dispose();
    }
}