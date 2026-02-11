using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SpellCardView : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] TMP_Text _nameText;
    [SerializeField] TMP_Text _descText;
    [SerializeField] TMP_Text _costText;

    [Header("Collider")]
    [SerializeField] Collider2D _collider;

    [Header("Input")]
    [SerializeField] CardInputHandler _input;

    public TMP_Text NameText => _nameText;
    public TMP_Text DescText => _descText;
    public TMP_Text CostText => _costText;

    public Collider2D Collider => _collider;
    public CardInputHandler Input => _input;

    public void Bind(SpellCardData data)
    {
        _nameText.text = data.displayName;
        _descText.text = data.description;
        _costText.text = $"{data.cost}";
    }
}