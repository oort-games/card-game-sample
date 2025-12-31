using UnityEngine;

public interface ISpellEffectHandler
{
    void Apply(SpellEffectData effect, SpellCard card, BattleContext context, CardTarget target);
}
