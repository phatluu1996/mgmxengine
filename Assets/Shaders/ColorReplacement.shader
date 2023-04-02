Shader "ColorReplacement"
{
    Properties
    {
        _MainTex("Diffuse", 2D) = "white" {}
        _MaskTex("Mask", 2D) = "white" {}
        _NormalMap("Normal Map", 2D) = "bump" {}

        // Legacy properties. They're here so that materials using this shader can gracefully fallback to the legacy sprite shader.
        [HideInInspector] _Color("Tint", Color) = (1,1,1,1)
        [HideInInspector] _RendererColor("RendererColor", Color) = (1,1,1,1)
        [HideInInspector] _Flip("Flip", Vector) = (1,1,1,1)
        [HideInInspector] _AlphaTex("External Alpha", 2D) = "white" {}
        [HideInInspector] _EnableExternalAlpha("Enable External Alpha", Float) = 0

        _Range ("Target Color Range", Range(0, 1)) = 0.01
        _Color0("Color 0", Color) = (1,1,1,1)
        _Color1("Color 1", Color) = (1,1,1,1)
        _Color2("Color 2", Color) = (1,1,1,1)
        _Color3("Color 3", Color) = (1,1,1,1)
        _Color4("Color 3", Color) = (1,1,1,1)
        
        _NewColor0("New Color 0", Color) = (1,1,1,1)
        _NewColor1("New Color 1", Color) = (1,1,1,1)
        _NewColor2("New Color 2", Color) = (1,1,1,1)
        _NewColor3("New Color 3", Color) = (1,1,1,1)
        _NewColor4("New Color 3", Color) = (1,1,1,1)
    }

    SubShader
    {
        Tags {"Queue" = "Transparent" "RenderType" = "Transparent" "RenderPipeline" = "UniversalPipeline" }

        Blend SrcAlpha OneMinusSrcAlpha, One OneMinusSrcAlpha
        Cull Off
        ZWrite Off

        Pass
        {
            Tags { "LightMode" = "Universal2D" }

            HLSLPROGRAM
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"

            #pragma vertex CombinedShapeLightVertex
            #pragma fragment CombinedShapeLightFragment

            #pragma multi_compile USE_SHAPE_LIGHT_TYPE_0 __
            #pragma multi_compile USE_SHAPE_LIGHT_TYPE_1 __
            #pragma multi_compile USE_SHAPE_LIGHT_TYPE_2 __
            #pragma multi_compile USE_SHAPE_LIGHT_TYPE_3 __
            #pragma multi_compile _ DEBUG_DISPLAY

            struct Attributes
            {
                float3 positionOS   : POSITION;
                float4 color        : COLOR;
                float2  uv          : TEXCOORD0;
                UNITY_VERTEX_INPUT_INSTANCE_ID
            };

            struct Varyings
            {
                float4  positionCS  : SV_POSITION;
                half4   color       : COLOR;
                float2  uv          : TEXCOORD0;
                half2   lightingUV  : TEXCOORD1;
                #if defined(DEBUG_DISPLAY)
                float3  positionWS  : TEXCOORD2;
                #endif
                UNITY_VERTEX_OUTPUT_STEREO
            };

            #include "Packages/com.unity.render-pipelines.universal/Shaders/2D/Include/LightingUtility.hlsl"

            TEXTURE2D(_MainTex);
            SAMPLER(sampler_MainTex);
            TEXTURE2D(_MaskTex);
            SAMPLER(sampler_MaskTex);
            half4 _MainTex_ST;
            float4 _Color;
            half4 _RendererColor;

            float _Range;  
            float4 _Color0;
            float4 _Color1;
            float4 _Color2;
            float4 _Color3;
            float4 _Color4;

            float4 _NewColor0;
            float4 _NewColor1;
            float4 _NewColor2;
            float4 _NewColor3;
            float4 _NewColor4;

            #if USE_SHAPE_LIGHT_TYPE_0
            SHAPE_LIGHT(0)
            #endif

            #if USE_SHAPE_LIGHT_TYPE_1
            SHAPE_LIGHT(1)
            #endif

            #if USE_SHAPE_LIGHT_TYPE_2
            SHAPE_LIGHT(2)
            #endif

            #if USE_SHAPE_LIGHT_TYPE_3
            SHAPE_LIGHT(3)
            #endif

            Varyings CombinedShapeLightVertex(Attributes v)
            {
                Varyings o = (Varyings)0;
                UNITY_SETUP_INSTANCE_ID(v);
                UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(o);

                o.positionCS = TransformObjectToHClip(v.positionOS);
                #if defined(DEBUG_DISPLAY)
                o.positionWS = TransformObjectToWorld(v.positionOS);
                #endif
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                o.lightingUV = half2(ComputeScreenPos(o.positionCS / o.positionCS.w).xy);

                o.color = v.color * _Color * _RendererColor;                
                return o;
            }

            #include "Packages/com.unity.render-pipelines.universal/Shaders/2D/Include/CombinedShapeLightShared.hlsl"

            float4 replace(half4 c) : COLOR
            {
                if (c.r >=_Color0.r - _Range && c.r <=_Color0.r + _Range
                    && c.g >=_Color0.g - _Range && c.g <=_Color0.g + _Range
                    && c.b >=_Color0.b - _Range && c.b <=_Color0.b + _Range && c.a >= 1)
                {
                    c = _NewColor0;
                }
                else if (c.r >=_Color1.r - _Range && c.r <=_Color1.r + _Range
                    && c.g >=_Color1.g - _Range && c.g <=_Color1.g + _Range
                    && c.b >=_Color1.b - _Range && c.b <=_Color1.b + _Range && c.a >= 1)
                {
                    c = _NewColor1;
                }
                else if (c.r >=_Color2.r - _Range && c.r <=_Color2.r + _Range
                    && c.g >=_Color2.g - _Range && c.g <=_Color2.g + _Range
                    && c.b >=_Color2.b - _Range && c.b <=_Color2.b + _Range && c.a >= 1)
                {
                    c = _NewColor2;
                }else if (c.r >=_Color3.r - _Range && c.r <=_Color3.r + _Range
                    && c.g >=_Color3.g - _Range && c.g <=_Color3.g + _Range
                    && c.b >=_Color3.b - _Range && c.b <=_Color3.b + _Range && c.a >= 1)
                {
                    c = _NewColor3;
                }else if (c.r >=_Color4.r - _Range && c.r <=_Color4.r + _Range
                    && c.g >=_Color4.g - _Range && c.g <=_Color4.g + _Range
                    && c.b >=_Color4.b - _Range && c.b <=_Color4.b + _Range && c.a >= 1)
                {
                    c = _NewColor4;
                }
                return c;
            }

            half4 CombinedShapeLightFragment(Varyings i) : SV_Target
            {
                
                half4 main = i.color * SAMPLE_TEXTURE2D(_MainTex, sampler_MainTex, i.uv);
                main = replace(main) * _Color;
                const half4 mask = SAMPLE_TEXTURE2D(_MaskTex, sampler_MaskTex, i.uv);
                
                

                SurfaceData2D surfaceData;
                InputData2D inputData;

                InitializeSurfaceData(main.rgb, main.a, mask, surfaceData);
                InitializeInputData(i.uv, i.lightingUV, inputData);
                
                return CombinedShapeLightShared(surfaceData, inputData);
            }
            ENDHLSL
        }
    }

    Fallback "Sprites/Default"
}
