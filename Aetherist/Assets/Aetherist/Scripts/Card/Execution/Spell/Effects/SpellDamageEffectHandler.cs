using UnityEngine;

public class SpellDamageEffectHandler : ISpellEffectHandler
{
    public void Apply(SpellEffectData effect, SpellCard card, BattleContext context, CardTarget target)
    {
        var targets = context.TargetResolver.Resolve(target, context);

        foreach (var target in targets)
        {
            target.TakeDamage(effect.value);
        }

        context.CleanupDeadEnemies();
    }
}
