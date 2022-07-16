using OpenTK.Mathematics;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Windowing.Common;
using NordaProject.GameCore.Rendering.Buffering;

namespace NordaProject.GameCore.Rendering;

internal sealed class RenderModule
{
    private const string SHADER_SOURCE = @"C:\Users\PHPpr\Documents\Development\MainProjects\Norda\NordaProject\GameCore\Rendering\Shaders\";

    private float[] _vertices =
    {
        -0.5f, -0.5f, 0.0f, //Bottom-left vertex
         0.5f, -0.5f, 0.0f, //Bottom-right vertex
         0.0f,  0.5f, 0.0f  //Top vertex
    };

    private float[] _vertices2 =
    {
        -0.5f, -0.5f, 0.0f, //Bottom-left vertex
         0.5f, -0.5f, 0.0f, //Bottom-right vertex
         0.0f,  0.5f, 0.0f  //Top vertex
    };

    uint[] indices = 
    {  // note that we start from 0!
        0, 1, 3,   // first triangle
        1, 2, 3    // second triangle
    };

    private int _vertexBuffer = 0;
    private int _vertexArray = 0;

    private VertexBuffer _VBO;
    private VertexArray _VAO;
    private int _EBO;

    private ShaderProgram _shaderProgram;

    // !!!
    public RenderModule(Window gameWindow) { } 

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
        _VBO.InitializeDataStore(_vertices, BufferTarget.ArrayBuffer);

        // 3. then set our vertex attributes pointers
        _VAO.SetAttributesPointers();

        _EBO = GL.GenBuffer();
        GL.BindBuffer(BufferTarget.ElementArrayBuffer, _EBO);
        GL.BufferData(BufferTarget.ElementArrayBuffer, indices.Length * sizeof(uint), indices, BufferUsageHint.StaticDraw);
    }

    public void RenderFrame(FrameEventArgs? args = null)
    {
        _shaderProgram.Use();

        //_VBO.InitializeDataStore(_vertices, BufferTarget.ArrayBuffer);

        //_VAO.Bind();

        GL.BindBuffer(BufferTarget.ElementArrayBuffer, _EBO);
        GL.BufferData(BufferTarget.ElementArrayBuffer, indices.Length * sizeof(uint), indices, BufferUsageHint.StaticDraw);

        GL.DrawElements(PrimitiveType.Triangles, indices.Length, DrawElementsType.UnsignedInt, 0);

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