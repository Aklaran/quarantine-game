using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandController : MonoBehaviour
{
    public List<GameObject> cards;
    public List<GameObject> selectedCards;
    public int maxCards;
    public GameObject cardPrefab;

    public CastButtonController castButton;

    void Start()
    {
        GenerateCards();
    }

    public void SelectCard(GameObject card) {
        if (!selectedCards.Contains(card)) {
            selectedCards.Add(card);
        } else {
            selectedCards.Remove(card);
        }

        castButton.OnSelectionChanged(selectedCards.Count);
    }

    void GenerateCards() {
        for (int i = 0; i < maxCards; i++) {
            GenerateCard(i);
        }
    }

    void GenerateCard(int index) {
        string cardName = string.Format("card{0}", index);

        Vector3 cardTransform = AlignCard(index, (RectTransform)transform); // cast transform as RectTransform to expose width

        GameObject cardGameObject = Instantiate(cardPrefab, cardTransform, transform.rotation);
        cardGameObject.name = cardName;

        // Give the card object's script a reference to this script.
        cardGameObject.GetComponent<CardController>().hand = this;

        cards.Add(cardGameObject);
    }

    Vector3 AlignCard(int index, RectTransform rectTransform) {
        float startPosition = rectTransform.position.x - (rectTransform.rect.width / 2);
        float interval = rectTransform.rect.width / (maxCards + 1);
        
        float relativeX = startPosition + (interval * (index + 1));

        return new Vector3(relativeX, rectTransform.position.y, rectTransform.position.z);
    }
}
