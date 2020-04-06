using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastButtonController : MonoBehaviour
{
    public Sprite redSprite;
    public Sprite greySprite;
    public int cardsRequired;
    public CombatManager combatManager;

    bool isReady;
    SpriteRenderer spriteRenderer;

    void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void SetReady (bool ready) {
        isReady = ready;
        spriteRenderer.sprite = isReady ? redSprite : greySprite;
    }

    void OnMouseUp() {
        if (isReady) {
            combatManager.ExecuteSpell();
        }
    }
}
