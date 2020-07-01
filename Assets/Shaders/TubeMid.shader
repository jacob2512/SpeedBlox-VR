// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Shader created with Shader Forge v1.26 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.26;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:True,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:3138,x:32719,y:32712,varname:node_3138,prsc:2|emission-9697-OUT;n:type:ShaderForge.SFN_Tex2d,id:7198,x:32042,y:32842,ptovrint:False,ptlb:Base,ptin:_Base,varname:node_7198,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:d387e770ce4e053478f467dd7233a4de,ntxv:0,isnm:False|UVIN-97-UVOUT;n:type:ShaderForge.SFN_Tex2d,id:2739,x:32033,y:33179,ptovrint:False,ptlb:Electricity,ptin:_Electricity,varname:node_2739,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:e34101901c438bd4797d1690ca9796fa,ntxv:0,isnm:False|UVIN-9891-UVOUT;n:type:ShaderForge.SFN_Add,id:4433,x:32285,y:32953,varname:node_4433,prsc:2|A-7198-RGB,B-2739-RGB;n:type:ShaderForge.SFN_TexCoord,id:9707,x:31259,y:32844,varname:node_9707,prsc:2,uv:0;n:type:ShaderForge.SFN_Panner,id:97,x:31717,y:32839,varname:node_97,prsc:2,spu:-0.5,spv:0|UVIN-7522-OUT;n:type:ShaderForge.SFN_Multiply,id:7522,x:31502,y:33046,varname:node_7522,prsc:2|A-9707-UVOUT,B-9859-OUT;n:type:ShaderForge.SFN_Vector2,id:9859,x:31213,y:33223,varname:node_9859,prsc:2,v1:20,v2:1;n:type:ShaderForge.SFN_Panner,id:9891,x:31771,y:33257,varname:node_9891,prsc:2,spu:-1.5,spv:0|UVIN-7522-OUT;n:type:ShaderForge.SFN_Lerp,id:2092,x:31829,y:32500,varname:node_2092,prsc:2|A-6486-RGB,B-9425-RGB,T-9707-U;n:type:ShaderForge.SFN_Color,id:6486,x:31421,y:32201,ptovrint:False,ptlb:node_6486,ptin:_node_6486,varname:node_6486,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_Color,id:9425,x:31421,y:32436,ptovrint:False,ptlb:node_6486_copy,ptin:_node_6486_copy,varname:_node_6486_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0,c2:0,c3:0,c4:1;n:type:ShaderForge.SFN_Multiply,id:9838,x:32188,y:32445,varname:node_9838,prsc:2|A-3577-OUT,B-2092-OUT;n:type:ShaderForge.SFN_Vector1,id:3577,x:31802,y:32322,varname:node_3577,prsc:2,v1:5;n:type:ShaderForge.SFN_Clamp01,id:5693,x:32429,y:32445,varname:node_5693,prsc:2|IN-9838-OUT;n:type:ShaderForge.SFN_Multiply,id:9697,x:32436,y:32737,varname:node_9697,prsc:2|A-2334-OUT,B-4433-OUT;n:type:ShaderForge.SFN_Lerp,id:379,x:31812,y:32086,varname:node_379,prsc:2|A-9425-RGB,B-6486-RGB,T-9707-U;n:type:ShaderForge.SFN_Multiply,id:674,x:32207,y:32219,varname:node_674,prsc:2|A-3577-OUT,B-379-OUT;n:type:ShaderForge.SFN_Clamp01,id:9275,x:32429,y:32219,varname:node_9275,prsc:2|IN-674-OUT;n:type:ShaderForge.SFN_Multiply,id:2334,x:32669,y:32353,varname:node_2334,prsc:2|A-9275-OUT,B-5693-OUT;proporder:7198-2739-6486-9425;pass:END;sub:END;*/

Shader "Shader Forge/EmissionTest" {
    Properties {
        _Base ("Base", 2D) = "white" {}
        _Electricity ("Electricity", 2D) = "white" {}
        _node_6486 ("node_6486", Color) = (1,1,1,1)
        _node_6486_copy ("node_6486_copy", Color) = (0,0,0,1)
    }
    SubShader {
        Tags {
            "RenderType"="Opaque"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma exclude_renderers metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 2.0
            uniform float4 _TimeEditor;
            uniform sampler2D _Base; uniform float4 _Base_ST;
            uniform sampler2D _Electricity; uniform float4 _Electricity_ST;
            uniform float4 _node_6486;
            uniform float4 _node_6486_copy;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.pos = UnityObjectToClipPos(v.vertex );
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
////// Lighting:
////// Emissive:
                float node_3577 = 5.0;
                float3 node_379 = lerp(_node_6486_copy.rgb,_node_6486.rgb,i.uv0.r);
                float4 node_3935 = _Time + _TimeEditor;
                float2 node_7522 = (i.uv0*float2(20,1));
                float2 node_97 = (node_7522+node_3935.g*float2(-0.5,0));
                float4 _Base_var = tex2D(_Base,TRANSFORM_TEX(node_97, _Base));
                float2 node_9891 = (node_7522+node_3935.g*float2(-1.5,0));
                float4 _Electricity_var = tex2D(_Electricity,TRANSFORM_TEX(node_9891, _Electricity));
                float3 emissive = ((saturate((node_3577*node_379))*saturate((node_3577*lerp(_node_6486.rgb,_node_6486_copy.rgb,i.uv0.r))))*(_Base_var.rgb+_Electricity_var.rgb));
                float3 finalColor = emissive;
                return fixed4(finalColor,1);
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
}
