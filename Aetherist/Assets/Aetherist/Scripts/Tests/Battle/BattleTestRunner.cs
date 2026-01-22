using System.Collections.Generic;
using UnityEngine;

public class BattleTestRunner : MonoBehaviour
{
    [SerializeField] SpellCardData testSpellCard;
    [SerializeField] RelicCardData testRelicCard;
    [SerializeField] ArcanaCardData testArcanaCard;

    void Start()
    {
        var presentationQueue = new BattlePresentationQueue();

        var spellExecutor = new SpellExecutor();
        var relicExecutor = new RelicExecutor();
        var arcanaExecutor = new ArcanaExecutor(presentationQueue);

        var targetResolver = new DefaultTargetResolver();

        var context = new BattleContext(
            presentationQueue,
            spellExecutor,
            relicExecutor,
            arcanaExecutor,
            targetResolver
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

        context.RelicExecutor.Trigger(RelicTriggerType.OnBattleStart, context);

        context.ArcanaExecutor.Execute(testArcanaCard, context);

        var spell = new SpellCard(testSpellCard);

        if (spell.CanPlay(context))
        {
            spell.Play(context);
        }

        StartCoroutine(context.PresentationQueue.Play());
    }
}
