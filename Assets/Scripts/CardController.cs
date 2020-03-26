using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardController : MonoBehaviour
{

    public HandController hand;

    SpriteRenderer spriteRenderer;

    public Color32 highlightColor;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnMouseUp() {
        spriteRenderer.color = highlightColor;
        hand.SelectCard(gameObject);
    }

    public void Highlight() {
        spriteRenderer.color = highlightColor;
    }
}
