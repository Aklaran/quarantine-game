using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandController : MonoBehaviour {
    public List<CardController> selectedCards;
    public int maxCards;
    public GameObject cardPrefab;

    public CombatManager combatManager;

    void Start () {
        GenerateCards ();
    }

    void GenerateCards () {
        for (int i = 0; i < maxCards; i++) {
            GenerateCard (i, string.Format ("Card-{0}", i));
        }
    }

    void GenerateCard (int index, string cardName) {
        Vector3 cardTransform = AlignCard (index, (RectTransform) transform); // cast transform as RectTransform to expose width

        GameObject cardGameObject = Instantiate (cardPrefab, cardTransform, transform.rotation);
        cardGameObject.name = cardName;
        // Give the card object's script a reference to this script.
        cardGameObject.GetComponent<CardController> ().handController = this;
    }

    Vector3 AlignCard (int index, RectTransform rectTransform) {
        float startPosition = rectTransform.position.x - (rectTransform.rect.width / 2);
        float interval = rectTransform.rect.width / (maxCards + 1);
        float relativeX = startPosition + (interval * (index + 1));

        // 1.1 is a 10% offset downward on the y axis to give room for the selected card indicators
        return new Vector3 (relativeX, (float) (rectTransform.position.y * 1.1), rectTransform.position.z);
    }

    public void HandleCardClick (CardController cardController, bool isSelected) {
        if (isSelected) {
            SelectCard (cardController);
        } else {
            DeselectCard (cardController);
        }

        bool canCast = combatManager.ParseSpell (selectedCards.Count);

        UpdateAllSelectedCards (canCast);
    }

    void SelectCard (CardController cardController) {
        selectedCards.Add (cardController);
    }

    void DeselectCard (CardController cardController) {
        selectedCards.Remove (cardController);
        cardController.UpdateSelectedCardIndex (0);
    }

    void UpdateAllSelectedCards (bool canCast) {
        foreach (CardController selectedCardController in selectedCards) {
            selectedCardController.UpdateSelectedCardIndex (RetrieveDisplayIndex (selectedCardController), canCast);
        }
    }

    int RetrieveDisplayIndex (CardController cardController) {
        return selectedCards.IndexOf (cardController) + 1;
    }
}