using UnityEngine;

public class RelicGainManaEffectHandler : IRelicEffectHandler
{
    public void Apply(RelicEffectData effect, RelicTriggerContext context)
    {
        context.BattleContext.AddMana(effect.value);
    }
}