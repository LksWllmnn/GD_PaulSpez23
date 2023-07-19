Shader "Custom/PixelationEffectWithOpacity"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _PixelationSize ("Pixelation Size", Range(1, 100)) = 10
        _Opacity ("Opacity", Range(0, 1)) = 1
    }
 
    SubShader
    {
        Tags { "Queue" = "Transparent" "RenderType" = "Transparent" }
        LOD 100
 
        Blend SrcAlpha OneMinusSrcAlpha
        ZWrite Off
 
        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"
 
            uniform sampler2D _MainTex;
            float _PixelationSize;
            float _Opacity;
 
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
 
            v2f vert(appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }
 
            fixed4 frag(v2f i) : SV_Target
            {
                float2 uv = i.uv;
                float2 pixelSize = float2(_PixelationSize, _PixelationSize) / _ScreenParams.xy;
                float2 uvPixelated = floor(uv / pixelSize) * pixelSize;
                fixed4 texColor = tex2D(_MainTex, uvPixelated);
                texColor.a *= _Opacity;
                return texColor;
            }
 
            ENDCG
        }
    }
}
