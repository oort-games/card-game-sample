using System.Collections.Generic;
using UnityEngine;

public class RelicExecutor
{
    List<RelicCard> _relics;

    public RelicExecutor()
    {
        _relics = new();
    }

    public void AddRelic(RelicCard relic)
    {
        _relics.Add(relic);
    }

    public void Trigger(RelicTriggerType triggerType, BattleContext context, SpellCard card = null)
    {
        Trigger(new RelicTriggerContext(triggerType, context, card));
    }

    void Trigger(RelicTriggerContext context)
    {
        foreach (var relic in _relics)
        {
            if (relic.Data.triggerType != context.TriggerType)
                continue;

            if (!RelicConditionEvaluator.CheckAll(relic.Data.conditions, context))
                continue;

            Excute(relic, context);
        }
    }

    void Excute(RelicCard relic, RelicTriggerContext context)
    {
        Debug.Log($"[Relic] Excute | {relic.Data.displayName} ({relic.Data.triggerType})");
        RelicEffectProcessor.Apply(relic, context);
    }
}
