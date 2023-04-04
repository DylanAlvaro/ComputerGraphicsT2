using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostProcessing : MonoBehaviour
{
    public Material material;
    
    // Start is called before the first frame update
    void Start()
    {
        Camera cam = GetComponent<Camera>();
        cam.depthTextureMode = DepthTextureMode.Depth;
    }

    private void OnRenderImage(RenderTexture src, RenderTexture dest)
    {
        material.SetFloat("_DeltaX", 1.0f / (float)src.width);
        material.SetFloat("_DeltaY", 1.0f / (float)src.height);
        
        Graphics.Blit(src, dest, material);
    }
}
