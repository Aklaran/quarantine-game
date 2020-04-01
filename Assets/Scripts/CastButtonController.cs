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

    public bool OnSelectionChanged(int numSelected) {
        isReady = numSelected == cardsRequired;
        spriteRenderer.sprite = isReady ? redSprite : greySprite;
        return isReady;
    }

    void OnMouseUp() {
        if (isReady) {
            Debug.Log("cast button clicked");
            // TODO: CJ - Decrease character health bars
        }
    }
}
