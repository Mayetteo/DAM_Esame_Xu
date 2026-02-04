using UnityEngine;

public class Rotate : MonoBehaviour
{
    public GameObject clickerContainerTransform;
    
    void FixedUpdate()
    {
        clickerContainerTransform.transform.Rotate(0,0, Time.deltaTime * 10);
    }
}
