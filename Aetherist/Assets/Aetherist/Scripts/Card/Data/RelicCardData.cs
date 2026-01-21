using System;
using UnityEngine;

[CreateAssetMenu(fileName = "RelicCard", menuName = "Aetherist/Card/RelicCard Data")]
public class RelicCardData : CardData
{
    protected override CardType FixedType => CardType.Relic;

    [Header("Trigger")]
    public RelicTriggerType triggerType;

    [Header("Conditions")]
    public RelicConditionData[] conditions;

    [Header("Effects")]
    public RelicEffectData[] effects;

    [Header("Rules")]
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