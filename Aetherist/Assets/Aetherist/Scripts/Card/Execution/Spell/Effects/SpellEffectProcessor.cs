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

    public static void Apply(SpellEffectData effect, IBattleTarget target, SpellCard card, BattleContext context)
    {
        if (_handlers.TryGetValue(effect.effectType, out var handler))
        {
            handler.Apply(effect, target, card, context);
        }
        else
        {
            Debug.LogError($"Unhandled SpellEffectType: {effect.effectType}");
        }
    }
}
