using UnityEngine;

public class SpellDamageEffectHandler : ISpellEffectHandler
{
    public void Apply(SpellEffectData effect, IBattleTarget target, BattleContext context)
    {
        target.TakeDamage(effect.value);
    }
}
