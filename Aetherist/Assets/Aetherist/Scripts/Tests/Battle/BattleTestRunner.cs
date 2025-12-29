using System.Collections.Generic;
using UnityEngine;

public class BattleTestRunner : MonoBehaviour
{
    [SerializeField] SpellCardData testSpellCard;

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

        var card = new SpellCard(testSpellCard);

        if (card.CanPlay(context))
        {
            card.Play(context);
        }
    }
}
