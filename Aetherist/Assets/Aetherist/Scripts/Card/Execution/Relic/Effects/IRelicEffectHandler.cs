using UnityEngine;

public interface IRelicEffectHandler
{
    void Apply(RelicEffectData effect, RelicCard relic, RelicTriggerContext context);
}
