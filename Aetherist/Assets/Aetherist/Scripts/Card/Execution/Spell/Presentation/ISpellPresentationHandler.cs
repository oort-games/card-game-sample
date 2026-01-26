using System.Collections;

public interface ISpellPresentationHandler
{
    IEnumerator Play(SpellEffectData effect, IBattleTarget target, BattleContext context);
}
