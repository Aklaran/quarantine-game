using System;
[Serializable]
public class Spell {
    // Applicable to all
    public SpellType type;
    // Applicable to all
    public float amount;
    // Applicable to cards with manner type OVER_TIME or LATER
    public int duration;
    // Applicable to cards with different Verb types
    public float multiplier;
    // These three spell types are going to be mutually exclusively filled based on what kind of card it is.  Default will be null.
    public SpellElement element;
    public SpellVerb verb;
    public SpellManner manner;
}