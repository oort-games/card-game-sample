using System.Collections.Generic;
using UnityEngine;

public static class SpellEffectProcessor
{
    private static readonly Dictionary<SpellEffectType, ISpellEffectHandler> _handlers = new()
    {
        { SpellEffectType.Damage, new SpellDamageEffectHandler() },
        { SpellEffectType.Draw, new SpellDrawEffectHandler() },
    };

    public static void Apply(SpellEffectData effect, SpellCard card, BattleContext context)
    {
        if (_handlers.TryGetValue(effect.effectType, out var handler))
        {
            handler.Apply(effect, card, context);
        }
        else
        {
            Debug.LogError($"Unhandled SpellEffectType: {effect.effectType}");
        }
    }
}
