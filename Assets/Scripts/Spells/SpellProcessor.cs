using System.Collections.Generic;
using UnityEngine;
public class SpellProcessor {
    bool hasElement, hasVerb, hasManner;

    public bool IsSpellComplete (List<CardController> selectedCards) {
        resetSpell ();
        foreach (CardController selectedCard in selectedCards) {
            switch (selectedCard.spell.type) {
                case SpellType.ELEMENT:
                    hasElement = true;
                    break;
                case SpellType.VERB:
                    hasVerb = true;
                    break;
                case SpellType.MANNER:
                    hasManner = true;
                    break;
                default:
                    break;
            }
        }

        return (hasElement && hasVerb && hasManner);
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
        foreach (CreatureController target in targets) {
            target.TakeDamage (multiplier == 0 ? damage : multiplier * damage);
        }
    }

    void resetSpell () {
        this.hasElement = false;
        this.hasVerb = false;
        this.hasManner = false;
    }
}