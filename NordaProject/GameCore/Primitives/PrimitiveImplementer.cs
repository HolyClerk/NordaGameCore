using NordaProject.GameCore.Primitives.Types;
using OpenTK.Graphics.OpenGL;
using OpenTK.Windowing.Desktop;

namespace NordaProject.GameCore.Primitives;

internal class PrimitiveImplementer
{
    public static void CreatePoint(Point point = default)
    {
        GL.PointSize(point.Size);
        GL.Begin(PrimitiveType.Points);
        GL.Vertex2(point.X, point.Y);
        GL.End();
    }

    public static void CreateTriangle(Triangle triangle = default)
    {
        GL.Begin(PrimitiveType.Triangles);
        GL.Vertex2(triangle.Vertex0);
        GL.Vertex2(triangle.Vertex1);
        GL.Vertex2(triangle.Vertex2);
        GL.End();
    }
}