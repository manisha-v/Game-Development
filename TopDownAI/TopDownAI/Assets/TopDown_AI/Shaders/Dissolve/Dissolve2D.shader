// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Custom/Effects/Dissolve2D" {
Properties {    
	 _Color ("Color", Color) = (1,1,1,1)	 
	 _ImageColor("ImageColor", Color) = (1,1,1,1)	 
	 _InnerColor ("DissolveInnerColor", Color) = (1,0,0,1)
	 _OuterColor ("DissolveOuterColor", Color) = (0,0,1,1)
	_DissolveOuterLength("DissolveOuterLength",Float)=0.025
  	_DissolveInnerLength("DissolveInnerLength",Float)=0.05    
   // _DissolveValue ("SliderValue", Range(0,1)) = 0.01      
    _MainTex ("Texture", 2D) = "white" { }
    _DissolveTex ("Dissolve Texture", 2D) = "white" { }
  
}
SubShader {
	Tags {"Queue" = "Transparent" }
    Pass {
    Blend SrcAlpha OneMinusSrcAlpha  
    Cull off   
	CGPROGRAM
	#pragma vertex vert
	#pragma fragment frag	
	#include "UnityCG.cginc"	
	float4 _InnerColor,_OuterColor,_Color,_ImageColor;
	sampler2D _MainTex,_DissolveTex;
	
	
	struct v2f {
	    float4  pos : SV_POSITION;
	    float2  uv : TEXCOORD0;
	};	
	float4 _MainTex_ST;	
	float _DissolveInnerLength,_DissolveOuterLength;
	//float DissolveValue;
	v2f vert (appdata_base v){
	    v2f o;
	    o.pos = UnityObjectToClipPos (v.vertex);
	    o.uv = TRANSFORM_TEX (v.texcoord, _MainTex);
	    return o;
	}	
	half4 frag (v2f i) : COLOR{		
		half4 texcol,dissolvecol,finalcol;
		dissolvecol = tex2D (_DissolveTex, i.uv);
		texcol = tex2D (_MainTex, i.uv);
		
		finalcol=texcol;//+frontcol;
		float dissolveValue=1-_Color.r;
		if(dissolvecol.r-_DissolveInnerLength<dissolveValue){
			finalcol=_InnerColor*texcol.a;
		}
		if(dissolvecol.r<dissolveValue+_DissolveOuterLength){
			finalcol=_OuterColor*texcol.a;;
		}
		if(dissolvecol.r<dissolveValue){
			finalcol.a=0.0;
		}
		
		
		
		
	    return finalcol*_ImageColor*_Color.a;
	}
	ENDCG

    }
}
Fallback "VertexLit"
} 


//o.Gloss = skincol.a;
//_SpecColor *= transparencycol.r + 0.3f;
//o.Specular = _Shininess;//*transparencycol.r + 0.1f;

//o.Normal = UnpackNormal(tex2D(_BumpMap, IN.uv_BumpMap));