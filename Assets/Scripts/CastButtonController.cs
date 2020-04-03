using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastButtonController : MonoBehaviour
{
    public Sprite redSprite;
    public Sprite greySprite;

    public int cardsRequired;

    bool isReady;
    SpriteRenderer spriteRenderer;

    void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void SetReady (bool ready) {
        isReady = ready;
        spriteRenderer.sprite = isReady ? redSprite : greySprite;
    }

    void OnMouseUp() {
        if (isReady) {
            Debug.Log("cast button clicked");
            // TODO: CJ - Decrease character health bars
        }
    }
}
