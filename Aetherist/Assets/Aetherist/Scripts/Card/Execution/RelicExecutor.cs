using System.Collections.Generic;
using UnityEngine;

public class RelicExecutor
{
    private readonly List<RelicCard> _relics;

    public RelicExecutor(List<RelicCard> relics)
    {
        _relics = relics;
    }

    public void Trigger(RelicTriggerType trigger, BattleContext context)
    {
        foreach (var relic in _relics)
        {
            if (relic.Data.triggerType == trigger)
            {
                Excute(relic, context);
            }
        }
    }

    private void Excute(RelicCard card, BattleContext context)
    {

    }
}
