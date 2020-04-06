using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardIndexController : MonoBehaviour {
    public Color32 readyCastColor;
    public Color32 unreadyCastColor;
    int indexToDisplay;
    bool isDisplayed, canCast;
    TextMesh textMesh;
    // Start is called before the first frame update
    void Start () {
        textMesh = GetComponent<TextMesh> ();
    }

    public void UpdateIndexDisplay (int index, bool canCast) {
        SetIsDisplayed (index != -1);
        UpdateIndex (index);
        SetCanCast (canCast);
        UpdateText ();
        UpdateColor ();
    }

    void UpdateIndex (int index) {
        indexToDisplay = index;
    }

    void UpdateText () {
        if (isDisplayed) {
            textMesh.text = indexToDisplay.ToString ();
        } else {
            textMesh.text = "";
        }
    }

    void SetIsDisplayed (bool isDisplayed) {
        this.isDisplayed = isDisplayed;
    }

    void SetCanCast (bool canCast) {
        this.canCast = canCast;
        UpdateColor ();
    }

    void UpdateColor () {
        textMesh.color = canCast ? readyCastColor : unreadyCastColor;
    }
}