using UnityEngine;

public interface IRelicEffectHandler
{
    void Apply(RelicEffectData effect, RelicTriggerContext context);
}
