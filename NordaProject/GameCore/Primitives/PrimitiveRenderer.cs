using NordaProject.GameCore.Primitives.Types;
using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;
using OpenTK.Windowing.Desktop;

namespace NordaProject.GameCore.Primitives;

internal class PrimitiveRenderer
{
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

    public static void CreateConnectedTriangle(Triangle baseTriangle, Vector2[] vertices)
    {
        GL.Begin(PrimitiveType.TriangleStrip);

        GL.Color3(2.55f, 0.42f, 0.64f);

        GL.Vertex2(baseTriangle.Vertex0);
        GL.Vertex2(baseTriangle.Vertex1);
        GL.Vertex2(baseTriangle.Vertex2);

        if (vertices.Length <= 0)
        {
            GL.End();
            return;
        }

        for (int i = 0; i < vertices.Length; i++)
        {
            GL.Vertex2(vertices[i].X, vertices[i].Y);
        }

        GL.End();
    }
}