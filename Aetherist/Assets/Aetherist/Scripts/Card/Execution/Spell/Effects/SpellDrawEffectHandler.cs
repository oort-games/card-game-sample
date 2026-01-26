using UnityEngine;

public class SpellDrawEffectHandler : ISpellEffectHandler
{
    public void Apply(SpellEffectData effect, IBattleTarget target, BattleContext context)
    {
        context.DrawCards(effect.value);
    }
}