using System.Collections.Generic;
using UnityEngine;

public class BattleContext
{
    public SpellExecutor SpellExecutor { get; }
    public RelicExecutor RelicExecutor { get; }
    public ITargetResolver TargetResolver { get; }

    public uint Mana { get; private set; }
    public PlayerTarget Player { get; private set; }
    
    List<EnemyTarget> _enemies = new();
    public IReadOnlyList<EnemyTarget> Enemies => _enemies;

    public BattleContext(SpellExecutor spellExecutor, RelicExecutor relicExecutor, ITargetResolver targetResolver)
    {
        SpellExecutor = spellExecutor;
        RelicExecutor = relicExecutor;
        TargetResolver = targetResolver;
    }

    public void SetupBattle(uint startMana, PlayerTarget player, IReadOnlyList<EnemyTarget> enemies)
    {
        Mana = startMana;
        Player = player;

        _enemies.Clear();
        _enemies.AddRange(enemies);
    }

    #region Mana
    public void UseMana(uint amount)
    {
        var before = Mana;
        Mana -= amount;
        Debug.Log($"[Mana] Use | {amount} ({before} -> {Mana})");
    }

    public void AddMana(uint amount)
    {
        var before = Mana;
        Mana += amount;
        Debug.Log($"[Mana] Add | {amount} ({before} -> {Mana})");
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