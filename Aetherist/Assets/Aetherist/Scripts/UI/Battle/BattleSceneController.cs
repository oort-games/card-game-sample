using System.Collections.Generic;
using UnityEngine;

public class BattleSceneController : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] HandCardPanel _handPanel;

    BattleContext _context;
    BattleHandController _handController;

    #region Battle Lifecycle
    public void StartBattle(BattleContext context)
    {
        _context = context;

        _handController = new BattleHandController(_context);
        _context.PresentationQueue.SetCoroutineHost(this);

        BindContext();
        BindHandUI();
        BindHandPanel();

        _handController.Draw(_context.DrawCountPerTurn);
    }
    #endregion

    #region Binds
    void BindContext()
    {
        _context.OnManaChanged += OnManaChanged;
    }

    void BindHandUI()
    {
        _context.Hand.OnCardAdded += OnCardAdded;
        _context.Hand.OnCardRemoved += OnCardRemoved;
        _context.Hand.OnChanged += OnHandChanged;
    }

    void BindHandPanel()
    {
        _handPanel.OnCardUseRequested += OnCardUseRequested;
    }
    #endregion

    #region Context Event Handlers
    void OnManaChanged()
    {
       UpdateHandPlayableState();
    }

    void UpdateHandPlayableState()
    {
        foreach (var card in _context.Hand.Cards)
        {
            _handPanel.SetPlayable(card, card.CanPlay(_context));
        }
    }
    #endregion

    #region Hand Event Handlers
    void OnCardAdded(SpellCard card)
    {
        _handPanel.AddCard(card);
        _handPanel.SetPlayable(card, card.CanPlay(_context));
    }

    void OnCardRemoved(SpellCard card)
    {
        _handPanel.RemoveCard(card);
    }

    void OnHandChanged()
    {

    }
    #endregion

    #region HandPanel Event Handlers
    void OnCardUseRequested(SpellCard card)
    {
        _handController.UseCard(card);
    }
    #endregion
}
