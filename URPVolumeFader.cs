using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using System.Collections;

public class URPFinalSequence : MonoBehaviour
{
    [Header("Links")]
    public Volume targetVolume;
    public GameObject objectToLoad; // The object to "spawn" or activate
    
    [Header("Settings")]
    public float delayBeforeFade = 10f;
    public float fadeDuration = 5f;
    public float targetExposure = -100f;

    private ColorAdjustments colorAdjustments;

    void Start()
    {
        // Ensure the object we want to load is hidden at the start
        if (objectToLoad != null)
            objectToLoad.SetActive(false);

        // Access the Color Adjustments from the Volume
        if (targetVolume.profile.TryGet<ColorAdjustments>(out var ca))
        {
            colorAdjustments = ca;
        }
        else
        {
            Debug.LogError("Add 'Color Adjustments' to your Volume Profile first!");
        }

        StartCoroutine(ExecuteSequence());
    }

    IEnumerator ExecuteSequence()
    {
        // 1. Wait for the initial 10 seconds
        yield return new WaitForSeconds(delayBeforeFade);

        // 2. Fade the exposure down to -100
        if (colorAdjustments != null)
        {
            float startExposure = colorAdjustments.postExposure.value;
            float elapsed = 0f;

            while (elapsed < fadeDuration)
            {
                elapsed += Time.deltaTime;
                colorAdjustments.postExposure.value = Mathf.Lerp(startExposure, targetExposure, elapsed / fadeDuration);
                yield return null;
            }
            
            colorAdjustments.postExposure.value = targetExposure;
        }

        // 3. The Fade is finished! Load the object.
        if (objectToLoad != null)
        {
            objectToLoad.SetActive(true);
            Debug.Log("Sequence Complete: Object Loaded.");
        }
    }
}