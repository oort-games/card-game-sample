using UnityEngine;

public class BattleUnitView : MonoBehaviour
{
    [SerializeField] Transform _modelRoot;

    BattleUnit _unit;

    public void Bind(BattleUnit unit)
    {
        _unit = unit;
        _unit.OnHpChanged += OnHpChanged;
    }

    void OnHpChanged(BattleUnit unit)
    {
        Debug.Log($"HP : {unit.Hp}");
    }
}
