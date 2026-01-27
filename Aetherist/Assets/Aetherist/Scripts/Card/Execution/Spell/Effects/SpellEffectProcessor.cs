using System.Collections.Generic;
using UnityEngine;

public static class SpellEffectProcessor
{
    static readonly Dictionary<SpellEffectType, ISpellEffectHandler> _handlers = new()
    {
        { SpellEffectType.Damage, new SpellDamageEffectHandler() },
        { SpellEffectType.Draw, new SpellDrawEffectHandler() },
        { SpellEffectType.Heal, new SpellHealEffectHandler() },
    };

    public static void Apply(SpellEffectData effect, IBattleTarget target, BattleContext context)
    {
        if (_handlers.TryGetValue(effect.effectType, out var handler))
        {
            handler.Apply(effect, target, context);
        }
        else
        {
            Debug.LogWarning($"[Spell EffectType] Unhandled type: {effect.effectType}");
        }
    }
}
