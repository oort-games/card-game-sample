using UnityEngine;

public static class RelicConditionEvaluator
{
    public static bool CheckAll(RelicConditionData[] conditions, RelicTriggerContext context)
    {
        if (conditions == null || conditions.Length == 0)
            return true;

        foreach (var condition in conditions)
        {
            if (!Check(condition, context))
                return false;
        }

        return true;
    }

    static bool Check(RelicConditionData condition, RelicTriggerContext context)
    {
        switch (condition.conditionType)
        {
            case RelicConditionType.HandCardCount:
                break;
            case RelicConditionType.ManaRemaining:
                return Compare(
                    context.BattleContext.Mana,
                    condition
                );
            case RelicConditionType.ManaSpent:
                break;
            case RelicConditionType.SpellUsedCount:
                break;
            case RelicConditionType.DistinctElementUsed:
                break;
            case RelicConditionType.SpecificElementUsed:
                break;
            case RelicConditionType.PlayerHealthPercent:
                break;
            case RelicConditionType.EnemyCount:
                break;
        }
        return true;
    }

    static bool Compare(uint currentValue, RelicConditionData condition)
    {
        return condition.comparison switch
        {
            ComparisonType.Equal => currentValue == condition.value,
            ComparisonType.Greater => currentValue > condition.value,
            ComparisonType.GreaterOrEqual => currentValue >= condition.value,
            ComparisonType.Less => currentValue < condition.value,
            ComparisonType.LessOrEqual => currentValue <= condition.value,
            _ => false
        };
    }
}
