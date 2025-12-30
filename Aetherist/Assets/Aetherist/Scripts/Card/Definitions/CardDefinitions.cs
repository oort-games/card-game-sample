#region Common
public enum CardType
{
    None = 0,

    Spell,
    Relic,
    Arcana,
}

public enum CardElement
{
    None = 0,

    Fire,
    Water,
    Earth,
    Lightning,
    Wind,
}

public enum CardRarity
{
    Common = 0,
    Uncommon,
    Rare,
    Epic,
    Unique,
    Legendary,
}

public enum CardTarget
{
    None = 0,

    Self,
    SingleEnemy,
    AllEnemies,
    LowestHPEnemy,
}
#endregion

#region Spell
public enum SpellActionType
{
    None = 0,

    Attack,
    Defense,
    Buff,
    Debuff,
    Conversion,
    Utility,
}

public enum SpellEffectType
{
    None = 0,

    Damage,
    Shield,
    Heal,
    Draw,
    ElementAdd,
    ElementRemove,
    StatusApply,
}
#endregion

#region Relic
public enum RelicTriggerType
{
    None = 0,

    OnBattleStart,
    OnTurnStart,
    OnSpellUsed,
    OnElementChanged,
    OnTurnEnd,
}

public enum RelicEffectType
{
    None = 0,
    
    GainMana,
    GainShield,
    Heal,
    IncreaseDamage,
    ModifySpellCost,
    DuplicateSpell,
    AddElement,
    RemoveElement,
}
#endregion