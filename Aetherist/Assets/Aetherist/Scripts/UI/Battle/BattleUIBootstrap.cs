using UnityEngine;

public class BattleUIBootstrap : MonoBehaviour
{
    [SerializeField] HandCardPanel _handPanel;

    BattleHand _hand;

    public void Init(BattleContext context)
    {
        _hand = context.Hand;
    }

    public void RefreshHand()
    {
        _handPanel.SetHand(_hand.Cards);
    }
}
