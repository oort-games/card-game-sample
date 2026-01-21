using UnityEngine;

public interface ISpellEffectHandler
{
    void Apply(SpellEffectData effect, IBattleTarget target, SpellCard spell, BattleContext context);
}
