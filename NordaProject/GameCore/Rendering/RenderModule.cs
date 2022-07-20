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

    private readonly float[] _vertices2 =
    {
        // pos                  // colors
        -1.0f, -1.0f, 0.0f,     1.0f, 0.0f, 0.0f, // l-b
         0.5f, -1.0f, 0.0f,     0.0f, 1.0f, 0.0f, // r-b
        -0.7f,  0.5f, 0.0f,     0.0f, 0.0f, 1.0f, // t
    };

    private VertexArray _VAO;
    private VertexBuffer _VBO;
    private VertexBuffer _VBO2;
    private ShaderProgram _shader;

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
        _VAO = new();
        _VBO = new();
        _VBO2 = new();

        // Биндим VAO
        _VAO.Bind();

        // Копируем вершинные массивы в буфер 
        _VBO.Bind();
        _VBO.InitializeDataStore(_vertices, BufferTarget.ArrayBuffer);

        // Устанавливаем точки аттрибутов вершин
        _VAO.SetAttributesPointers(index: 0, stride: 6, offset: 0);
        _VAO.SetAttributesPointers(index: 1, stride: 6, offset: 3 * sizeof(float));
        
        _VAO.Unbind();

        _shader = new ShaderProgram(SHADER_SOURCE + "shader_base.vert", SHADER_SOURCE + "shader_base.frag");
        _shader.Use();
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