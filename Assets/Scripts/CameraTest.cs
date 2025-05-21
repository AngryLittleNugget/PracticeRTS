using UnityEngine;

public class CameraTest : MonoBehaviour
{
    [SerializeField] private Transform gridPosition;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(gridPosition);
    }
}
