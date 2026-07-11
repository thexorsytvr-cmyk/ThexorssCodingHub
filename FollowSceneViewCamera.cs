#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;

[ExecuteAlways]
public class FollowSceneViewCamera : MonoBehaviour
{
    void Update()
    {
        SceneView sceneView = SceneView.lastActiveSceneView;

        if (sceneView != null)
        {
            transform.position = sceneView.camera.transform.position;
            transform.rotation = sceneView.camera.transform.rotation;
        }
    }
}
#endif