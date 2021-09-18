Shader "Unlit/FenelEffect"
{
    Properties
    {
        _ColorA("Color A", Color) = (1,1,1,1)
        _ColorB("Color B", Color) = (0,0,0,0)
        _ColorStart("Color Start", range(0,1)) = 0
        _ColorEnd("Color End", range(0,1)) = 1
        _Speed("Speed of Shader", range(0.01,0.3)) = 0.3
        _Height("Hight of CosWave", range(0,0.1)) = 0.01
    }
    SubShader
    {
        Tags {
            "RenderType"="Transparent"
            "Queue"="Transparent"
            }
        LOD 100

        Pass
        {
            Cull Off
            Zwrite Off  // dont write to the depth buffer / z-buffer
            Blend One One       // Additive.
            //Blend DstColor Zero // Multipliply
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            // make fog work.
            #pragma multi_compile_fog

            #include "UnityCG.cginc"
            #define TAU 6.28318530718

            struct appdata
            {
                float4 vertex : POSITION;   // Vertex position in object space.
                float3 normal : NORMAL;     // These tags pass in data to variable.
                float2 uv : TEXCOORD1;
            };

            struct v2f
            {
                float4 vertex : SV_POSITION; // Clip space postition.
                float2 uv : TEXCOORD1;
                float3 normal : TEXCOORD0;
            };

            float4 _ColorA;
            float4 _ColorB;
            float _Scale;
            float _Offset;
            float _ColorStart;
            float _Speed;
            float _Height;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                
                o.uv = v.uv;// (v.uv, _Offset) * _Scale; //v.uv;

                o.normal = mul((float3x3) unity_ObjectToWorld, v.normal);
                // o.normal = UnityObjectToWorldNormal(v.normal);
                return o;
            }
            
            // lerp         (10, 20, 0.5) = 15
            // InverseLerp   (10, 20, 15) = 0.5
            float InverseLerp(float a, float b, float v)
            {
                return (v-a)/(b-a);
            }

            fixed4 frag (v2f i) : SV_Target
            {
                float xOffset = cos(i.uv.y * TAU * 11) * _Height;                
                float t = cos((i.uv.x + xOffset + _Time.y * _Speed) * TAU * 5)* 2 + 0.5;
                t *= 1- i.uv.y;
                float4 outColor = lerp(_ColorA, _ColorB, t);
                return float4(outColor.xyz,1);
            }
            ENDCG
        }
    }
}
