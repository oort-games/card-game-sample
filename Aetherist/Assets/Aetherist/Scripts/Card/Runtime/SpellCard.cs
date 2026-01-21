using UnityEngine;

public class SpellCard : Card
{
    public new SpellCardData Data => (SpellCardData)base.Data;

    public SpellCard(SpellCardData data) : base(data) { }

    protected override uint GetBaseCost() => Data.cost;

    public override bool CanPlay(BattleContext context)
    {
        return context.CanUseMana(CurrentCost);
    }

    public override void Play(BattleContext context)
    {
        Debug.Log($"[Spell] Play | {Data.displayName} ({Data.actionType})");
        context.UseMana(CurrentCost);
        context.SpellExecutor.Excute(this, context);
    }
}
