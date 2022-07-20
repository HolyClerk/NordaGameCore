using System;
using System.Collections.Generic;
using OpenTK.Graphics.OpenGL4;

using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;

namespace NordaProject.GameCore.Rendering;

public class Texture
{
    public Texture(string path)
    {
        Handle = GL.GenTexture();

        var image = Image.Load<Rgba32>(path);
        var pixelsArray = new byte[4 * image.Width * image.Height];

        // ImageSharp подгружает текстуру с верхнего-левого пикселя, а OpenGL с 
        // нижнего левого. Так что нам необходимо перевернуть изображение(текстуру)
        // по вертикали.
        image.Mutate(x => x.Flip(FlipMode.Vertical));
        image.CopyPixelDataTo(pixelsArray);

        GenerateTexture(image.Width, image.Height, ref pixelsArray);
    }

    public int Handle 
    { 
        get; private set; 
    }

    private void GenerateTexture(int width, int height, ref byte[] pixelsToGenerate)
    {
        GL.TexImage2D(
            TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, 
            width, height, 0, PixelFormat.Rgba, 
            PixelType.UnsignedByte, pixelsToGenerate);
        GL.GenerateMipmap(GenerateMipmapTarget.Texture2D);
    }

    public void Use()
    {
        GL.BindTexture(TextureTarget.Texture2D, Handle);
    }
}

