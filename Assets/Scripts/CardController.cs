using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardController : MonoBehaviour {
    public HandController handController;
    public Color32 unselectedColor;
    public Color32 selectedColor;
    public GameObject indexIndicatorPrefab;
    SelectedIndexController selectedIndexController;
    SpriteRenderer spriteRenderer;
    bool isSelected;

    // Start is called before the first frame update
    void Start () {
        spriteRenderer = GetComponent<SpriteRenderer> ();
        GenerateIndexIndicator();
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
        selectedIndexController.UpdateIndex(newIndex);
        selectedIndexController.SetCanCast(canCast);
    }

    void GenerateIndexIndicator () {
        GameObject indexIndicatorObject = Instantiate (indexIndicatorPrefab);
        indexIndicatorObject.transform.SetParent(gameObject.transform, false);

        // Parent -> Child communication only
        selectedIndexController = indexIndicatorObject.GetComponent<SelectedIndexController>();
    }
}