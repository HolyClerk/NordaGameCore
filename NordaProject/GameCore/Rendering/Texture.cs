using System;
using System.Collections.Generic;
using OpenTK.Graphics.OpenGL4;

using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;

namespace NordaProject.GameCore.Rendering;

public class Texture
{
    public Texture()
    {
        Handle = GL.GenTexture();

        Image<Rgba32> image = Image.Load<Rgba32>("");

        //ImageSharp loads from the top-left pixel, whereas OpenGL loads from the bottom-left, causing the texture to be flipped vertically.
        //This will correct that, making the texture display properly.
        image.Mutate(x => x.Flip(FlipMode.Vertical));

        //Use the CopyPixelDataTo function from ImageSharp to copy all of the bytes from the image into an array that we can give to OpenGL.
        var pixels = new byte[4 * image.Width * image.Height];
        image.CopyPixelDataTo(pixels);
    }

    public int Handle { get; private set; }
}

