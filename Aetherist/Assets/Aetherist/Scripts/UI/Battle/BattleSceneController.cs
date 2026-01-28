using UnityEngine;

public class BattleSceneController : MonoBehaviour
{
    [SerializeField] BattleUIBootstrap _uiBootstrap;

    BattleContext _context;

    BattleHand _hand;
    BattleHandController _handController;

    public void StartBattle(BattleContext context)
    {
        _context = context;

        _hand = new BattleHand();
        _handController = new BattleHandController(_context, _hand);

        _uiBootstrap.Init(_context, _hand);

        _handController.Draw(_context.DrawCountPerTurn);
    }
}
