Shader "Custom/DamageTaken"
{
    Properties
    {
	
		

		_MainTex("MainTex", 2D) = "red" {}
		_NormalMap("NormalMap", 2D) = "grey" {}
		_NormalStrength("NormalStrength", Range (-2,10)) = 1
    }
    SubShader
    {
      
	 
        CGPROGRAM
        

		 #pragma surface surf Lambert

		

		 
	


		 struct Input
		{
			float2 uv_MainTex;
		
		};

		 sampler2D _MainTex;
		 sampler2D _NormalMap;


		 void surf( in Input IN, inout SurfaceOutput OUT){
		
			float3 norm = UnpackNormal(tex2D(_NormalMap,IN.uv_MainTex));

			OUT.Normal = norm;


			OUT.Albedo = tex2D(_MainTex,IN.uv_MainTex);

			
		}
        ENDCG
    }
    FallBack "Diffuse"
}
