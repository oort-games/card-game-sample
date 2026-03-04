using System;
using UnityEngine;

public abstract class BattleUnit : IBattleTarget
{
    public uint MaxHp { get; private set; }
    public uint Hp { get; protected set; }

    public bool IsDead => Hp == 0;

    public event Action<BattleUnit> OnHpChanged;

    protected BattleUnit(uint hp)
    {
        MaxHp = hp;
        Hp = hp;
    }

    public virtual void TakeDamage(uint amount)
    {
        uint before = Hp;
        Hp = amount >= Hp ? 0 : Hp - amount;

        OnHpChanged?.Invoke(this);
        Debug.Log($"[Damage] {GetType().Name} | {amount} ({before} -> {Hp})");
    }

    public virtual void Heal(uint amount)
    {
        Hp += amount;

        var before = Hp;

        if (Hp >= MaxHp)
        {
            Hp = MaxHp;
        }
        else
        {
            uint remaining = MaxHp - Hp;
            Hp += amount >= remaining ? remaining : amount;
        }

        OnHpChanged?.Invoke(this);
    }
}
