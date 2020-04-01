using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedIndexController : MonoBehaviour {
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
        Debug.Log ("Changed is Displayed to: " + isDisplayed + "" + gameObject.name);
        indexToDisplay = index;
        UpdateText ();
    }

    public void SetCanCast (bool canCast) {
        this.canCast = canCast;
        UpdateColor ();
    }

    void UpdateText () {
        if (isDisplayed) {
            textMesh.text = indexToDisplay.ToString ();
        } else {
            textMesh.text = "";
        }
    }

    void UpdateColor () {
        textMesh.color = canCast?readyCastColor : unreadyCastColor;
    }
}