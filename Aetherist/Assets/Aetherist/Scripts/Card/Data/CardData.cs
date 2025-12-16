using UnityEngine;

public abstract class CardData : ScriptableObject
{
    [Header("Base Info")]
    public uint id;
    public string displayName;
    [TextArea]
    public string description;

    [Header("Visual")]
    public Sprite icon;

    [Header("Meta")]
    public CardType type;
    public CardRarity rarity;

    protected abstract CardType FixedType { get; }

    protected virtual void OnEnable()
    {
        type = FixedType;
    }
}
