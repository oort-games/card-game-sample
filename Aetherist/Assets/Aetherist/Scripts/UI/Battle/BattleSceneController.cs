using System.Collections.Generic;
using UnityEngine;

public class BattleSceneController : MonoBehaviour
{
    [SerializeField] BattleUIBootstrap _uiBootstrap;

    BattleContext _context;

    BattleHandController _handController;

    public void StartBattle(BattleContext context)
    {
        _context = context;
        _handController = new BattleHandController(_context);

        _uiBootstrap.Init(_context);

        _handController.Draw(_context.DrawCountPerTurn);

        _uiBootstrap.RefreshHand();
    }
}
