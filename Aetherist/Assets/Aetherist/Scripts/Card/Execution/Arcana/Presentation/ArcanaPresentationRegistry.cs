using System.Collections.Generic;
using UnityEngine;

public static class ArcanaPresentationRegistry
{
    static readonly Dictionary<ArcanaEffectType, IArcanaPresentationHandler> _handlers = new()
    {
        { ArcanaEffectType.IncreaseMaxMana, new ArcanaIncreaseMaxManaPresentation() },
    };

    public static IArcanaPresentationHandler Resolve(ArcanaEffectType type)
    {
        if (_handlers.TryGetValue(type, out var handler))
        {
            return handler;
        }

        Debug.LogWarning($"[Arcana Presentation] Unhandled type: {type}");
        return null;
    }
}
