using UnityEngine;

public class Toggle : MonoBehaviour
{
    public GameObject[] objectsToEnable;
    public GameObject[] objectsToDisable;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "HandTag")
        {
            foreach (GameObject obj in objectsToEnable)
            {
                obj.SetActive(true);
            }
            foreach (GameObject obj in objectsToDisable)
            {
                obj.SetActive(false);
            }
        }
    }
}
