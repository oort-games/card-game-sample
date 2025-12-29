using System.Collections.Generic;
using UnityEngine;

public static class RelicEffectProcessor
{
    static readonly Dictionary<RelicEffectType, IRelicEffectHandler> _handlers = new()
    {
        { RelicEffectType.GainShield, new RelicGainShieldEffectHandler() },
        { RelicEffectType.ModifySpellCost, new RelicModifySpellCostEffectHandler() },
    };

    public static void Apply(RelicCard relic, RelicTriggerContext context)
    {
        foreach (var effect in relic.Data.effects)
        {
            if (_handlers.TryGetValue(effect.effectType, out var handler))
            {
                handler.Apply(effect, relic, context);
            }
            else
            {
                Debug.LogError($"Unhandled RelicEffectType: {effect.effectType}");
            }
        }
    }
}
