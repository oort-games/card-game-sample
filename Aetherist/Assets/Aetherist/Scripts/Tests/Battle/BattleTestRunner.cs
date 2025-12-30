using System.Collections.Generic;
using UnityEngine;

public class BattleTestRunner : MonoBehaviour
{
    [SerializeField] SpellCardData testSpellCard;
    [SerializeField] RelicCardData testRelicCard;

    void Start()
    {
        var context = new BattleContext(
            spellExecutor: new SpellExecutor(),
            relicExecutor: new RelicExecutor(),
            targetResolver: new DefaultTargetResolver() 
            );

        var player = new PlayerTarget(20);
        var enemies = new List<EnemyTarget>
        {
            new EnemyTarget(10)
        };

        context.SetupBattle(3, player, enemies);

        var relic = new RelicCard(testRelicCard);
        context.RelicExecutor.AddRelic(relic);

        Debug.Log("[Battle] Start | Test");

        context.RelicExecutor.Trigger(new RelicTriggerContext(RelicTriggerType.OnBattleStart, context));

        var spell = new SpellCard(testSpellCard);

        if (spell.CanPlay(context))
        {
            spell.Play(context);
        }
    }
}
