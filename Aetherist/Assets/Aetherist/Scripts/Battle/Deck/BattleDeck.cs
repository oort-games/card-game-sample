using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BattleDeck
{
    readonly List<SpellCard> _drawCards = new();
    readonly List<SpellCard> _discardCards = new();

    public int DrawCount => _drawCards.Count;
    public int DiscardCount => _discardCards.Count;

    public BattleDeck(IEnumerable<SpellCard> initialCards)
    {
        _drawCards.AddRange(initialCards);
        Shuffle();
    }

    public SpellCard Draw(IReadOnlyCollection<SpellCard> handCards)
    {
        if (_drawCards.Count == 0)
            ReshuffleDiscardToDraw(handCards);

        if (_drawCards.Count == 0)
            return null;

        int last = _drawCards.Count - 1;
        var card = _drawCards[last];
        _drawCards.RemoveAt(last);
        return card;
    }

    public void Discard(SpellCard card)
    {
        _discardCards.Add(card);
    }

    void ReshuffleDiscardToDraw(IReadOnlyCollection<SpellCard> handCards)
    {
        if (_discardCards.Count == 0)
            return;

        for (int i = _discardCards.Count - 1; i >= 0; i--)
        {
            var card = _discardCards[i];

            if (handCards.Contains(card))
                continue;

            _drawCards.Add(card);
            _discardCards.RemoveAt(i);
        }

        Shuffle();
    }

    void Shuffle()
    {
        for (int i = _drawCards.Count - 1; i > 0; i--)
        {
            int j = Random.Range(0, i + 1);
            (_drawCards[i], _drawCards[j]) = (_drawCards[j], _drawCards[i]);
        }
    }
}
