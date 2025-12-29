using UnityEngine;

public class EnemyTarget : IBattleTarget
{
    uint _hp;

    public EnemyTarget(uint startHp)
    {
        _hp = startHp;
    }

    public void TakeDamage(uint amount)
    {
        uint before = _hp;
        _hp = amount >= _hp ? 0 : _hp - amount;

        Debug.Log($"HP {before} -> {_hp} (damage {amount})");
    }

    public void Heal(uint amount)
    {
        _hp += amount;
    }
}
