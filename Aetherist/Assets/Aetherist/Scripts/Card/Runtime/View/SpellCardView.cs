using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SpellCardView : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] TMP_Text _nameText;
    [SerializeField] TMP_Text _descText;
    [SerializeField] TMP_Text _costText;

    [Header("Selection")]
    [SerializeField] GameObject _selectedObject;

    [Header("Input")]
    [SerializeField] Collider2D _collider;

    [Header("Playable Color")]
    [SerializeField] Color _playableCostColor = Color.green;
    [SerializeField] Color _unPlayableCostColor = Color.red;

    SpellCardData _data;

    public void Bind(SpellCardData data)
    {
        _data = data;

        _nameText.text = data.displayName;
        _descText.text = data.description;
        _costText.text = $"{data.cost}";

        SetSelected(false);
    }

    public void SetSelected(bool selected)
    {
        if (_selectedObject != null)
            _selectedObject.SetActive(selected);
    }

    public void SetPlayable(bool playable)
    {
        if (_collider == null)
        {
            _collider.enabled = playable;
        }

        _costText.color = playable ? _playableCostColor : _unPlayableCostColor;
    }
}
