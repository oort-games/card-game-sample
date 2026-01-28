using System.Collections.Generic;
using UnityEngine;

public class BattleHand
{
    readonly List<SpellCard> _cards = new();

    public IReadOnlyList<SpellCard> Cards => _cards;

    public void Add(SpellCard card)
    {
        _cards.Add(card);
    }

    public void Remove(SpellCard card)
    {
        _cards.Remove(card);
    }

    public void Clear()
    {
        _cards.Clear();
    }
}
