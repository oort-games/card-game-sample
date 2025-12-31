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
        => Apply(effect, card, context, card.Data.target);

    public static void Apply(SpellEffectData effect, SpellCard card, BattleContext context, CardTarget target)
    {
        if (_handlers.TryGetValue(effect.effectType, out var handler))
        {
            handler.Apply(effect, card, context, target);
        }
        else
        {
            Debug.LogError($"Unhandled SpellEffectType: {effect.effectType}");
        }
    }
}
