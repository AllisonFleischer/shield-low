//CODE BY SeventySevian and inbgche
//https://gist.github.com/inbgche/a81169d4cd8ba662817e
Shader "SeventySevian/Pixelated-Mobile" {
	Properties 
	{
			_MainTex ("Base (RGB) Trans (A)", 2D) = "white" {}
			_Color ("Color", Color) = (1, 1, 1, 1)
			//_PixelCountU ("Pixel Count U", Range (1, 500)) = 100
			_PixelCount ("Pixel Count", Range (1, 500)) = 200
		}
	 
		SubShader 
		{
			Tags {"Queue"="Transparent" "RenderType"="Transparent"}
			LOD 100
			
			Lighting Off
			Blend SrcAlpha OneMinusSrcAlpha 
			
	        	Pass 
	        	{            
				CGPROGRAM 
				#pragma vertex vert
				#pragma fragment frag
								
				#include "UnityCG.cginc"
				
				sampler2D _MainTex;	
				fixed4 _Color;
				half _PixelCount;
						
				struct v2f 
				{
				    float4 pos : SV_POSITION;
				    float2 uv : TEXCOORD1;
				};
				
				v2f vert(appdata_base v)
				{
				    v2f o;			    
				    o.uv = v.texcoord.xy;
				    o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
				    
				    return o;
				}
				
				fixed4 frag(v2f i) : COLOR
				{   
					fixed pixelWidth = 1.0f / _PixelCount;
					fixed pixelHeight = 1.0f / _PixelCount;
					
					half2 uv = half2((int)(i.uv.x / pixelWidth) * pixelWidth, (int)(i.uv.y / pixelHeight) * pixelHeight);
					fixed4 col = tex2D(_MainTex, uv);
				
				    return col * _Color;
				}
				ENDCG
		  	}
		}
	 FallBack "Diffuse"
	}
