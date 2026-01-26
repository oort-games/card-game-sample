using System.Collections.Generic;
using UnityEngine;

public class SpellPresentationRegistry : MonoBehaviour
{
    static readonly Dictionary<SpellEffectType, ISpellPresentationHandler> _handlers = new()
    {
        { SpellEffectType.Damage, new SpellDamagePresentation() },
    };

    public static ISpellPresentationHandler Resolve(SpellEffectType type)
    {
        if (_handlers.TryGetValue(type, out var handler))
        {
            return handler;
        }

        Debug.LogWarning($"[SpellPresentation] Unhandled type: {type}");
        return null;
    }
}
