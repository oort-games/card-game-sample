using System.Collections;

public class RelicPresentation : IBattlePresentation
{
    readonly RelicEffectData _effect;
    readonly RelicTriggerContext _context;

    public RelicPresentation(RelicEffectData effect, RelicTriggerContext context)
    {
        _effect = effect;
        _context = context;
    }

    public IEnumerator Play()
    {
        var presenter = RelicPresentationRegistry.Resolve(_effect.effectType);
        if (presenter != null)
        {
            yield return presenter.Play(_effect, _context);
        }
        else
        {
            RelicEffectProcessor.Apply(_effect, _context);
        }
    }
}
