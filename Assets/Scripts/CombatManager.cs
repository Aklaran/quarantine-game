using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatManager : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject enemyPrefab;

    public CastButtonController castButton;

    public int cardsRequired;

    List<CreatureController> targets;

    int cardsSelected;

    void Awake() {
        targets = new List<CreatureController>();
    }

    void Start()
    {
        GenerateCombatParticipants();
    }

    void GenerateCombatParticipants() {
        // Instantiate prefabs
        GenerateCreature(playerPrefab);
        GenerateCreature(enemyPrefab);
    }

    void GenerateCreature(GameObject creaturePrefab) {
        GameObject creature = Instantiate(creaturePrefab);

        creature.transform.SetParent(gameObject.transform, false);

        creature.GetComponent<CreatureController>().combatManager = this;
    }

    public void HandleCreatureClick(CreatureController creature) {

        // Check for target selection and update creature displays accordingly
        if (targets.Contains(creature)) {
            targets.Remove(creature);

            creature.SetTargetingArrowDisplay(false);

        } else {
            targets.Add(creature);

            creature.SetTargetingArrowDisplay(true);

        }

        // Update UI if all conditions for casting a spell have been met
        CheckCastReady();
    }

    public bool ParseSpell(int numCards) {
        // TODO: return true and set ref if cards selected match a spell in database
        
        this.cardsSelected = numCards;

        // Update UI if all conditions for casting a spell have been met
        CheckCastReady();

        // Let caller know if card selection conditions have been met
        return this.cardsSelected == cardsRequired;
    }

    void CheckCastReady () {
        castButton.SetReady(targets.Count != 0 && cardsSelected == cardsRequired);
    }

    public void ExecuteSpell() {
        // TODO: Apply the spell effects on the target
    }
}
