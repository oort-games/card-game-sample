using UnityEngine;

public interface ISpellEffectHandler
{
    void Apply(SpellEffectData effect, IBattleTarget target, BattleContext context);
}
