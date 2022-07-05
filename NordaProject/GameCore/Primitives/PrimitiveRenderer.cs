using NordaProject.GameCore.Primitives.Types;
using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;
using OpenTK.Windowing.Desktop;

namespace NordaProject.GameCore.Primitives;

internal class PrimitiveRenderer
{
    public static void CreatePoint(Vector2 point = default, int size = 1)
    {
        GL.PointSize(size);

        GL.Begin(PrimitiveType.Points);

        GL.Color3(2.55f, 0.0f, 1.32f);

        GL.Vertex2(point.X, point.Y);

        GL.End();
    }

    public static void CreatePoint(Point point = default)
    {
        GL.PointSize(point.Size);

        GL.Begin(PrimitiveType.Points);

        GL.Color3(2.55f, 0.0f, 1.32f);

        GL.Vertex2(point.X, point.Y);

        GL.End();
    }

    public static void CreateTriangle(Triangle triangle = default)
    {
        GL.Begin(PrimitiveType.Triangles);

        GL.Color3(2.55f, 0.42f, 0.64f);

        GL.Vertex2(triangle.Vertex0);
        GL.Vertex2(triangle.Vertex1);
        GL.Vertex2(triangle.Vertex2);

        GL.End();
    }

    public static void CreateTriangle(Vector3 color, Triangle triangle = default)
    {
        GL.Begin(PrimitiveType.Triangles);

        GL.Color3(color);

        GL.Vertex2(triangle.Vertex0);
        GL.Vertex2(triangle.Vertex1);
        GL.Vertex2(triangle.Vertex2);

        GL.End();
    }
}