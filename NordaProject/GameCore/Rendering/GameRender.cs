using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;

using NordaProject.GameCore.Rendering.Buffering;

namespace NordaProject.GameCore.Rendering;

internal class GameRender
{
    private Window _currentWindow;

    uint[] indexes = new uint[] {
                0, 1, 2,
                0, 2, 3,
                3, 2, 4,
                3, 4, 5,
                5, 4, 6,
                5, 6, 7,

                1, 8, 9,
                1, 9, 2,
                2, 9, 10,
                2, 10, 4,
                4, 10, 11,
                4, 11, 6
    };

    float[] vert_colors = new float[]
    {
                // vertices           // colosrs 
                -0.8f,  0.6f, 0.0f,   1.0f, 0.0f, 0.0f, 1.0f,
                -0.8f,  0.0f, 0.0f,   0.0f, 1.0f, 0.0f, 1.0f,
                -0.2f,  0.0f, 0.0f,   0.0f, 0.0f, 1.0f, 1.0f,
                -0.2f,  0.6f, 0.0f,   0.8f, 0.6f, 0.2f, 1.0f,
                 0.2f,  0.0f, 0.0f,   0.8f, 0.6f, 0.2f, 1.0f,
                 0.2f,  0.6f, 0.0f,   0.8f, 0.6f, 0.2f, 1.0f,
                 0.8f,  0.0f, 0.0f,   0.8f, 0.6f, 0.2f, 1.0f,
                 0.8f,  0.6f, 0.0f,   0.8f, 0.6f, 0.2f, 1.0f,

                -0.8f,  -0.6f, 0.0f,   0.8f, 0.6f, 0.2f, 1.0f,
                -0.2f,  -0.6f, 0.0f,   0.8f, 0.6f, 0.2f, 1.0f,
                 0.2f,  -0.6f, 0.0f,   0.8f, 0.6f, 0.2f, 1.0f,
                 0.8f,  -0.6f, 0.0f,   0.8f, 0.6f, 0.2f, 1.0f
    };

    public GameRender(Window window)
    {
        _currentWindow = window;
    }

    public void RenderFrame()
    {
        /*float[] vertexes =
        {
            0.1f, 0.2f
        };

        var VBO = new VertexBuffer(BufferTarget.ArrayBuffer);

        VBO.SetBufferData()

        var EBO = new VertexBuffer(BufferTarget.ElementArrayBuffer);*/
    }
}