using UnityEngine;

public class SpellHealEffectHandler : ISpellEffectHandler
{
    public void Apply(SpellEffectData effect, IBattleTarget target, SpellCard spell, BattleContext context)
    {
        target.Heal(effect.value);
    }
}
