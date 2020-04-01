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
    void GenerateCardIndex () {
        GameObject cardIndexObject = Instantiate (cardIndexPrefab);
        cardIndexObject.transform.SetParent (gameObject.transform, false);

        // Parent -> Child communication only
        cardIndexController = cardIndexObject.GetComponent<CardIndexController> ();
    }

    void OnMouseUp () {
        isSelected = !isSelected;
        spriteRenderer.color = isSelected ? selectedColor : unselectedColor;

        handController.HandleCardClick (this, isSelected);
    }

    public void UpdateSelectedCardIndex (int newIndex, bool canCast = false) {
        cardIndexController.UpdateIndex (newIndex);
        cardIndexController.SetCanCast (canCast);
    }
}