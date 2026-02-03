using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleTestRunner : MonoBehaviour
{
    [Header("Deck")]
    [SerializeField] SpellCardData[] _spells;

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

        var deck = CreateDeck();
        var hand = new BattleHand();

        _context.SetupBattle(player, enemies, _mana, _maxHandSize, _drawCountPerTurn);
        _context.SetupCard(deck, hand);
        _context.SetupScene(_battleSceneController);

        _battleSceneController.StartBattle(_context);
        SetupRelic();
        ExecuteArcanas();
    }

    BattleDeck CreateDeck()
    {
        List<SpellCard> cards = new();
        foreach (var spellData in _spells)
        {
            if (spellData == null)
                continue;

            cards.Add(new SpellCard(spellData));
        }
        return new BattleDeck(cards);
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
