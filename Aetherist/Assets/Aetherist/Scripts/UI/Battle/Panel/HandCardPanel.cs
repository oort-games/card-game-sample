using System;
using System.Collections.Generic;
using UnityEngine;

public class HandCardPanel : MonoBehaviour
{
    [SerializeField] SpellCardView _cardViewPrefab;
    [SerializeField] Transform _cardRoot;

    readonly Dictionary<SpellCard, BattleSpellCard> _handCards = new();
    BattleSpellCard _selected;

    public void AddCard(SpellCard card)
    {
        var view = Instantiate(_cardViewPrefab, _cardRoot);
        var battleCard = new BattleSpellCard(card, view);
        battleCard.OnClicked += OnCardClicked;

        _handCards.Add(card, battleCard);        
    }

    public void RemoveCard(SpellCard card)
    {
        if (!_handCards.TryGetValue(card, out var battleCard))
            return;

        if (_selected == battleCard)
            _selected = null;

        Destroy(battleCard.View.gameObject);
        _handCards.Remove(card);
    }

    public void ClearHand()
    {
        foreach (var battleCard in _handCards.Values)
            Destroy(battleCard.View.gameObject);

        _handCards.Clear();
        _selected = null;
    }

    void OnCardClicked(BattleSpellCard card)
    {
        _selected?.SetSelected(false);
        _selected = card;
        _selected.SetSelected(true);
    }
}