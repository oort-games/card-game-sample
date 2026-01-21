using System;
using UnityEngine;

[CreateAssetMenu(fileName = "ArcanaCard", menuName = "Aetherist/Card/ArcanaCard Data")]
public class ArcanaCardData : CardData
{
    protected override CardType FixedType => CardType.Arcana;

    [Header("Effects")]
    public ArcanaEffectData[] effects;
}

[Serializable]
public class ArcanaEffectData
{
    public ArcanaEffectType effectType;
    public uint value;
}