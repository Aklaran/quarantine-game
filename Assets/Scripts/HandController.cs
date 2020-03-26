using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandController : MonoBehaviour
{
    public GameObject cardPrefab;
    public GameObject[] cards;
    public int numCards;

    // Start is called before the first frame update
    void Start()
    {
        GenerateCards();
    }

    void GenerateCards() {
        for (int i = 0; i < numCards; i++) {
            GenerateCard(i);
        }
    }

    void GenerateCard(int index) {
            string cardName = string.Format("card{0}", index);
            Vector3 cardTransform = alignCard(index+1, (RectTransform)transform);
            
            GameObject cardGameObject = Instantiate(cardPrefab, cardTransform, transform.rotation);
            cardGameObject.name = cardName;
    }

    Vector3 alignCard(int index, RectTransform rectTransform) {
        float relativeIndex = (float)index / numCards;
        float startPosition = rectTransform.position.x - (rectTransform.rect.width / 2);
        float positionMultiplier = ((float)rectTransform.rect.width - (rectTransform.rect.width / numCards));

        float relativeX = relativeIndex * positionMultiplier + startPosition;

        return new Vector3(relativeX, rectTransform.position.y, rectTransform.position.z);
    }
}
