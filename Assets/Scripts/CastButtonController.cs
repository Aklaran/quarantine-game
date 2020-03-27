using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastButtonController : MonoBehaviour
{
    bool isActive;
    SpriteRenderer spriteRenderer;
    public Sprite redSprite;
    public Sprite greySprite;

    void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void CardSelected(int numSelected) {
        bool oldActive = isActive;

        isActive = numSelected == 3 ? true : false;

        if (isActive != oldActive) {
            spriteRenderer.sprite = isActive ? redSprite : greySprite;
        }
    }
}
