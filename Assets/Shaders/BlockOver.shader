// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'



// Shader created with Shader Forge v1.26 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.26;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:True,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:3138,x:32512,y:32485,varname:node_3138,prsc:2|emission-4666-OUT;n:type:ShaderForge.SFN_Tex2d,id:6251,x:31913,y:32864,ptovrint:False,ptlb:node_6251,ptin:_node_6251,varname:node_6251,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:677724291ac98bd45a30280cff0f12cd,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Multiply,id:4666,x:32301,y:32583,varname:node_4666,prsc:2|A-9002-OUT,B-9891-OUT;n:type:ShaderForge.SFN_Time,id:7959,x:31259,y:33071,varname:node_7959,prsc:2;n:type:ShaderForge.SFN_Lerp,id:9002,x:32103,y:32423,varname:node_9002,prsc:2|A-5309-OUT,B-9445-OUT,T-9319-OUT;n:type:ShaderForge.SFN_Vector1,id:5309,x:31428,y:32408,varname:node_5309,prsc:2,v1:1;n:type:ShaderForge.SFN_Vector1,id:9445,x:31428,y:32487,varname:node_9445,prsc:2,v1:2;n:type:ShaderForge.SFN_Sin,id:9491,x:31661,y:32912,varname:node_9491,prsc:2|IN-6617-OUT;n:type:ShaderForge.SFN_Add,id:2890,x:31711,y:32715,varname:node_2890,prsc:2|A-5309-OUT,B-9491-OUT;n:type:ShaderForge.SFN_Divide,id:9319,x:32001,y:32627,varname:node_9319,prsc:2|A-2890-OUT,B-9445-OUT;n:type:ShaderForge.SFN_Multiply,id:6617,x:31661,y:33110,varname:node_6617,prsc:2|A-7959-T,B-9445-OUT;n:type:ShaderForge.SFN_Color,id:1423,x:31913,y:33090,ptovrint:False,ptlb:node_1423,ptin:_node_1423,varname:node_1423,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.6470588,c2:0.4685599,c3:0,c4:1;n:type:ShaderForge.SFN_Multiply,id:9891,x:32190,y:32832,varname:node_9891,prsc:2|A-6251-RGB,B-1423-RGB;proporder:6251-1423;pass:END;sub:END;*/

Shader "Shader Forge/Block" {
	SubShader{
		Tags{
		"Queue" = "Transparent" //"IgnoreProjector"="True" "RenderType"="Transparent"
	}
		Pass{

		ZWrite Off

		Blend SrcAlpha OneMinusSrcAlpha

		CGPROGRAM

			#pragma vertex vert 
			#pragma fragment frag

			float4 vert(float4 vertexPos : POSITION) : SV_POSITION
			{
				return UnityObjectToClipPos(vertexPos);
			}

			float4 frag(void) : COLOR
			{
				return float4(0.6470588,0.4685599,0,0.8);
			// the fourth component (alpha) is important: 
			// this is semitransparent green
			}

		ENDCG

		}
	}
}