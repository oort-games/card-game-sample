using System.Collections;
using UnityEngine;

public class SpellDamagePresentation : ISpellPresentationHandler
{
    public IEnumerator Play(SpellEffectData effect, IBattleTarget target, BattleContext context)
    {
        yield return new WaitForSeconds(0.25f);
        SpellEffectProcessor.Apply(effect, target, context);
    }
}
