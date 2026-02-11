using UnityEngine;

public class BattleSpellCardView : MonoBehaviour
{
    [Header("View")]
    [SerializeField] SpellCardView _view;

    [Header("Selection")]
    [SerializeField] GameObject _selectedObject;

    [Header("Playable Color")]
    [SerializeField] Color _playableCostColor = Color.green;
    [SerializeField] Color _unPlayableCostColor = Color.red;

    public CardInputHandler Input => _view.Input;

    public void Bind(SpellCardData data)
    {
        _view.Bind(data);
        SetSelected(false);
    }

    public void SetSelected(bool selected)
    {
        if (_selectedObject != null)
            _selectedObject.SetActive(selected);
    }

    public void SetPlayable(bool playable)
    {
        if (_view.Collider == null)
        {
            _view.Collider.enabled = playable;
        }
        _view.CostText.color = playable ? _playableCostColor : _unPlayableCostColor;
    }
}
