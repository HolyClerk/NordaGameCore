using OpenTK.Mathematics;
using OpenTK.Graphics.OpenGL;

using NordaProject.GameCore.Rendering.Buffers;

namespace NordaProject.GameCore.Rendering;

internal sealed class RenderModule
{
    // private ShaderProgram _shaderProgram;

    private float[] vertices =
    {
        -0.5f, -0.5f, 0.0f, //Bottom-left vertex
         0.5f, -0.5f, 0.0f, //Bottom-right vertex
         0.0f,  0.5f, 0.0f  //Top vertex
    };

    int VertexBufferObject;

    public RenderModule() 
    {
        VertexBufferObject = GL.GenBuffer();
        
        GL.BufferData(BufferTarget.ArrayBuffer, vertices.Length * sizeof(float), vertices, BufferUsageHint.StaticDraw);

        string VertexShaderSource;

        using (StreamReader reader = new StreamReader(vertexPath, Encoding.UTF8))
        {
            VertexShaderSource = reader.ReadToEnd();
        }

        string FragmentShaderSource;

        using (StreamReader reader = new StreamReader(fragmentPath, Encoding.UTF8))
        {
            FragmentShaderSource = reader.ReadToEnd();
        }
    }

    public void RenderFrame()
    {

    }
}