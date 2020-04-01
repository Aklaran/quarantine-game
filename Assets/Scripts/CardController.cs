using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardController : MonoBehaviour {
    public HandController handController;
    public Color32 unselectedColor;
    public Color32 selectedColor;
    public GameObject cardIndexPrefab;
    CardIndexController cardIndexController;
    SpriteRenderer spriteRenderer;
    bool isSelected;

    // Start is called before the first frame update
    void Start () {
        spriteRenderer = GetComponent<SpriteRenderer> ();
        GenerateCardIndex ();
    }

    void OnMouseUp () {
        if (isSelected) {
            handController.DeselectCard (this);
        } else {
            handController.SelectCard (this);
        }
        isSelected = !isSelected;
        spriteRenderer.color = isSelected ? selectedColor : unselectedColor;
    }

    public void UpdateSelectedCardIndex (int newIndex, bool canCast = false) {
        cardIndexController.UpdateIndex (newIndex);
        cardIndexController.SetCanCast (canCast);
    }

    void GenerateCardIndex () {
        GameObject cardIndexObject = Instantiate (cardIndexPrefab);
        cardIndexObject.transform.SetParent (gameObject.transform, false);

        // Parent -> Child communication only
        cardIndexController = cardIndexObject.GetComponent<CardIndexController> ();
    }
}