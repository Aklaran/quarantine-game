using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardController : MonoBehaviour {
    public HandController handController;
    public Color32 unselectedColor;
    public Color32 selectedColor;
    public GameObject cardIndexPrefab;
    public Spell spell;
    CardIndexController cardIndexController;
    SpriteRenderer spriteRenderer;
    bool isSelected;

    // Start is called before the first frame update
    void Start () {
        spriteRenderer = GetComponent<SpriteRenderer> ();
        GenerateCardIndex ();
    }
    void GenerateCardIndex () {
        GameObject cardIndexObject = Instantiate (cardIndexPrefab);
        cardIndexObject.transform.SetParent (gameObject.transform, false);

        // Parent -> Child communication only
        cardIndexController = cardIndexObject.GetComponent<CardIndexController> ();
    }

    void OnMouseUp () {
        handController.HandleCardClick (this, isSelected);
    }

    public void SetSelected (bool selected) {
        this.isSelected = selected;
    }

    public void UpdateCardDisplay () {
        // A non-zero index indicates that the card is selected
        spriteRenderer.color = isSelected ? selectedColor : unselectedColor;
    }

    public void UpdateCardIndexDisplay (int newIndex, bool canCast = false) {
        cardIndexController.UpdateIndexDisplay (newIndex, canCast);
    }
}