using UnityEngine;

public class TargetBehaviour : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(0.0f, 1.0f, 0.0f, Space.World);
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}
