Shader "Custom/SpriteOutline"
{
    Properties
    {
        _MainTex ("Sprite Texture", 2D) = "white" {}
        _OutlineColor ("Outline Color", Color) = (0,0,0,1)
        _OutlineThickness ("Outline Thickness", Range(0.0, 0.03)) = 0.01
    }

    SubShader
    {
        Tags {"Queue"="Overlay" "IgnoreProjector"="True" "RenderType"="Transparent"}
        LOD 100

        Cull Off
        Lighting Off
        ZWrite Off
        Blend SrcAlpha OneMinusSrcAlpha

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

            sampler2D _MainTex;
            float4 _MainTex_ST;
            float4 _OutlineColor;
            float _OutlineThickness;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                float alpha = tex2D(_MainTex, i.uv).a;

                // Check neighboring pixels for outline
                float2 offset = float2(_OutlineThickness, 0);
                float alphaN = tex2D(_MainTex, i.uv + offset).a;
                float alphaS = tex2D(_MainTex, i.uv - offset).a;
                offset = float2(0, _OutlineThickness);
                float alphaE = tex2D(_MainTex, i.uv + offset).a;
                float alphaW = tex2D(_MainTex, i.uv - offset).a;

                if(alpha == 0 && (alphaN > 0 || alphaS > 0 || alphaE > 0 || alphaW > 0))
                {
                    return _OutlineColor;
                }
                else
                {
                    return tex2D(_MainTex, i.uv);
                }
            }
            ENDCG
        }
    }
}
