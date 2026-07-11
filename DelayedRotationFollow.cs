using UnityEngine;

public class SmoothDelayedFollow : MonoBehaviour
{
    [Header("Object to Copy")]
    public Transform target;

    [Header("Rotation Lag")]
    public float rotationSmoothTime = 0.4f;

    private void Update()
    {
        if (target == null) return;

        // Follow position instantly
        transform.position = target.position;

        // Smoothly follow rotation
        float t = 1f - Mathf.Exp(-Time.deltaTime / rotationSmoothTime);
        transform.rotation = Quaternion.Slerp(
            transform.rotation,
            target.rotation,
            t
        );
    }
}
