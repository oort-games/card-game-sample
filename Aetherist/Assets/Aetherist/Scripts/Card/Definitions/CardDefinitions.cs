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
    OnTurnEnd,

    OnSpellUsed, // 사용 선언
    OnSpellResolved, // 효과 적용 완료

    OnElementChanged,
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

public enum RelicConditionType
{
    HandCardCount, // 손에 들고 있는 카드 수
    ManaRemaining, // 남아 있는 마나
    ManaSpent, // 이번 턴에 사용한 마나 총량
    SpellUsedCount, // 이번 턴에 사용한 스펠 횟수
    DistinctElementUsed, // 이번 턴에 사용한 서로 다른 속성 개수
    SpecificElementUsed, // 특정 속성 스펠 사용 횟수
    PlayerHealthPercent, // 플레이어 체력 비율
    EnemyCount, // 현재 살아있는 적 수
}
#endregion

