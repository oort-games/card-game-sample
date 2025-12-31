using UnityEngine;

public class SpellAttackAction : ISpellAction
{
    public void Excute(SpellCard card, BattleContext context)
    {
        context.RelicExecutor.Trigger(new RelicTriggerContext(RelicTriggerType.OnSpellUsed, context, card));

        foreach (var effectGroup in card.Data.GetEffectGroups())
        {
            foreach (var effect in effectGroup.effects)
            {
                SpellEffectProcessor.Apply(effect, card, context, effectGroup.target);
            }
        }
    }
}
