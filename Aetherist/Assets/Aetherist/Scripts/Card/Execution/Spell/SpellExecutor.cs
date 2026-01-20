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

    public void Excute(SpellCard card, BattleContext context)
    {
        if (_actions.TryGetValue(card.Data.actionType, out var action))
        {
            context.RelicExecutor.Trigger(RelicTriggerType.OnSpellUsed, context, card);
            action.Excute(card, context);
            context.RelicExecutor.Trigger(RelicTriggerType.OnSpellResolved, context, card);
        }
        else
        {
            Debug.LogError($"Unhandled SpellActionType: {card.Data.actionType}");
        }
    }
}
