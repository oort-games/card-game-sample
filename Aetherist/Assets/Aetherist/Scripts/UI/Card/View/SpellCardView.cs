using UnityEngine;
using TMPro;

public class SpellCardView : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] TMP_Text _nameText;
    [SerializeField] TMP_Text _costText;

    SpellCardData _data;

    public void Bind(SpellCardData data)
    {
        _data = data;

        _nameText.text = data.displayName;
        _costText.text = $"{data.cost}";
    }

    public void SetSelected(bool selected)
    {

    }
}
