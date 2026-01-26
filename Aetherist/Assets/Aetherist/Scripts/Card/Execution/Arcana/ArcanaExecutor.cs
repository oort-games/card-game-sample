using UnityEngine;

public class ArcanaExecutor
{
    public ArcanaExecutor()
    {
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
        context.PresentationQueue.Enqueue(new ArcanaPresentation(effect, context));
    }
}
