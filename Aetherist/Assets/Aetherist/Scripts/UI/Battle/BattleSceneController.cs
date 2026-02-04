using System.Collections.Generic;
using UnityEngine;

public class BattleSceneController : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] HandCardPanel _handPanel;

    BattleContext _context;
    BattleHandController _handController;

    public void StartBattle(BattleContext context)
    {
        _context = context;
        _handController = new BattleHandController(_context);

        BindHandUI();

        _handController.Draw(_context.DrawCountPerTurn);
    }

    void BindHandUI()
    {
        _context.Hand.OnCardAdded += _handPanel.AddCard;
        _context.Hand.OnCardRemoved -= _handPanel.RemoveCard;
        _context.Hand.OnChanged += () => { };
    }
}
