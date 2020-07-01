// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Shader created with Shader Forge v1.26 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.26;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:3138,x:33177,y:32692,varname:node_3138,prsc:2|emission-2522-OUT;n:type:ShaderForge.SFN_Color,id:7241,x:32734,y:32046,ptovrint:False,ptlb:Color,ptin:_Color,varname:node_7241,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.4697635,c2:0.9852941,c3:0.4274438,c4:1;n:type:ShaderForge.SFN_Time,id:8688,x:31764,y:32238,varname:node_8688,prsc:2;n:type:ShaderForge.SFN_Lerp,id:2522,x:33017,y:32368,varname:node_2522,prsc:2|A-7241-RGB,B-8640-RGB,T-9854-OUT;n:type:ShaderForge.SFN_Sin,id:989,x:32267,y:32337,varname:node_989,prsc:2|IN-5361-OUT;n:type:ShaderForge.SFN_Add,id:9892,x:32514,y:32337,varname:node_9892,prsc:2|A-4406-OUT,B-989-OUT;n:type:ShaderForge.SFN_Vector1,id:4406,x:32448,y:32242,varname:node_4406,prsc:2,v1:1;n:type:ShaderForge.SFN_Vector1,id:4374,x:32513,y:32731,varname:node_4374,prsc:2,v1:2;n:type:ShaderForge.SFN_Divide,id:9854,x:32470,y:32546,varname:node_9854,prsc:2|A-9892-OUT,B-4374-OUT;n:type:ShaderForge.SFN_Color,id:8640,x:32734,y:32279,ptovrint:False,ptlb:node_8640,ptin:_node_8640,varname:node_8640,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.2150101,c2:0.3897059,c3:0.1461397,c4:1;n:type:ShaderForge.SFN_Multiply,id:5361,x:32031,y:32366,varname:node_5361,prsc:2|A-8688-T,B-729-OUT;n:type:ShaderForge.SFN_Vector1,id:729,x:31784,y:32597,varname:node_729,prsc:2,v1:8;proporder:7241-8640;pass:END;sub:END;*/

Shader "Shader Forge/GridSpotOpen" {
    Properties {
        _Color ("Color", Color) = (0.4697635,0.9852941,0.4274438,1)
        _node_8640 ("node_8640", Color) = (0.2150101,0.3897059,0.1461397,1)
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
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform float4 _TimeEditor;
            uniform float4 _Color;
            uniform float4 _node_8640;
            struct VertexInput {
                float4 vertex : POSITION;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.pos = UnityObjectToClipPos(v.vertex );
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
////// Lighting:
////// Emissive:
                float4 node_8688 = _Time + _TimeEditor;
                float3 node_2522 = lerp(_Color.rgb,_node_8640.rgb,((1.0+sin((node_8688.g*8.0)))/2.0));
                float3 emissive = node_2522;
                float3 finalColor = emissive;
                return fixed4(finalColor,1);
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
