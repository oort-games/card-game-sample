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
    public PlayerTarget Player { get; private set; }

    readonly List<EnemyTarget> _enemies = new();
    public IReadOnlyList<EnemyTarget> Enemies => _enemies;

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
    public BattleSceneController SceneController { get; private set; }
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
    public void SetupBattle(PlayerTarget player, IReadOnlyList<EnemyTarget> enemies,
        uint mana, uint maxHandSize, uint drawCountPerTurn)
    {
        Player = player;
        _enemies.Clear();
        _enemies.AddRange(enemies);

        Mana = mana;
        MaxMana = mana;

        MaxHandSize = maxHandSize;
        DrawCountPerTurn = drawCountPerTurn;
    }

    public void SetupCard(BattleDeck deck, BattleHand hand)
    {
        Deck = deck;
        Hand = hand;
    }

    public void SetupScene(BattleSceneController sceneController)
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
        Mana -= amount;
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

        Debug.Log($"[Mana] Add | {amount} ({before} -> {Mana})");
    }

    public void IncreaseMaxMana(uint amount)
    {
        var beforeMax = MaxMana;

        if (uint.MaxValue - MaxMana < amount)
            MaxMana = uint.MaxValue;
        else
            MaxMana += amount;

        Debug.Log($"[Mana] Max Increase | {amount} ({beforeMax} -> {MaxMana})");
    }
    #endregion

    public void DrawCards(uint count)
    {

    }

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

    public void RemoveEnemy(EnemyTarget enemy)
    {
        _enemies.Remove(enemy);
    }
}