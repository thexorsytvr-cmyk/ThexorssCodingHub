using System;
using UnityEngine;
using Photon.VR;
using Photon.VR.Cosmetics;

public class ChangeCosmetic : MonoBehaviour
{
    public string Slot;
    public string CosmeticName;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("HandTag"))
        {
            CosmeticType cosmeticType = (CosmeticType)Enum.Parse(typeof(CosmeticType), Slot);

            PhotonVRManager.SetCosmetic(cosmeticType, CosmeticName);
        }
    }
}