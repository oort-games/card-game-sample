using TMPro;
using UnityEngine;

public class ManaView : MonoBehaviour
{
    [SerializeField] TMP_Text _manaText;

    public void SetMana(uint mana)
    {
        _manaText.text = mana.ToString();
    }
}
