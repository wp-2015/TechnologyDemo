Shader "Unlit/ProjectorDemo"
{
    Properties
    {
        _MainTex ("Cookie", 2D) = "white" {}
    }
    SubShader
    {
        Tags {"Queue"="Transparent" "IgnoreProjector"="True" "RenderType"="Transparent" "PreviewType"="Plane" }

        Pass
        {
            ColorMask RGB
            ZWrite off Cull Off Lighting Off 
            //Blend DstColor One
            //Blend SrcAlpha One            // particle add
            Blend SrcAlpha OneMinusSrcAlpha    // particle blend
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            // make fog work
            #pragma multi_compile_fog

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                UNITY_FOG_COORDS(1)
                float4 vertex : SV_POSITION;
                float4 texc:TEXCOORD1;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
            float4x4 unity_Projector;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                o.texc = mul(unity_Projector, v.vertex);
                UNITY_TRANSFER_FOG(o,o.vertex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                // sample the texture
                //fixed4 col = tex2D(_MainTex, i.uv);
                float4 c = tex2Dproj(_MainTex, i.texc);
                // apply fog
                UNITY_APPLY_FOG(i.fogCoord, col);
                return c;
            }
            ENDCG
        }
    }
}
