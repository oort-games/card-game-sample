using UnityEngine;

public class SpellHealEffectHandler : ISpellEffectHandler
{
    public void Apply(SpellEffectData effect, SpellCard card, BattleContext context, CardTarget target)
    {
        var targets = context.TargetResolver.Resolve(target, context);

        foreach (var target in targets)
        {
            target.Heal(effect.value);
        }
    }
}
