using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardController : MonoBehaviour
{

    public HandController hand;

    SpriteRenderer spriteRenderer;


    public Color32 defaultColor;
    public Color32 highlightColor;
    bool selected;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnMouseUp() {
        selected = !selected;
        spriteRenderer.color = selected ? highlightColor : defaultColor;
        
        hand.SelectCard(gameObject);
    }
}
