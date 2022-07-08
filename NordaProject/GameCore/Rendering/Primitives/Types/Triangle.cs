using OpenTK.Mathematics;

namespace NordaProject.GameCore.Primitives.Types;

internal struct Triangle
{
    public Triangle(Vector2 vertex0, Vector2 vertex1, Vector2 vertex2)
    {
        Vertex0 = vertex0;
        Vertex1 = vertex1;
        Vertex2 = vertex2;
    }

    public Vector2 Vertex0 = new Vector2(-0.2f, 0.0f);  // LEFT VERTEX
    public Vector2 Vertex1 = new Vector2(0.0f, 0.3f);   // RIGHT VERTEX
    public Vector2 Vertex2 = new Vector2(0.2f, 0.0f);   // TOP VERTEX
}
