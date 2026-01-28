using System;
using System.Collections.Generic;
using UnityEngine;

public class HandCardPanel : MonoBehaviour
{
    [SerializeField] SpellCardView _cardViewPrefab;
    [SerializeField] Transform _cardRoot;

    readonly List<BattleSpellCard> _handCards = new();

    public void SetHand(IEnumerable<SpellCard> cards)
    {
        ClearHand();

        foreach (var card in cards)
        {
            AddCard(card);
        }
    }

    void AddCard(SpellCard card)
    {
        var view = Instantiate(_cardViewPrefab, _cardRoot);
        var battleCard = new BattleSpellCard(card, view);

        _handCards.Add(battleCard);
    }

    public void RemoveCard(SpellCard card)
    {
        var target = _handCards.Find(c => c.Card == card);
        if (target == null)
            return;

        Destroy(target.View.gameObject);
        _handCards.Remove(target);
    }

    void ClearHand()
    {
        foreach (Transform child in _cardRoot)
            Destroy(child.gameObject);

        _handCards.Clear();
    }
}
