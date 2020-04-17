Shader "StencilOutlinePostEffect"
{
	Properties
	{
		_OutlineColor("OutlineColor", Color) = (1, 1, 1, 1)
	}

	SubShader
	{
		Cull Off ZWrite Off ZTest Always

		Stencil
		{
			Ref 1
			Comp Equal
		}

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

			half4 _OutlineColor;

			v2f vert(appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = v.uv;
				return o;
			}

			fixed4 frag(v2f i) : SV_Target
			{
				return _OutlineColor;
			}
			ENDCG
		}
	}
}