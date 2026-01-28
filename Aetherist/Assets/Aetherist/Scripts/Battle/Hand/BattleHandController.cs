using UnityEngine;

public class BattleHandController
{
    readonly BattleContext _context;
    readonly BattleHand _hand;

    public BattleHandController(BattleContext context, BattleHand hand)
    {
        _context = context;
        _hand = hand;
    }

    public void Draw(uint count)
    {

    }
}
