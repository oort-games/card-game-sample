using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class HandView : MonoBehaviour
{
    [SerializeField] SpellCardView _cardViewPrefab;

    [Header("Layout")]
    [SerializeField] float spacing = 1.2f;
    [SerializeField] float radius = 6.0f;
    [SerializeField] float depth = 0.01f;

    readonly Dictionary<SpellCard, BattleSpellCard> _cards = new();
    BattleSpellCard _selected;

    public event Action<SpellCard> OnCardUseRequested;

    #region Card
    public void AddCard(SpellCard card)
    {
        var view = Instantiate(_cardViewPrefab, transform);

        var battleCard = new BattleSpellCard(card, view);
        battleCard.OnClicked += OnCardClicked;

        _cards.Add(card, battleCard);

        UpdateCardPositions();
    }

    public void RemoveCard(SpellCard card)
    {
        if (!_cards.TryGetValue(card, out var battleCard))
            return;

        if (_selected == battleCard)
            _selected = null;

        Destroy(battleCard.View.gameObject);
        _cards.Remove(card);

        UpdateCardPositions();
    }

    public void ClearCard()
    {
        foreach (var battleCard in _cards.Values)
            Destroy(battleCard.View.gameObject);

        _cards.Clear();
        _selected = null;
    }
    #endregion

    public void SetPlayable(SpellCard card, bool playable)
    {
        if (_cards.TryGetValue(card, out var battleCard))
        {
            battleCard.View.SetPlayable(playable);
        }
    }

    void OnCardClicked(BattleSpellCard card)
    {
        if (_selected == card)
        {
            OnCardUseRequested?.Invoke(card.Card);
            return;
        }

        _selected?.SetSelected(false);
        _selected = card;
        _selected.SetSelected(true);
    }

    void UpdateCardPositions()
    {
        if (_cards.Count == 0)
            return;

        var cardList = _cards.Values.ToList();
        int count = cardList.Count;

        float center = (count - 1) * 0.5f;

        for (int i = 0; i < count; i++)
        {
            float x = (i - center) * spacing;

            float y = Mathf.Sqrt(Mathf.Max(0f, radius * radius - x * x)) - radius;

            Vector3 localPos = new Vector3(x, y, -depth * i);
            cardList[i].View.transform.localPosition = localPos;
        }
    }
}
