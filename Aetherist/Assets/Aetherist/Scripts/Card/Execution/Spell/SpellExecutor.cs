using System.Collections.Generic;
using UnityEngine;

public class SpellExecutor
{
    private readonly Dictionary<SpellActionType, ISpellAction> _actions;

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
            action.Excute(card, context);
        }
        else
        {
            Debug.LogError($"Unhandled SpellActionType: {card.Data.actionType}");
        }
    }
}
