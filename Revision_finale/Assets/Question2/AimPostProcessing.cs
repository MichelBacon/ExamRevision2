using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class AimPostProcessing : MonoBehaviour {
    private Material material;
    public Texture2D texture;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void Awake()
    {
        material = new Material(Shader.Find("Hidden/ShaderQ2"));
        material.SetTexture("_AimTexture", texture);
    }

    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        Graphics.Blit(source, destination, material);
    }
}
