using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleTestRunner : MonoBehaviour
{
    [SerializeField] SpellCardData _testSpellCard;
    [SerializeField] RelicCardData _testRelicCard;
    [SerializeField] ArcanaCardData _testArcanaCard;

    [SerializeField] BattleSceneController _battleSceneController;

    BattleContext _context;

    void Start()
    {
        var spellExecutor = new SpellExecutor();
        var relicExecutor = new RelicExecutor();
        var arcanaExecutor = new ArcanaExecutor();

        var presentationQueue = new BattlePresentationQueue();
        var targetResolver = new DefaultTargetResolver();

        _context = new BattleContext(
            spellExecutor,
            relicExecutor,
            arcanaExecutor,
            presentationQueue,
            targetResolver
            );

        var player = new PlayerTarget(20);
        var enemies = new List<EnemyTarget>
        {
            new(10)
        };

        _context.SetupBattle(3, player, enemies);

        _battleSceneController.StartBattle(_context);

        //var relic = new RelicCard(_testRelicCard);
        //_context.RelicExecutor.AddRelic(relic);

        //StartCoroutine(StartBattle());
    }

    IEnumerator StartBattle()
    {
        Debug.Log("[Battle] Start | Test");
        _context.ArcanaExecutor.Execute(_testArcanaCard, _context);
        _context.RelicExecutor.Trigger(RelicTriggerType.OnBattleStart, _context);

        yield return _context.PresentationQueue.Play();

        var spell = new SpellCard(_testSpellCard);

        if (spell.CanPlay(_context))
        {
            spell.Play(_context);
        }
    }
}
