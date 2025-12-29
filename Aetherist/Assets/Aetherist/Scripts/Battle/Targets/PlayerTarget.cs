using UnityEngine;

public class PlayerTarget : IBattleTarget
{
    uint _hp;

    public PlayerTarget(uint startHp)
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
