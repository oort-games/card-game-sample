using UnityEngine;

public class BattleSpellCard
{
    public SpellCard Card { get; }
    public SpellCardView View { get; }

    public bool IsSelected { get; private set; }

    public BattleSpellCard(SpellCard card, SpellCardView view)
    {
        Card = card;
        View = view;

        View.Bind(card.Data);
    }

    public void Select()
    {
        IsSelected = true;
        View.SetSelected(true);
    }

    public void Deselect()
    {
        IsSelected = false;
        View.SetSelected(false);
    }
}
