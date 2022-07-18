using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NordaProject.GameCore
{
    internal class _tempgarbage
    {
        /*if (count< 1.0f)
        {
            vertex0 = new (vertex0.X, vertex0.Y += 0.01f);
            vertex1 = new (vertex1.X += 0.01f, vertex1.Y += 0.005f);
            vertex2 = new (vertex2.X -= 0.01f, vertex2.Y -= 0.01f);

            Triangle triangle = new(vertex0, vertex1, vertex2);

        PrimitiveImplementer.CreateTriangle(triangle);

            count += 0.01f;
        }
        else
        {
            vertex0 = new (-0.2f, 0.0f);
            vertex1 = new (0.0f, 0.2f);
            vertex2 = new (0.2f, -0.2f);

            count = 0.0f;
        }*/

        /*// ..:: Initialization code (done once (unless your object frequently changes)) :: ..
        // 1. bind Vertex Array Object
        _VAO.Bind();

        // 2. copy our vertices array in a buffer for OpenGL to use
        _VBO.Bind(); // Bind buffer
        _VBO.InitializeDataStore(vertices, BufferTarget.ArrayBuffer);

        // 3. then set our vertex attributes pointers
        _VAO.SetAttributesPointers();*/


        /*
        float[] _vertices =
        {
             0.5f,  0.6f, 0.0f,  // top right
             0.2f, -0.2f, 0.0f,  // bottom right
            -0.5f, -0.5f, 0.0f,  // bottom left
            -0.5f,  0.5f, 0.0f,  // top left

             0.8f, -0.5f, 0.0f,  // bottom right2
             0.8f,  0.6f, 0.0f,  // top right2
        };
        ................................................
        uint[] _indices =
        {  // note that we start from 0!
            0, 3, 1,    // first triangle
            3, 2, 1,    // second triangle
            0, 1, 4,
            5, 0, 4,
            1, 2, 4,
            //2, 5, 4,    // 2 4 5 // 4 5 2
        }
        ....................................................................
        _VBO.InitializeDataStore(_vertices, BufferTarget.ArrayBuffer);
        _EBO.InitializeDataStore(_indices);

        _isLower = _vertices[10] switch
        {
            >= 0.7f     => false,
            <= -0.8f    => true,
            _           => _isLower,
        };

        _vertices[10] += _isLower switch
        {
            true    => 0.03f,
            false   => -0.03f,
        };

        //GL.DrawArrays(PrimitiveType.Triangles, 0, 3);
        GL.DrawElements(PrimitiveType.Triangles, _indices.Length, DrawElementsType.UnsignedInt, 0);
    };*/
    }
}
