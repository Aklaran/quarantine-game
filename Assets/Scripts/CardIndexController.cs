﻿using System.Collections;
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

    public void UpdateIndex (int index) {
        isDisplayed = index != 0;
        indexToDisplay = index;
        UpdateText ();
    }

    void UpdateText () {
        if (isDisplayed) {
            textMesh.text = indexToDisplay.ToString ();
        } else {
            textMesh.text = "";
        }
    }

    public void SetCanCast (bool canCast) {
        this.canCast = canCast;
        UpdateColor ();
    }

    void UpdateColor () {
        textMesh.color = canCast?readyCastColor : unreadyCastColor;
    }
}