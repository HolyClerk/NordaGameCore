namespace NordaProject.GameCore.Primitives.Types;

internal struct Point
{
    public Point(float x = 0.0f, float y = 0.0f, int size = 1)
    {
        X = x;
        Y = y;

        Size = size;
    }

    public float X = 0.0f;
    public float Y = 0.0f;

    public int Size = 1;
}

