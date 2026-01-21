using UnityEngine;

public interface ISpellAction
{
    void Excute(SpellCard spell, BattleContext context);
}
