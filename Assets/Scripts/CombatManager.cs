using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatManager : MonoBehaviour {
    public GameObject playerPrefab;
    public GameObject enemyPrefab;
    public CastButtonController castButton;
    public int cardsRequired;
    public List<CardController> selectedCards;
    List<CreatureController> targets;
    SpellProcessor spellProcessor;

    void Awake () {
        targets = new List<CreatureController> ();
        selectedCards = new List<CardController> ();
        spellProcessor = new SpellProcessor ();
    }

    void Start () {
        GenerateCombatParticipants ();
        castButton.combatManager = this;
    }

    void GenerateCombatParticipants () {
        // Instantiate prefabs
        GenerateCreature (playerPrefab);
        GenerateCreature (enemyPrefab);
    }

    void GenerateCreature (GameObject creaturePrefab) {
        GameObject creature = Instantiate (creaturePrefab);

        creature.transform.SetParent (gameObject.transform, false);

        creature.GetComponent<CreatureController> ().combatManager = this;
    }

    public void HandleCreatureClick (CreatureController creature) {
        // Check for target selection and update creature displays accordingly
        if (targets.Contains (creature)) {
            targets.Remove (creature);
            creature.SetTargetingArrowDisplay (false);
        } else {
            targets.Add (creature);
            creature.SetTargetingArrowDisplay (true);
        }
        // Update UI if all conditions for casting a spell have been met
        CheckCastReady ();
    }

    public bool IsSpellValid (List<CardController> selectedCards) {
        // TODO: return true and set ref if cards selected match a spell in database
        this.selectedCards = selectedCards;

        // Update UI if all conditions for casting a spell have been met
        CheckCastReady ();
        return spellProcessor.IsSpellComplete (selectedCards);
        // Let caller know if card selection conditions have been met
    }

    void CheckCastReady () {
        castButton.SetReady (targets.Count != 0 && selectedCards.Count == cardsRequired);
    }

    public void ExecuteSpell () {
        spellProcessor.CastSpell(selectedCards, targets);
    }
}