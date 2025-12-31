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
    public SpellEffectGroup[] effectGroups;
    public SpellEffectData[] effects;

    public SpellEffectGroup[] GetEffectGroups()
    {
        if (effectGroups != null && effectGroups.Length > 0)
        {
            return effectGroups;
        }

        return new SpellEffectGroup[]
        {
            new()
            {
                target = target,
                effects = effects,
            },
        };
    }
}

[Serializable]
public class SpellEffectData
{
    public SpellEffectType effectType;
    public uint value;
}

[Serializable]
public class SpellEffectGroup
{
    public CardTarget target;
    public SpellEffectData[] effects;
}
