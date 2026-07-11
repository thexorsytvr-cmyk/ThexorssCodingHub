using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableOnStart : MonoBehaviour
{
    public GameObject targetObject;
    void Awake()
    {
        targetObject.SetActive(true);
    }
}
