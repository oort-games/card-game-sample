using UnityEngine;

public class RelicTriggerContext
{
    public RelicTriggerType TriggerType { get; }
    public BattleContext BattleContext { get; }

    public SpellCard SpellCard { get; }
    public SpellActionType? SpellActionType { get; }

    public RelicTriggerContext(RelicTriggerType triggerType, BattleContext battleContext, SpellCard spellCard = null)
    {
        TriggerType = triggerType;
        BattleContext = battleContext;
        SpellCard = spellCard;
        SpellActionType = spellCard?.Data.actionType;
    }
}
