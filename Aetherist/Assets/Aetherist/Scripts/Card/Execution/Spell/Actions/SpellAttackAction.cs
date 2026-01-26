using UnityEngine;

public class SpellAttackAction : ISpellAction
{
    public void Excute(SpellCard spell, BattleContext context)
    {      
        foreach(var effect in spell.Data.effects)
        {
            var targets = context.TargetResolver.Resolve(effect.target, context);

            foreach (var target in targets)
            {
                context.PresentationQueue.Enqueue(new SpellPresentation(effect, target, context));
            }
        }
    }
}