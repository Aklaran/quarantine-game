using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastButtonController : MonoBehaviour
{
    bool isReady;
    SpriteRenderer spriteRenderer;
    public Sprite redSprite;
    public Sprite greySprite;

    public int cardsRequired;

    void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void OnSelectionChanged(int numSelected) {
        bool oldActive = isReady;

        isReady = numSelected == cardsRequired;
        
        if (isReady != oldActive) {
            spriteRenderer.sprite = isReady ? redSprite : greySprite;
        }
    }

    void OnMouseUp() {
        if (isReady) {
            Debug.Log("cast button clicked");
            // TODO: CJ - Decrease character health bars
        }
    }
}
