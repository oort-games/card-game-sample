using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class HandView : MonoBehaviour
{
    [SerializeField] BattleSpellCardView _cardViewPrefab;

    [Header("Layout")]
    [SerializeField] float _spacing = 1.2f;
    [SerializeField] float _radius = 15.0f;
    [SerializeField] float _depth = 0.01f;
    [SerializeField] float _angleStep = 5f;

    [Header("Select Effect")]
    [SerializeField] float _selectedY = 0.6f;
    [SerializeField] float _selectedZ = -1f;
    [SerializeField] float _selectedScale = 1.1f;
    [SerializeField] float _spreadOffset = 2.0f;

    readonly Dictionary<SpellCard, BattleSpellCard> _cards = new();
    BattleSpellCard _selected;

    public event Action<SpellCard> OnCardUseRequested;

    #region Card
    public void AddCard(SpellCard card)
    {
        var view = Instantiate(_cardViewPrefab, transform);

        var battleCard = new BattleSpellCard(card, view);
        battleCard.OnClicked += OnCardClicked;
        battleCard.OnEntered += OnCardEntered;
        battleCard.OnExited += OnCardExited;

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
            UpdateCardPositions();
            return;
        }
    }

    void OnCardEntered(BattleSpellCard card)
    {
        _selected = card;
        _selected.SetSelected(true);
        UpdateCardPositions();
    }

    void OnCardExited(BattleSpellCard card)
    {
        if (_selected == card)
        {
            _selected.SetSelected(false);
            _selected = null;
            UpdateCardPositions();
        }
    }

    void UpdateCardPositions()
    {
        if (_cards.Count == 0)
            return;

        var cardList = _cards.Values.ToList();
        int count = cardList.Count;

        float center = (count - 1) * 0.5f;

        int selectedIndex = -1;
        if (_selected != null)
            selectedIndex = cardList.IndexOf(_selected);

        for (int i = 0; i < count; i++)
        {
            bool isSelected = i == selectedIndex;
            float offsetFromCenter = i - center;

            float x = offsetFromCenter * _spacing;
            if (selectedIndex >= 0 && isSelected == false)
            {
                int dir = i < selectedIndex ? -1 : 1;
                x += dir * _spreadOffset;
            }

            float y = isSelected ? _selectedY : Mathf.Sqrt(Mathf.Max(0f, _radius * _radius - x * x)) - _radius;

            float z = isSelected ? _selectedZ : -_depth * i;

            float scale = isSelected ? _selectedScale : 1f;

            float angle = isSelected ? 0f : -offsetFromCenter * _angleStep;

            Transform cardTransform = cardList[i].View.transform;
            cardTransform.localPosition = new Vector3(x, y, z);
            cardTransform.localScale = scale * Vector3.one;
            cardTransform.localRotation = Quaternion.Euler(0f, 0f, angle);
        }
    }
}
