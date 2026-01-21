using UnityEngine;

public class ArcanaIncreaseMaxManaHandler : IArcanaEffectHandler
{
    public void Apply(ArcanaEffectData effect, BattleContext context)
    {
        context.IncreaseMaxMana(effect.value);
        context.AddMana(effect.value);
    }
}
