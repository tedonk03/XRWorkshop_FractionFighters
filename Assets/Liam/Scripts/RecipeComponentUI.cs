using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RecipeComponentUI : MonoBehaviour
{
    public MeshRenderer icon;
    public TextMeshPro equationText;
    public GameObject border;

    public void UpdateComponentUI(Material _icon, string _equationText)
    {
        icon.material = _icon;
        equationText.SetText(_equationText);
    }
}
