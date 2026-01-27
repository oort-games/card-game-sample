using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleTestRunner : MonoBehaviour
{
    [SerializeField] SpellCardData testSpellCard;
    [SerializeField] RelicCardData testRelicCard;
    [SerializeField] ArcanaCardData testArcanaCard;

    BattleContext context;

    void Start()
    {
        var spellExecutor = new SpellExecutor();
        var relicExecutor = new RelicExecutor();
        var arcanaExecutor = new ArcanaExecutor();

        var presentationQueue = new BattlePresentationQueue();
        var targetResolver = new DefaultTargetResolver();

        context = new BattleContext(
            spellExecutor,
            relicExecutor,
            arcanaExecutor,
            presentationQueue,
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

        StartCoroutine(StartBattle());
    }

    IEnumerator StartBattle()
    {
        Debug.Log("[Battle] Start | Test");
        context.ArcanaExecutor.Execute(testArcanaCard, context);
        context.RelicExecutor.Trigger(RelicTriggerType.OnBattleStart, context);

        yield return context.PresentationQueue.Play();

        var spell = new SpellCard(testSpellCard);

        if (spell.CanPlay(context))
        {
            spell.Play(context);
        }
    }
}
