using System;
using UnityEngine;

[CreateAssetMenu(fileName = "RelicCard", menuName = "Aetherist/Card/RelicCard Data")]
public class RelicCardData : CardData
{
    protected override CardType FixedType => CardType.Relic;

    [Header("Relic Info")]
    public RelicTriggerType triggerType;

    [Header("Conditions")]
    public RelicConditionData[] conditions;

    [Header("Effect")]
    public RelicEffectData[] effects;

    [Header("Rule")]
    public bool isUnique = true;
}

[Serializable]
public class RelicEffectData
{
    public RelicEffectType effectType;
    public uint value;
}

[Serializable]
public class RelicConditionData
{
    [Header("Condition")]
    public RelicConditionType conditionType;

    [Header("Compare")]
    public ComparisonType comparison;
    public uint value;

    [Header("Optional Params")]
    public CardElement element;
    public CardType cardType;
}