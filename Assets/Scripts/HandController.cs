using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandController : MonoBehaviour
{
    public GameObject cardPrefab;
    public CastButtonController castButton;
    public List<GameObject> cards;
    public List<GameObject> selectedCards;
    public int numCards;

    public CardController foo;

    void Start()
    {
        GenerateCards();
    }

    public void SelectCard(GameObject card) {
        selectedCards.Add(card);
        castButton.CardSelected(selectedCards.Count);
    }

    void GenerateCards() {
        for (int i = 0; i < numCards; i++) {
            GenerateCard(i);
        }
    }

    void GenerateCard(int index) {
            string cardName = string.Format("card{0}", index);
            Vector3 cardTransform = AlignCard(index+1, (RectTransform)transform);
            
            GameObject cardGameObject = Instantiate(cardPrefab, cardTransform, transform.rotation);
            cardGameObject.name = cardName;
            cardGameObject.GetComponent<CardController>().hand = this;

            cards.Add(cardGameObject);
    }

    Vector3 AlignCard(int index, RectTransform rectTransform) {
        float relativeIndex = (float)index / numCards;
        float startPosition = rectTransform.position.x - (rectTransform.rect.width / 2);
        float positionMultiplier = ((float)rectTransform.rect.width - (rectTransform.rect.width / numCards));

        float relativeX = relativeIndex * positionMultiplier + startPosition;

        return new Vector3(relativeX, rectTransform.position.y, rectTransform.position.z);
    }


}
