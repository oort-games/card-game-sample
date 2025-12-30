using UnityEngine;

public class RelicGainManaEffectHandler : IRelicEffectHandler
{
    public void Apply(RelicEffectData effect, RelicCard relic, RelicTriggerContext context)
    {
        context.BattleContext.AddMana(effect.value);
    }
}