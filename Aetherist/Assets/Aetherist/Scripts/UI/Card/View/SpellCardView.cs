using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SpellCardView : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] TMP_Text _nameText;
    [SerializeField] TMP_Text _costText;

    [Header("Selection")]
    [SerializeField] GameObject _selectedObject;

    [Header("State")]
    [SerializeField] CanvasGroup _canvasGroup;

    SpellCardData _data;

    public void Bind(SpellCardData data)
    {
        _data = data;

        _nameText.text = data.displayName;
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
        if (_canvasGroup == null)
            return;

        _canvasGroup.alpha = playable ? 1 : 0;
        _canvasGroup.interactable = playable;
        _canvasGroup.blocksRaycasts = playable;
    }
}
