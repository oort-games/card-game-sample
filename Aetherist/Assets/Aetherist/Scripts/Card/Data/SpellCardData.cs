using System;
using UnityEngine;

[CreateAssetMenu(fileName = "SpellCard", menuName = "Aetherist/Card/SpellCard Data")]
public class SpellCardData : CardData
{
    protected override CardType FixedType => CardType.Spell;

    [Header("Spell Info")]
    public SpellActionType actionType;
    public CardElement element;
    public CardTarget target;

    [Header("Cost")]
    public uint cost = 1;

    [Header("Effect")]
    public SpellEffectData[] effects;
}

    [Serializable]
public class SpellEffectData
{
    public SpellEffectType effectType;
    public uint value;
}
