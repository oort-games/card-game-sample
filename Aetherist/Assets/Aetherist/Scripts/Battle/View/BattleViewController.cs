using System.Collections.Generic;
using UnityEngine;

public class BattleViewController : MonoBehaviour
{
    [Header("View")]
    [SerializeField] HandView _handView;
    [SerializeField] ManaView _manaView;

    BattleContext _context;

    #region Battle Lifecycle
    public void StartBattle(BattleContext context)
    {
        _context = context;

        _context.PresentationQueue.SetCoroutineHost(this);

        BindContext();
        BindHandUI();
        BindHandPanel();

        _manaView.SetMana(_context.Mana);
        _context.DrawCards(_context.DrawCountPerTurn);
    }
    #endregion

    #region Binds
    void BindContext()
    {
        _context.OnManaChanged += OnManaChanged;
        _context.OnCardDrawn += OnCardDrawn;
    }

    void BindHandUI()
    {
        _context.Hand.OnCardAdded += OnCardAdded;
        _context.Hand.OnCardRemoved += OnCardRemoved;
        _context.Hand.OnChanged += OnHandChanged;
    }

    void BindHandPanel()
    {
        _handView.OnCardUseRequested += OnCardUseRequested;
    }
    #endregion

    #region Context Event Handlers
    void OnManaChanged()
    {
        UpdateHandPlayableState();
        _manaView.SetMana(_context.Mana);
    }

    void UpdateHandPlayableState()
    {
        foreach (var card in _context.Hand.Cards)
        {
            _handView.SetPlayable(card, card.CanPlay(_context));
        }
    }

    void OnCardDrawn()
    {
        _context.PresentationQueue.Play();
    }
    #endregion

    #region Hand Event Handlers
    void OnCardAdded(SpellCard card)
    {
        _handView.AddCard(card);
        _handView.SetPlayable(card, card.CanPlay(_context));
    }

    void OnCardRemoved(SpellCard card)
    {
        _handView.RemoveCard(card);
    }

    void OnHandChanged()
    {

    }
    #endregion

    #region HandPanel Event Handlers
    void OnCardUseRequested(SpellCard card)
    {
        _context.UseCard(card);
        _context.PresentationQueue.Play();
    }
    #endregion
}
