Shader "gradation"
{
    Properties
    {
        _GradientColorOne("Gradient Color: ", color) = (1,1,1,1)
        _GradientColorTwo("Gradient Color: ", color) = (1,1,1,1)
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            fixed4 _GradientColorOne;
            fixed4 _GradientColorTwo;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                fixed4 col = lerp(_GradientColorOne, _GradientColorOne, i.uv.x);
                return col;
            }
            ENDCG
        }
    }
}
