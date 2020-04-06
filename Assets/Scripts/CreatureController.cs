using UnityEngine;

public class CreatureController : MonoBehaviour {
    HealthbarController healthbarController;

    public string characterName;

    public CombatManager combatManager;

    public GameObject targetingArrow;

    // Raw hp amount, the player could have anywhere from 1-X
    float hp;
    void Start () {
        hp = 100;
        // Populate name of character
        foreach (Transform t in transform) {
            if (t.name == "Name") {
                t.gameObject.GetComponent<TextMesh> ().text = characterName;
            }
            if (t.name == "HealthBar") {
                healthbarController = t.gameObject.GetComponent<HealthbarController> ();
            }
        }
    }

    void OnMouseUp () {
        combatManager.HandleCreatureClick (this);
    }

    public void SetTargetingArrowDisplay (bool shouldDisplay) {
        targetingArrow.SetActive (shouldDisplay);
    }

    // Deducts raw damage from current hp and proportionately scales down the hp bar.  This will be the main method used for visual health updates
    public void TakeDamage (float rawDamage) {
        healthbarController.DecreaseHealth (rawDamage / hp);
        hp -= rawDamage;
        // Check to see if character has died
        // We'll just have the visual indicator for death be that the sprite disappears.
    }

    public bool isCreatureDead () {
        return (hp <= 0);
    }

    public void DestroyCreature () {
        Destroy (gameObject);

    }
}