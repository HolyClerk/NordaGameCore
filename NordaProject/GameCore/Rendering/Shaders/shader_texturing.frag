#version 330 core

out vec4 outputColor;  

in vec2 textureCoord;
uniform sampler2D thisTexture;
  
void main()
{
    outputColor = texture(thisTexture, textureCoord);
}