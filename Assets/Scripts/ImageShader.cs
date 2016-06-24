using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class ImageShader : MonoBehaviour {

	public float intensity;
	public Shader shader;
	private Material material;

	// Creates a private material used to the effect
	void Awake ()
	{
		material = new Material( shader );
	}

	// Postprocess the image
	void OnRenderImage (RenderTexture source, RenderTexture destination)
	{
		if (intensity == 0)
		{
			Graphics.Blit (source, destination);
			return;
		}

		material.SetFloat("_bwBlend", intensity);
		Graphics.Blit (source, destination, material);
	}
}