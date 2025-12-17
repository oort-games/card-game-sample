using UnityEngine;

public class AttackSpellAction : ISpellAction
{
    public void Excute(SpellCard card, BattleContext context)
    {
        context.RelicExecutor.Trigger(RelicTriggerType.OnSpellUsed, context);

        foreach(var effect in card.Data.effects)
        {

        }
    }
}
