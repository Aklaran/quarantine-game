using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardController : MonoBehaviour
{
    public HandController hand;
    public Color32 unselectedColor;
    public Color32 selectedColor;

    SpriteRenderer spriteRenderer;
    bool selected;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnMouseUp() {
        selected = !selected;
        spriteRenderer.color = selected ? selectedColor : unselectedColor;
        
        hand.SelectCard(gameObject);
    }
}
