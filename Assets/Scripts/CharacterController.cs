using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour {
    // Raw hp amount, the player could have anywhere from 1-1000
    float hp;
    // This is going to be the current scale left on the hp bar, in proportion to how much raw health is left on the character
    float hpScale;
    // This is used to collect the intial raw scale value for the healthbar.  The healthbar could have a y value of like .9 so we want decutions to be made 
    // in proportion to how much raw health is being taken off
    public Transform hpTransform;
    public string characterName;

    // Start is called before the first frame update
    void Start () {
        // This hp value is raw
        hp = 100;
        // Referencing the current hp bar's y scale value (the width)
        hpScale = hpTransform.localScale.y;

        // Populate name of character
        foreach (Transform t in transform) {
            if (t.name == "Name") {
                t.gameObject.GetComponent<TextMesh> ().text = characterName;
            }
        }
    }

    // Update is called once per frame
    void Update () {
        // We'll just have the visual indicator for death be that the sprite disappears.
        if (hp <= 0) {
            Destroy (gameObject);
        }
    }

    // Deducts raw damage from current hp and proportionately scales down the hp bar.  This will be the main method used for visual health updates
    void takeDamage (float rawDamage) {
        hpScale -= (hpScale * (rawDamage / hp));
        hp -= rawDamage;
    }
    // Purely for testing purposes
    void OnMouseUp () {
        takeDamage (20);
    }

    public float getHpScale () {
        return hpScale;
    }
}