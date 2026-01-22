using UnityEngine;

public class ArcanaExecutor
{
    readonly BattlePresentationQueue _queue;

    public ArcanaExecutor(BattlePresentationQueue queue)
    {
        _queue = queue;
    }

    public void Execute(ArcanaCardData arcana, BattleContext context)
    {
        foreach (var effect in arcana.effects)
        {
            Execute(effect, context);
        }
    }

    void Execute(ArcanaEffectData effect, BattleContext context)
    {
        _queue.Enqueue(new ArcanaPresentation(effect, context));
    }
}
