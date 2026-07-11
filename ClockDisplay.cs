using TMPro;
using UnityEngine;
using System;

public class ClockDisplay : MonoBehaviour
{
    [SerializeField] private TMP_Text timeText;

    private void Update()
    {
        timeText.text = DateTime.Now.ToString("HH:mm");
    }
}