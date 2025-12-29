using UnityEngine;

public class SpellHealEffectHandler : ISpellEffectHandler
{
    public void Apply(SpellEffectData effect, SpellCard card, BattleContext context)
    {
        var targets = context.TargetResolver.Resolve(card.Data.target, context);

        foreach (var target in targets)
        {
            target.Heal(effect.value);
        }
    }
}
