using UnityEngine;

public abstract class Card
{
    public CardData Data { get; private set; }

    public uint CurrentCost { get; protected set; }
    public bool IsExhausted { get; protected set; }

    protected Card(CardData data)
    {
        Data = data;
        CurrentCost = GetBaseCost();
    }

    protected virtual uint GetBaseCost() => 0;

    public abstract bool CanPlay(BattleContext context);
    public abstract void Play(BattleContext context);
}
