using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour {
    // Raw hp amount, the player could have anywhere from 1-X
    float hp;
    public string characterName;
    public HealthbarController healthbarController;

    // Start is called before the first frame update
    void Start () {
        hp = 100;
        // Populate name of character
        foreach (Transform t in transform) {
            if (t.name == "Name") {
                t.gameObject.GetComponent<TextMesh> ().text = characterName;
            }
        }
    }

    // Purely for testing purposes
    void OnMouseUp () {
        TakeDamage (20);
    }

    // Deducts raw damage from current hp and proportionately scales down the hp bar.  This will be the main method used for visual health updates
    void TakeDamage (float rawDamage) {
        healthbarController.DecreaseHealth (rawDamage / hp);
        hp -= rawDamage;
        // Check to see if character has died
        // We'll just have the visual indicator for death be that the sprite disappears.
        if (hp <= 0) {
            Destroy (gameObject);
        }
    }
}