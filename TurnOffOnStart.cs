using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOffOnStart : MonoBehaviour
{
    public GameObject[] objectsToDisable;
    void Start()
    {
            foreach (GameObject obj in objectsToDisable)
            {
                obj.SetActive(false);
            }
    }
}

