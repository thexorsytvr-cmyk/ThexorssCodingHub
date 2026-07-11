using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayedObjectSwap : MonoBehaviour
{
    [Header("Audio")]
    public AudioSource targetAudioSource;

    [Header("3.88 Second Swap")]
    public GameObject objectA;
    public GameObject objectB;

    [Header("7.76 Second Swap")]
    public List<GameObject> objectsToDisable = new List<GameObject>();
    public List<GameObject> objectsToEnable = new List<GameObject>();

    private bool sequenceStarted = false;

    private void Start()
    {
        StartCoroutine(WaitForAudioThenRun());
    }

    private IEnumerator WaitForAudioThenRun()
    {
        // Wait for runtime + audio to actually start playing
        yield return new WaitUntil(() =>
            targetAudioSource != null &&
            targetAudioSource.isPlaying
        );

        sequenceStarted = true;

        yield return RunSequence();
    }

    private IEnumerator RunSequence()
    {
        // 3.88 seconds after audio starts
        yield return new WaitForSeconds(3.88f);

        if (objectA != null)
            objectA.SetActive(false);

        if (objectB != null)
            objectB.SetActive(true);

        // Wait remaining time to reach 7.76s total
        yield return new WaitForSeconds(3.88f);

        foreach (GameObject obj in objectsToDisable)
        {
            if (obj != null)
                obj.SetActive(false);
        }

        foreach (GameObject obj in objectsToEnable)
        {
            if (obj != null)
                obj.SetActive(true);
        }
    }
}