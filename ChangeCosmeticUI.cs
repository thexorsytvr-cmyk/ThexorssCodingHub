using System;
using UnityEngine;
using UnityEngine.UI;
using Photon.VR;
using Photon.VR.Cosmetics;

public class ChangeCosmeticUI : MonoBehaviour
{
    [Header("Cosmetic Settings")]
    public string Slot;
    public string CosmeticName;

    private void Awake()
    {
        Button targetButton = GetComponent<Button>();
        
        if (targetButton != null)
        {
            targetButton.onClick.AddListener(ApplyCosmetic);
        }
    }

    public void ApplyCosmetic()
    {
        if (string.IsNullOrEmpty(Slot) || string.IsNullOrEmpty(CosmeticName))
        {
            Debug.LogWarning("Cosmetic Slot or Name is not assigned.");
            return;
        }

        try
        {
            CosmeticType cosmeticType = (CosmeticType)Enum.Parse(typeof(CosmeticType), Slot, true);
            PhotonVRManager.SetCosmetic(cosmeticType, CosmeticName);
            Debug.Log($"Applied cosmetic: {CosmeticName} to slot: {cosmeticType}");
        }
        catch (ArgumentException e)
        {
            Debug.LogError($"Invalid Cosmetic Slot name: {Slot}. Error: {e.Message}");
        }
    }
} // <--- Ensure this closing brace exists and is the last character (ignoring whitespace)   