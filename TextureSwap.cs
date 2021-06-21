using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureSwap : MonoBehaviour
{
    public Texture[] textures;
    public int currentTexture=0;
    private Material[] materials;
    private Renderer _renderscreen;


    public void changeTexture()
    {
        _renderscreen = GetComponent<Renderer>();
        materials = _renderscreen.materials;
        materials[1].SetTexture("_EmissionMap", textures[currentTexture]);
        currentTexture++;
        Debug.Log(materials[1]);
        Debug.Log(textures[1]);


    }


}
