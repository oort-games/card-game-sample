using System.Collections.Generic;

public interface ITargetResolver
{
    IReadOnlyList<IBattleTarget> Resolve(CardTarget target, BattleContext context);
}
