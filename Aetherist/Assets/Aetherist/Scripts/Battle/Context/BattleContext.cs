using UnityEngine;

public class BattleContext
{
    public uint Mana { get; set; }

    public SpellExecutor SpellExecutor { get; }
    public RelicExecutor RelicExecutor { get; }

    public void UseMana(uint amount)
    {
        Mana -= amount;
    }

    public void DarwCards(int count)
    {

    }
}