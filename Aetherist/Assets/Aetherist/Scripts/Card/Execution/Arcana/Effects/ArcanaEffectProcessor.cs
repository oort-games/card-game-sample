using System.Collections.Generic;
using UnityEngine;

public static class ArcanaEffectProcessor
{
    static readonly Dictionary<ArcanaEffectType, IArcanaEffectHandler> _handlers = new()
    {
        { ArcanaEffectType.IncreaseMaxMana, new ArcanaIncreaseMaxManaHandler() },
    };

    public static void Apply(ArcanaEffectData effect, BattleContext context)
    {
        if (_handlers.TryGetValue(effect.effectType, out var handler))
        {
            handler.Apply(effect, context);
            return;
        }

        Debug.LogError($"Unhandled ArcanaEffectType: {effect.effectType}");
    }
}
