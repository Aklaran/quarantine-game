using System.Collections.Generic;
using UnityEngine;
public class SpellProcessor {

    public bool IsSpellComplete (List<CardController> selectedCards) {
        return true;
    }

    public void CastSpell (List<CardController> selectedCards, List<CreatureController> targets) {
        float damage = 0;
        float multiplier = 0;
        foreach (CardController selectedCard in selectedCards) {
            switch (selectedCard.spell.type) {
                // Only element will have an amount
                case SpellType.ELEMENT:
                    damage += selectedCard.spell.amount;
                    break;
                    // Manner or Verb can have multipliers for now
                default:
                    multiplier += selectedCard.spell.multiplier;
                    break;
            }
        }
        Debug.Log ("Current damage amount: " + multiplier * damage);
        foreach (CreatureController target in targets) {
            target.TakeDamage (multiplier == 0 ? damage : multiplier * damage);
        }
    }
}