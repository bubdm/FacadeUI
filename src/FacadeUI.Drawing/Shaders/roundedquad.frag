#version 450

layout(set = 2, binding = 0) uniform Shape
{
    float radius;
};

layout(set = 3, binding = 0) uniform Brush
{
    vec4 br_color;
};

layout(set = 4, binding = 0) uniform Stroke
{
    float st_ext;
    vec4 st_color;
};

layout(location = 0) in vec2 fsin_TexCoord;
//layout(location = 1) in vec4 fsin_Color;
layout(location = 0) out vec4 fsout_Color;

float dis_circle(vec2 center, float r, vec2 coord){
    //Signed Distance Field Function;
    //Circle
    //vec2 offset = coord - center; 
    //float d = sqrt((offset.x * offset.x) + (offset.y * offset.y)) - r;
    float d = distance( center, coord ) - r;
    
    return d;
}

float udRoundBox( vec2 p, vec2 b, float r )
{
    return length(max(abs(p)-b+r,0.0))-r;
}

void main()
{
    //vec4 color = vec4(1.0, 0.0, 0.0, 1.0) ;    // plain red
    //float distance = dis_circle( vec2(0.5, 0.5), 0.5, fsin_TexCoord ) ;
    float distance = udRoundBox(fsin_TexCoord - vec2(0.5, 0.5), vec2(0.5, 0.5), radius) ;
    fsout_Color = vec4(br_color.rgb, br_color.a * (1.0 - smoothstep(-0.005,0.005,distance)));
}