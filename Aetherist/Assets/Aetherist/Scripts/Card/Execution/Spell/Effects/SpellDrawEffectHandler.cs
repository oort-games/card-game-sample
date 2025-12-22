using UnityEngine;

public class SpellDrawEffectHandler : ISpellEffectHandler
{
    public void Apply(SpellEffectData effect, SpellCard card, BattleContext context)
    {
        context.DarwCards(effect.value);
    }
}
