using UnityEngine;

public class RelicTriggerContext
{
    public RelicTriggerType TriggerType { get; }
    public BattleContext BattleContext { get; }

    public SpellCard SpellCard { get; }
    public SpellActionType? SpellActionType { get; }

    public RelicTriggerContext(RelicTriggerType triggerType, BattleContext context, SpellCard card = null)
    {
        TriggerType = triggerType;
        BattleContext = context;
        SpellCard = card;
        SpellActionType = card?.Data.actionType;
    }
}
