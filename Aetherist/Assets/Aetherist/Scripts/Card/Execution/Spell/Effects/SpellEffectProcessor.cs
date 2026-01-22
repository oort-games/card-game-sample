using System.Collections.Generic;
using UnityEngine;

public static class SpellEffectProcessor
{
    static readonly Dictionary<SpellEffectType, ISpellEffectHandler> _handlers = new()
    {
        { SpellEffectType.Damage, new SpellDamageEffectHandler() },
        { SpellEffectType.Draw, new SpellDrawEffectHandler() },
        { SpellEffectType.Heal, new SpellDrawEffectHandler() },
    };

    public static void Apply(SpellEffectData effect, IBattleTarget target, SpellCard spell, BattleContext context)
    {
        if (_handlers.TryGetValue(effect.effectType, out var handler))
        {
            handler.Apply(effect, target, spell, context);
        }
        else
        {
            Debug.LogWarning($"[SpellEffectType] Unhandled type: {effect.effectType}");
        }
    }
}
