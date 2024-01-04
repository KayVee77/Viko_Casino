using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpriteChanger : MonoBehaviour
{
    public Sprite newSprite; 
    private Sprite oldSprite; 

    private Image buttonImage; 
    private bool isOriginalSprite = true; 

    void Start()
    {
        buttonImage = GetComponent<Image>();
        if (buttonImage != null)
        {
            oldSprite = buttonImage.sprite; 
        }
    }

    public void ToggleButtonSprite()
    {
        if (buttonImage == null || newSprite == null)
        {
            return;
        }

        buttonImage.sprite = isOriginalSprite ? newSprite : oldSprite;
        isOriginalSprite = !isOriginalSprite; 
    }
}
