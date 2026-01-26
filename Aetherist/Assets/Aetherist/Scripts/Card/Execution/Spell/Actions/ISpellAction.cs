using System.Collections.Generic;
using UnityEngine;

public interface ISpellAction
{
    void Excute(SpellCard spell, BattleContext context);
}
