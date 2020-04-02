using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatManager : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject enemyPrefab;

    public CastButtonController castButton;

    public int cardsRequired;

    GameObject target;

    int cardsSelected;

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

    public void SetTarget(GameObject target) {
        this.target = target;

        CheckCastReady();
    }

    public bool ParseSpell(int numCards) {
        // TODO: return true and set ref if cards selected match a spell in database

        this.cardsSelected = numCards;

        CheckCastReady();

        return this.cardsSelected == cardsRequired;
    }

    void CheckCastReady () {
        if (target != null && cardsSelected == cardsRequired) {
            castButton.SetReady(true);
        } else {
            castButton.SetReady(false);
        }
    }

    public void ExecuteSpell() {
        // Apply the spell effects on the target
    }
}
