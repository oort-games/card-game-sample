using System;
using System.Collections.Generic;
using UnityEngine;

public class BattleContext
{
    #region System
    public BattlePresentationQueue PresentationQueue { get; }

    public SpellExecutor SpellExecutor { get; }
    public RelicExecutor RelicExecutor { get; }
    public ArcanaExecutor ArcanaExecutor { get; }

    public ITargetResolver TargetResolver { get; }
    #endregion

    #region Runtime State
    public PlayerUnit Player { get; private set; }

    readonly List<EnemyUnit> _enemies = new();
    public IReadOnlyList<EnemyUnit> Enemies => _enemies;

    public BattleTurnState TurnState { get; private set; }

    public uint Mana { get; private set; }

    public BattleDeck Deck { get; private set; }
    public BattleHand Hand { get; private set; }
    #endregion

    #region Rules
    public uint MaxMana { get; private set; }
    public uint ManaGainPerTurn { get; private set; }

    public uint MaxHandSize { get; private set; }
    public uint DrawCountPerTurn { get; private set; }
    #endregion

    #region Scene
    public BattleViewController SceneController { get; private set; }
    #endregion

    #region Event
    public event Action OnManaChanged;
    public event Action OnCardDrawn;
    #endregion

    public BattleContext(SpellExecutor spellExecutor, RelicExecutor relicExecutor, ArcanaExecutor arcanaExecutor,
        BattlePresentationQueue presentationQueue,
        ITargetResolver targetResolver)
    {
        SpellExecutor = spellExecutor;
        RelicExecutor = relicExecutor;
        ArcanaExecutor = arcanaExecutor;
        PresentationQueue = presentationQueue;
        TargetResolver = targetResolver;
    }

    #region Setup
    public void SetupBattle(uint mana, uint maxHandSize, uint drawCountPerTurn)
    {
        Mana = mana;
        MaxMana = mana;

        MaxHandSize = maxHandSize;
        DrawCountPerTurn = drawCountPerTurn;
    }

    public void SetupPlayer(PlayerUnit player)
    {
        Player = player;
    }

    public void SetupEnemy(IReadOnlyList<EnemyUnit> enemies)
    {
        _enemies.Clear();
        _enemies.AddRange(enemies);
    }

    public void SetupCard(BattleDeck deck, BattleHand hand)
    {
        Deck = deck;
        Hand = hand;
    }

    public void SetupScene(BattleViewController sceneController)
    {
        SceneController = sceneController;
    }
    #endregion

    #region Mana
    public bool CanUseMana(uint amount)
    {
        return Mana >= amount;
    }

    public void UseMana(uint amount)
    {
        var before = Mana;
        Mana = amount >= Mana ? 0 : Mana - amount;

        OnManaChanged?.Invoke();
        Debug.Log($"[Mana] Use | {amount} ({before} -> {Mana})");
    }

    public void AddMana(uint amount)
    {
        var before = Mana;

        if (Mana >= MaxMana)
        {
            Mana = MaxMana;
        }
        else
        {
            uint remaining = MaxMana - Mana;
            Mana += amount >= remaining ? remaining : amount;
        }
        OnManaChanged?.Invoke();
        Debug.Log($"[Mana] Add | {amount} ({before} -> {Mana})");
    }

    public void IncreaseMaxMana(uint amount)
    {
        var beforeMax = MaxMana;

        if (uint.MaxValue - MaxMana < amount)
            MaxMana = uint.MaxValue;
        else
            MaxMana += amount;

        OnManaChanged?.Invoke();
        Debug.Log($"[Mana] Max Increase | {amount} ({beforeMax} -> {MaxMana})");
    }
    #endregion

    #region Card
    public void DrawCards(uint count)
    {
        for (int i = 0; i < count; i++)
        {
            if (Hand.Cards.Count >= MaxHandSize)
                break;

            var card = Deck.Draw(Hand.Cards);
            if (card == null)
                break;

            Hand.Add(card);
        }
        OnCardDrawn?.Invoke();
    }

    public void UseCard(SpellCard card)
    {
        if (card == null)
            return;

        if (!card.CanPlay(this))
            return;

        card.Play(this);
        Hand.Remove(card);
        Deck.Discard(card);
    }
    #endregion

    public void CleanupDeadEnemies()
    {
        for (int i = 0; i < _enemies.Count; i++)
        {
            if (_enemies[i].IsDead)
            {
                _enemies.RemoveAt(i);
            }
        }
    }

    public void RemoveEnemy(EnemyUnit enemy)
    {
        _enemies.Remove(enemy);
    }
}