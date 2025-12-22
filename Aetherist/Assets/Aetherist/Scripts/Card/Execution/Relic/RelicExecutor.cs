using System.Collections.Generic;
using UnityEngine;

public class RelicExecutor
{
    private readonly List<RelicCard> _relics;

    public RelicExecutor(List<RelicCard> relics)
    {
        _relics = relics;
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

    private void Excute(RelicCard relic, RelicTriggerContext context)
    {

    }
}
