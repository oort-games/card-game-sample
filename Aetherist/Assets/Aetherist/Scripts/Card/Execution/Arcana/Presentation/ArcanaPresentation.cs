using System.Collections;
using UnityEngine;

public class ArcanaPresentation : IBattlePresentation
{
    readonly ArcanaEffectData _effect;
    readonly BattleContext _context;

    public ArcanaPresentation(ArcanaEffectData effect, BattleContext context)
    {
        _effect = effect;
        _context = context;
    }

    public IEnumerator Play()
    {
        var presenter = ArcanaPresentationRegistry.Resolve(_effect.effectType);
        if (presenter != null)
        {
            yield return presenter.Play(_effect, _context);
        }

        ArcanaEffectProcessor.Apply(_effect, _context);
    }
}
