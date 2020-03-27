using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastButtonController : MonoBehaviour
{
    bool isActive;
    SpriteRenderer spriteRenderer;
    public Sprite redSprite;
    public Sprite greySprite;

    public int cardsRequired;

    void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void OnSelectionChanged(int numSelected) {
        bool oldActive = isActive;

        isActive = numSelected == cardsRequired ? true : false;

        if (isActive != oldActive) {
            spriteRenderer.sprite = isActive ? redSprite : greySprite;
        }
    }

    void OnMouseUp() {
        if (isActive) {
            Debug.Log("cast button clicked");
            // TODO: CJ - Decrease character health bars
        }
    }
}
