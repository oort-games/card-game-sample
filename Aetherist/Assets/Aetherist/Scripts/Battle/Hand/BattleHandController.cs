using UnityEngine;

public class BattleHandController
{
    readonly BattleContext _context;
    readonly BattleDeck _deck;
    readonly BattleHand _hand;

    public BattleHandController(BattleContext context)
    {
        _context = context;
        _deck = context.Deck;
        _hand = context.Hand;
    }

    public void Draw(uint count)
    {
        for (int i = 0; i < count; i++)
        {
            if (_hand.Cards.Count >= _context.MaxHandSize)
                break;

            var card = _deck.Draw(_hand.Cards);
            if (card == null)
                break;

            _hand.Add(card);
        }
    }

    public void UseCard(SpellCard card)
    {
        if (card == null)
            return;

        if (!card.CanPlay(_context))
            return;

        card.Play(_context);
        _context.Hand.Remove(card);
        _context.Deck.Discard(card);

        _context.PresentationQueue.Play();
    }
}
