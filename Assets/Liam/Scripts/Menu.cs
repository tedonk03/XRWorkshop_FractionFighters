using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public void ToggleMenu(bool status)
    {
        gameObject.SetActive(status);
    }

}
