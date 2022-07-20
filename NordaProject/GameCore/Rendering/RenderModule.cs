using OpenTK.Mathematics;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Windowing.Common;
using NordaProject.GameCore.Rendering.Buffering;
using NordaProject.GameCore.Rendering.RenderNShaderExamples;

namespace NordaProject.GameCore.Rendering;

public sealed class RenderModule
{
    private const string SHADER_SOURCE = @"C:\Users\PHPpr\Documents\Development\MainProjects\Norda\NordaProject\GameCore\Rendering\Shaders\";

    float[] _vertices =
    {
        //Position          Texture coordinates
         0.5f,  0.5f, 0.0f, 1.0f, 1.0f, // Top right
         0.5f, -0.5f, 0.0f, 1.0f, 0.0f, // Bottom right
        -0.5f, -0.5f, 0.0f, 0.0f, 0.0f, // Bottom left
        -0.5f,  0.5f, 0.0f, 0.0f, 1.0f  // Top left
    };

    private readonly uint[] _indices =
    {
        0, 1, 3,
        1, 2, 3
    };

    private VertexArray _VAO;
    private VertexBuffer _VBO;
    private ElementBuffer _EBO;

    private ShaderProgram _shader;
    private Texture _texture;

    private DrawExample? _example;
    

#pragma warning disable CS8618 // Выключение CS8618 т.к. поля объявляются в LoadResources
    public RenderModule(Window gameWindow) 
    {
        _example = new DrawExample();
    }
#pragma warning restore CS8618

    public void LoadResources()
    {
        GL.ClearColor(0.2f, 0.3f, 0.3f, 1.0f);

        // Биндим VAO
        _VAO = new();
        _VAO.Bind();

        // VBO & EBO бинд
        _VBO = new();
        _VBO.Bind();
        _VBO.InitializeDataStore(_vertices, BufferTarget.ArrayBuffer);

        _EBO = new();
        _EBO.Bind();
        _EBO.InitializeDataStore(_indices);

        //
        _shader = new ShaderProgram(SHADER_SOURCE + "shader_texturing.vert", SHADER_SOURCE + "shader_texturing.frag");
        _shader.Use();

        //
        var verticesLocation = _shader.GetAttribLocation("aPosition");
        _VAO.SetAttributesPointers(index: verticesLocation, stride: 5, offset: 0);

        var textureCoordLocation = _shader.GetAttribLocation("aTextureCoord");
        _VAO.SetAttributesPointers(index: textureCoordLocation, stride: 5, offset: 3 * sizeof(float));

        _VAO.Unbind();

        _texture = new("Resources/container.jpg");
        _texture.Use();
    }

    public void RenderFrame(FrameEventArgs? args = null)
    {
        _shader.Use();

        _VAO.Bind();

        // DrawExample.ScaleVertex(ref _vertices[6]);
        // _VBO.InitializeDataStore(_vertices, BufferTarget.ArrayBuffer);

        // GL.DrawElements(PrimitiveType.Triangles, _indices.Length, DrawElementsType.UnsignedInt, 0);
        GL.DrawArrays(PrimitiveType.Triangles, 0, 3);
    }

    public void UnloadResources()
    {
        _VAO.Dispose();
        _VBO.Dispose();
        _shader.Dispose();
    }
}