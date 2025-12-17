using UnityEngine;

public interface ISpellAction
{
    void Excute(SpellCard card, BattleContext context);
}
