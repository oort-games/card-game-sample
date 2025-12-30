using UnityEngine;

public class EnemyTarget : IBattleTarget
{
    uint _hp;
    public uint Hp => _hp;
    public bool IsDead => _hp == 0;

    public EnemyTarget(uint startHp)
    {
        _hp = startHp;
    }

    public void TakeDamage(uint amount)
    {
        uint before = _hp;
        _hp = amount >= _hp ? 0 : _hp - amount;

        Debug.Log($"[Damage] Enemy | {amount} ({before} -> {_hp})");
    }

    public void Heal(uint amount)
    {
        _hp += amount;
    }
}
