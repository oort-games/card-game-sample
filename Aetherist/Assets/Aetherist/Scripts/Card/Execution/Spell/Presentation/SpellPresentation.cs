using System.Collections;

public class SpellPresentation : IBattlePresentation
{
    readonly SpellEffectData _effect;
    readonly IBattleTarget _target;
    readonly BattleContext _context;

    public SpellPresentation(SpellEffectData effect, IBattleTarget target, BattleContext context)
    {
        _effect = effect;
        _target = target;
        _context = context;
    }

    public IEnumerator Play()
    {
        var presenter = SpellPresentationRegistry.Resolve(_effect.effectType);
        if (presenter != null)
        {
            yield return presenter.Play(_effect, _target,_context);
        }
        else
        {
            SpellEffectProcessor.Apply(_effect, _target, _context);
        }
    }
}
