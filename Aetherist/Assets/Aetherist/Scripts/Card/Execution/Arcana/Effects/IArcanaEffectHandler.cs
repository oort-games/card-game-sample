using UnityEngine;

public interface IArcanaEffectHandler
{
    void Apply(ArcanaEffectData effect, BattleContext context);
}