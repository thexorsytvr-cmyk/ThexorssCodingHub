using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITab : MonoBehaviour
{
    public Button Button;
    public GameObject[] tabContenttoEnable;
    public GameObject[] tabContentToDisable;
    private void Start()
    {
        Button.onClick.AddListener(ToggleTab);
    }

    private void ToggleTab()
    {
        foreach (GameObject obj in tabContenttoEnable)
        {
            obj.SetActive(true);
        }
        foreach (GameObject obj in tabContentToDisable)
        {
            obj.SetActive(false);
        }
    }
}
