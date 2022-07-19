using OpenTK.Mathematics;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Windowing.Common;
using NordaProject.GameCore.Rendering.Buffering;
using NordaProject.GameCore.Rendering.RenderNShaderExamples;

namespace NordaProject.GameCore.Rendering;

internal sealed class RenderModule
{
    private const string SHADER_SOURCE = @"C:\Users\PHPpr\Documents\Development\MainProjects\Norda\NordaProject\GameCore\Rendering\Shaders\";

    private readonly float[] _vertices =
    {
        -0.5f, -0.5f, 0.0f, // Bottom-left vertex
         0.5f, -0.5f, 0.0f, // Bottom-right vertex
         0.0f,  0.5f, 0.0f, // Top vertex
    };

    private VertexArray _VAO;
    private VertexBuffer _VBO;
    private ShaderProgram _shaderProgram;

    private DrawExample? _example;

#pragma warning disable CS8618 // Выключение CS8618 т.к. поля объявляются в LoadResources
    public RenderModule(Window gameWindow) 
    {
        // _example = new DrawExample();
    }
#pragma warning restore CS8618

    public void LoadResources()
    {
        GL.ClearColor(0.2f, 0.3f, 0.3f, 1.0f);

        _shaderProgram = new ShaderProgram(SHADER_SOURCE + "shader.vert", SHADER_SOURCE + "shader.frag");

        _VAO = new();
        _VBO = new();

        // 1. Биндим VAO
        _VAO.Bind();

        // 2. Копируем вершинные массивы в буфер 
        _VBO.Bind();
        _VBO.InitializeDataStore(_vertices, BufferTarget.ArrayBuffer);

        // 3. Устанавливаем точки аттрибутов вершин
        _VAO.SetAttributesPointers();
    }

    public void RenderFrame(FrameEventArgs? args = null)
    {
        _shaderProgram.Use();
        _VAO.Bind();
        // GL.DrawElements(PrimitiveType.Triangles, _indices.Length, DrawElementsType.UnsignedInt, 0);
        GL.DrawArrays(PrimitiveType.Triangles, 0, 3);
    }

    public void UnloadResources()
    {
        _VAO.Dispose();
        _VBO.Dispose();
        _shaderProgram.Dispose();
    }
}