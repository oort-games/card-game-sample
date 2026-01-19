using UnityEngine;

public class SpellDamageEffectHandler : ISpellEffectHandler
{
    public void Apply(SpellEffectData effect, IBattleTarget target, SpellCard card, BattleContext context)
    {
        target.TakeDamage(effect.value);
    }
}
