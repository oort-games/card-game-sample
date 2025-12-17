using UnityEngine;

public class RelicCard : Card
{
    public new RelicCardData Data => (RelicCardData)base.Data;

    public RelicCard(RelicCardData data) : base(data) { }

    public override bool CanPlay(BattleContext context) => false;

    public override void Play(BattleContext context) { }
}
