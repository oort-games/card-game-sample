using UnityEngine;

public class RelicTriggerContext
{
    public RelicTriggerType TriggerType { get; }
    public BattleContext BattleContext { get; }

    public SpellCard SpellCard { get; }
    public SpellActionType? SpellActionType { get; }

    public RelicTriggerContext(RelicTriggerType triggerType, BattleContext context, SpellCard spell = null)
    {
        TriggerType = triggerType;
        BattleContext = context;
        SpellCard = spell;
        SpellActionType = spell?.Data.actionType;
    }
}
