using UnityEngine;

public class SpellDrawEffectHandler : ISpellEffectHandler
{
    public void Apply(SpellEffectData effect, IBattleTarget target, SpellCard spell, BattleContext context)
    {
        context.DrawCards(effect.value);
    }
}