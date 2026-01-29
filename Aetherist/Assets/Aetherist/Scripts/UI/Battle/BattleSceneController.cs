using System.Collections.Generic;
using UnityEngine;

public class BattleSceneController : MonoBehaviour
{
    [SerializeField] BattleUIBootstrap _uiBootstrap;

    BattleContext _context;

    BattleHand _hand;
    BattleHandController _handController;

    public void StartBattle(BattleContext context, IEnumerable<SpellCard> initialDeck)
    {
        _context = context;

        var deck = new BattleDeck(initialDeck);
        _hand = new BattleHand();
        _handController = new BattleHandController(_context, deck,_hand);

        _uiBootstrap.Init(_context, _hand);

        _handController.Draw(_context.DrawCountPerTurn);

        _uiBootstrap.RefreshHand();
    }
}
