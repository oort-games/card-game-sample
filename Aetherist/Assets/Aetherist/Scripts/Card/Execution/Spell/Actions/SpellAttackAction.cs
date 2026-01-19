using UnityEngine;

public class SpellAttackAction : ISpellAction
{
    public void Excute(SpellCard card, BattleContext context)
    {
        context.RelicExecutor.Trigger(new RelicTriggerContext(RelicTriggerType.OnSpellUsed, context, card));

        foreach(var effect in card.Data.effects)
        {
            var targets = context.TargetResolver.Resolve(effect.target, context);

            foreach (var target in targets)
            {
                SpellEffectProcessor.Apply(effect, target, card, context);
            }
        }
    }
}