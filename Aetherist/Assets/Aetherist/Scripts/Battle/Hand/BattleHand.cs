using System;
using System.Collections.Generic;
using UnityEngine;

public class BattleHand
{
    readonly List<SpellCard> _cards = new();

    public IReadOnlyList<SpellCard> Cards => _cards;

    public event Action<SpellCard> OnCardAdded;
    public event Action<SpellCard> OnCardRemoved;
    public event Action OnChanged;

    public void Add(SpellCard card)
    {
        _cards.Add(card);
        OnCardAdded?.Invoke(card);
        OnChanged?.Invoke();
    }

    public void Remove(SpellCard card)
    {
        if (_cards.Remove(card))
        {
            OnCardRemoved?.Invoke(card);
            OnChanged?.Invoke();
        }
    }

    public void Clear()
    {
        if (_cards.Count == 0)
            return;

        _cards.Clear();
        OnChanged?.Invoke();
    }
}
