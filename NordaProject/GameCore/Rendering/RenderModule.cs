﻿using OpenTK.Mathematics;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Windowing.Common;
using NordaProject.GameCore.Rendering.Buffering;
using NordaProject.GameCore.Rendering.RenderNShaderExamples;

namespace NordaProject.GameCore.Rendering;

internal sealed class RenderModule
{
    private const string SHADER_SOURCE = @"C:\Users\PHPpr\Documents\Development\MainProjects\Norda\NordaProject\GameCore\Rendering\Shaders\";

    private float[] _vertices = 
    {
         0.5f,  0.5f, 0.0f,  // Top right
         0.5f, -0.5f, 0.0f,  // Bottom right
        -0.5f, -0.5f, 0.0f,  // Bottom left
        -0.5f,  0.5f, 0.0f,  // Top left
    };

    private uint[] _indices = 
    {
        0, 3, 1,    // 1 T
        3, 2, 1,    // 2 T
    };

    private VertexBuffer _VBO;
    private ElementBuffer _EBO;
    private VertexArray _VAO;

    private ShaderProgram _shaderProgram;

    private DrawExample _example;

#pragma warning disable CS8618 // Выключение CS8618 т.к. поля объявляются в LoadResources
    public RenderModule(Window gameWindow) { }
#pragma warning restore CS8618

    public void LoadResources()
    {
        _example = new DrawExample();

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
        // _shaderProgram.Use();
        // _VAO.Bind();
        // GL.DrawElements(PrimitiveType.Triangles, _indices.Length, DrawElementsType.UnsignedInt, 0);
        // GL.DrawArrays(PrimitiveType.Triangles, 0, 3);

        _example.ChangeColor();
    }

    public void UnloadResources()
    {
        _VAO.Dispose();
        _VBO.Dispose();
        _EBO.Dispose();
        _shaderProgram.Dispose();
    }
}