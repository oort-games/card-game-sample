using System;
using UnityEngine;

public class BattleSpellCard
{
    public SpellCard Card { get; }
    public BattleSpellCardView View { get; }

    public bool IsSelected { get; private set; }

    public event Action<BattleSpellCard> OnClicked;
    public event Action<BattleSpellCard> OnEntered;
    public event Action<BattleSpellCard> OnExited;

    public BattleSpellCard(SpellCard card, BattleSpellCardView view)
    {
        Card = card;
        View = view;

        View.Bind(card.Data);
        View.Input.OnClick += () => OnClicked?.Invoke(this);
        View.Input.OnEnter += () => OnEntered?.Invoke(this);
        View.Input.OnExit += () => OnExited?.Invoke(this);

        View.Input.OnEnter += () => View.Collider.size = new Vector2(3.5f, 4.75f);
        View.Input.OnExit += () => View.Collider.size = new Vector2(3.2f, 4.5f);
    }

    public void SetSelected(bool selected)
    {
        IsSelected = selected;
        View.SetSelected(selected);
    }
}