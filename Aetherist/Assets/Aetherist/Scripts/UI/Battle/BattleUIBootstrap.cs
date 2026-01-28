using UnityEngine;

public class BattleUIBootstrap : MonoBehaviour
{
    [SerializeField] HandCardPanel _handPanel;

    BattleHand _hand;

    public void Init(BattleContext context, BattleHand hand)
    {
        _hand = hand;
        _handPanel.SetHand(_hand.Cards);
    }
}
