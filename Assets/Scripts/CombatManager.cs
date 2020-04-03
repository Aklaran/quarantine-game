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
        GameObject player = GenerateCreature(playerPrefab);
        GameObject enemy = GenerateCreature(enemyPrefab);
    }

    GameObject GenerateCreature(GameObject creaturePrefab) {
        GameObject creature = Instantiate(creaturePrefab);

        creature.transform.SetParent(gameObject.transform, false);

        creature.GetComponent<CreatureController>().combatManager = this;

        return creature;
    }

    public void HandleCreatureClick(CreatureController creature) {

        // Check for target selection and update visual indicators accordingly
        if (targets.Contains(creature)) {
            targets.Remove(creature);

            creature.HideTargetingArrow();
        } else {
            targets.Add(creature);

            creature.ShowTargetingArrow();
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
        if (targets.Count != 0 && cardsSelected == cardsRequired) {
            castButton.SetReady(true);
        } else {
            castButton.SetReady(false);
        }
    }

    public void ExecuteSpell() {
        // TODO: Apply the spell effects on the target
    }
}
