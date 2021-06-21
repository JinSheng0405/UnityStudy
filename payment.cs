using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class payment : MonoBehaviour
{
    public Image oldImage;
    public Sprite[] images;
    public int currentImage = 0;
    

    public void changeImage()
    {
        oldImage.sprite = images[currentImage];
        currentImage++;
        Debug.Log("changed");


    }


}