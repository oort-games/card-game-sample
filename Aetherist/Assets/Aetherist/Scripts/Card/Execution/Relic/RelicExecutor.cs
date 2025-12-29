using System.Collections.Generic;
using UnityEngine;

public class RelicExecutor
{
    List<RelicCard> _relics;

    public RelicExecutor()
    {
        _relics = new();
    }

    public void Trigger(RelicTriggerContext context)
    {
        foreach (var relic in _relics)
        {
            if (relic.Data.triggerType == context.TriggerType)
            {
                Excute(relic, context);
            }
        }
    }

    void Excute(RelicCard relic, RelicTriggerContext context)
    {
        RelicEffectProcessor.Apply(relic, context);
    }
}
