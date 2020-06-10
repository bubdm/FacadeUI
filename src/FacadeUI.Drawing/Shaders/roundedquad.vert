#version 450

layout(set = 0, binding = 0) uniform Projection
{
    mat4 _Projection;
};

layout(set = 1, binding = 0) uniform World
{
    mat4 _World;
};

layout(location = 0) in vec2 Position;
layout(location = 1) in vec2 TexCoord;

layout(location = 0) out vec2 fsin_TexCoord;
//--layout(location = 1) out vec4 fsin_Color;

void main()
{
    gl_Position = _Projection * _World * vec4(Position, 0, 1);
    //gl_Position.y *= -1;  //-- invert Y
    fsin_TexCoord = Position;
    //--fsin_Color = Color;
}