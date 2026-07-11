using UnityEngine;
using TMPro;

public class Battery : MonoBehaviour
{
    // Reference to the TextMeshProUGUI component
    public TMP_Text batteryText;

    void Start()
    {
        if (batteryText == null)
        {
            Debug.LogError("Battery TextMeshProUGUI reference is missing!");
            return;
        }

        // Initial update
        UpdateBatteryPercentage();
    }

    void Update()
    {
        UpdateBatteryPercentage();
    }

    void UpdateBatteryPercentage()
    {
        // Get the battery level
        float batteryLevel = SystemInfo.batteryLevel;

        // Convert to percentage
        int batteryPercentage = Mathf.RoundToInt(batteryLevel * 100);

        // Display the battery percentage
        batteryText.text = $"{batteryPercentage}%";
    }
}
