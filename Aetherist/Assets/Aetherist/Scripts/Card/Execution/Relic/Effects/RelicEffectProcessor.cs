using System.Collections.Generic;
using UnityEngine;

public static class RelicEffectProcessor
{
    static readonly Dictionary<RelicEffectType, IRelicEffectHandler> _handlers = new()
    {
        { RelicEffectType.GainMana, new RelicGainManaEffectHandler() },
        { RelicEffectType.GainShield, new RelicGainShieldEffectHandler() },
        { RelicEffectType.ModifySpellCost, new RelicModifySpellCostEffectHandler() },
    };

    public static void Apply(RelicEffectData effect, RelicTriggerContext context)
    {
        if (_handlers.TryGetValue(effect.effectType, out var handler))
        {
            handler.Apply(effect, context);
        }
        else
        {
            Debug.LogWarning($"[Relic EffectType] Unhandled type: {effect.effectType}");
        }
    }
}
