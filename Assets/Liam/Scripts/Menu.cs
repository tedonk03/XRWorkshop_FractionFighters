using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public void ToggleMenu(bool status)
    {
        FindObjectOfType<AudioManager>().Play("click");
        gameObject.SetActive(status);
    }

}
