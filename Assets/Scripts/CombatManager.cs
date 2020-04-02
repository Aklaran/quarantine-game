using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatManager : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject enemyPrefab;
    public List<CreatureController> combatParticipants;
    void Start()
    {
        GenerateCombatParticipants();
    }

    void GenerateCombatParticipants() {
        // Instantiate the player and place on the left of the screen
        GameObject player = GeneratePlayer();

        // Instantiate the enemies and place on the right of the screen
        GameObject enemy = GenerateEnemy();

        // Keep track of all targetable entities
        combatParticipants.Add(player.GetComponent<CreatureController>());
        combatParticipants.Add(enemy.GetComponent<CreatureController>());
    }

    GameObject GeneratePlayer() {
        GameObject player = Instantiate(playerPrefab);
        player.transform.SetParent(gameObject.transform, false);

        return player;
    }

    GameObject GenerateEnemy() {
        GameObject player = Instantiate(enemyPrefab);
        player.transform.SetParent(gameObject.transform, false);

        return player;
    }
}
