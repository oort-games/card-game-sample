using System.Collections.Generic;
using UnityEngine;

public class RelicPresentationRegistry : MonoBehaviour
{
    static readonly Dictionary<RelicEffectType, IRelicPresentationHandler> _handlers = new()
    {
    };

    public static IRelicPresentationHandler Resolve(RelicEffectType type)
    {
        if (_handlers.TryGetValue(type, out var handler))
        {
            return handler;
        }

        Debug.LogWarning($"[Relic Presentation] Unhandled type: {type}");
        return null;
    }
}
