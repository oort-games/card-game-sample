using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleTestRunner : MonoBehaviour
{
    //[SerializeField] SpellCardData _testSpellCard;
    //[SerializeField] RelicCardData _testRelicCard;
    //[SerializeField] ArcanaCardData _testArcanaCard;

    [Header("Deck")]
    [SerializeField] SpellCardData[] _spellDeck;

    [Header("Relic")]
    [SerializeField] RelicCardData[] _relics;

    [Header("Arcana")]
    [SerializeField] ArcanaCardData[] _arcanas;

    [Header("Player")]
    [SerializeField] uint _player = 20;

    [Header("Enemies")]
    [SerializeField] List<uint> _enemys = new() { 10 };

    [Header("Battle Rules")]
    [SerializeField] uint _mana = 3;
    [SerializeField] uint _maxHandSize = 5;
    [SerializeField] uint _drawCountPerTurn = 3;

    [Header("UI")]
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

        var player = new PlayerTarget(_player);

        var enemies = new List<EnemyTarget>();
        foreach (var hp in _enemys)
        {
            enemies.Add(new EnemyTarget(hp));
        }

        _context.SetupBattle(player, enemies, _mana, _maxHandSize, _drawCountPerTurn);
        var testDeck = CreateDeck();

        _battleSceneController.StartBattle(_context, testDeck);
        SetupRelic();
        ExecuteArcanas();
        //_context.PresentationQueue.Play();
    }

    IEnumerable<SpellCard> CreateDeck()
    {
        foreach (var cardData in _spellDeck)
        {
            if (cardData == null)
                continue;

            yield return new SpellCard(cardData);
        }
    }

    void SetupRelic()
    {
        if (_relics == null)
            return;

        foreach (var relicData in _relics)
        {
            if (relicData == null)
                continue;

            var relic = new RelicCard(relicData);
            _context.RelicExecutor.AddRelic(relic);
        }
    }

    void ExecuteArcanas()
    {
        if (_arcanas == null)
            return;

        foreach (var arcanaData in _arcanas)
        {
            if (arcanaData == null)
                continue;

            _context.ArcanaExecutor.Execute(arcanaData, _context);
        }
    }
}
