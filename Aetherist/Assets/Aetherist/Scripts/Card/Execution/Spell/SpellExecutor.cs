using System.Collections.Generic;
using UnityEngine;

public class SpellExecutor
{
    readonly Dictionary<SpellActionType, ISpellAction> _actions;

    public SpellExecutor()
    {
        _actions = new()
        {
            { SpellActionType.Attack, new SpellAttackAction() }
        };
    }

    public void Excute(SpellCard spell, BattleContext context)
    {
        if (_actions.TryGetValue(spell.Data.actionType, out var action))
        {
            context.RelicExecutor.Trigger(RelicTriggerType.OnSpellUsed, context, spell);
            action.Excute(spell, context);
            context.RelicExecutor.Trigger(RelicTriggerType.OnSpellResolved, context, spell);
        }
        else
        {
            Debug.LogWarning($"[Spell ActionType] Unhandled type: {spell.Data.actionType}");
        }
    }
}
