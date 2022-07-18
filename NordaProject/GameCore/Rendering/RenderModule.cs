using OpenTK.Mathematics;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Windowing.Common;
using NordaProject.GameCore.Rendering.Buffering;

namespace NordaProject.GameCore.Rendering;

internal sealed class RenderModule
{
    private const string SHADER_SOURCE = @"C:\Users\PHPpr\Documents\Development\MainProjects\Norda\NordaProject\GameCore\Rendering\Shaders\";

    private float[] _verticesD =
    {
        -0.5f, -0.5f, 0.0f, // Bottom-left vertex
         0.5f, -0.5f, 0.0f, // Bottom-right vertex
         0.0f,  0.5f, 0.0f  // Top vertex
    };

    float[] _vertices = 
    {
         0.5f,  0.5f, 0.0f,  // Top right
         0.5f, -0.5f, 0.0f,  // Bottom right
        -0.5f, -0.5f, 0.0f,  // Bottom left
        -0.5f,  0.5f, 0.0f,  // Top left
    };

    uint[] _indices = 
    {
        0, 3, 1,    // 1 T
        3, 2, 1,    // 2 T
    };

    private VertexBuffer _VBO;
    private ElementBuffer _EBO;
    private VertexArray _VAO;

    private ShaderProgram _shaderProgram;

#pragma warning disable CS8618 // Выключение CS8618 т.к. поля объявляются в LoadResources
    public RenderModule(Window gameWindow) { }
#pragma warning restore CS8618

    public void LoadResources()
    {
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
        _EBO.InitializeDataStore(_indices);

        _isLower = _vertices[10] switch
        {
            >= 0.7f     => false,
            <= -0.8f    => true,
            _           => _isLower,
        };

        _vertices[10] += _isLower switch
        {
            true    => 0.03f,
            false   => -0.03f,
        };

        //GL.DrawArrays(PrimitiveType.Triangles, 0, 3);
        GL.DrawElements(PrimitiveType.Triangles, _indices.Length, DrawElementsType.UnsignedInt, 0);
    }

    public void UnloadResources()
    {
        _VAO.Dispose();
        _VBO.Dispose();
        _EBO.Dispose();
        _shaderProgram.Dispose();
    }
}