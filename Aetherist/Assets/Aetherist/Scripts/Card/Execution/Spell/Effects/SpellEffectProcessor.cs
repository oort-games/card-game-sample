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

    public static void Apply(SpellEffectData effect, SpellCard card, BattleContext context)
    {
        if (_handlers.TryGetValue(effect.effectType, out var handler))
        {
            Debug.Log($"Apply SpellEffect: {card.Data.displayName} - {effect.effectType}");
            handler.Apply(effect, card, context);
        }
        else
        {
            Debug.LogError($"Unhandled SpellEffectType: {effect.effectType}");
        }
    }
}
