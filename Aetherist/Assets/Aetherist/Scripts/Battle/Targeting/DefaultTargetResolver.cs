using System;
using System.Collections.Generic;

public class DefaultTargetResolver : ITargetResolver
{
    public IReadOnlyList<IBattleTarget> Resolve(CardTarget target, BattleContext context)
    {
        return target switch
        {
            CardTarget.Self => ResolveSelf(context),
            CardTarget.SingleEnemy => ResolveSingleEnemy(context),
            CardTarget.AllEnemies => ResolveAllEnemies(context),
            CardTarget.LowestHPEnemy => ResolveLowestHPEnemy(context),
            _ => Empty()
        };
    }

    IReadOnlyList<IBattleTarget> ResolveSelf(BattleContext context)
    {
        return new[] { context.Player };
    }

    IReadOnlyList<IBattleTarget> ResolveSingleEnemy(BattleContext context)
    {
        return context.Enemies.Count > 0 ? new[] { context.Enemies[0] } : Empty();
    }

    IReadOnlyList<IBattleTarget> ResolveAllEnemies(BattleContext context)
    {
        return context.Enemies.Count > 0 ? context.Enemies : Empty();
    }

    IReadOnlyList<IBattleTarget> ResolveLowestHPEnemy(BattleContext context)
    {
        if (context.Enemies.Count == 0) return Empty();

        EnemyTarget lowest = context.Enemies[0];

        for (int i = 1; i < context.Enemies.Count; i++)
        {
            if (context.Enemies[i].Hp <  lowest.Hp)
            {
                lowest = context.Enemies[i];
            }
        }
        return new[] { lowest };
    }

    static IReadOnlyList<IBattleTarget> Empty() => Array.Empty<IBattleTarget>();
}
