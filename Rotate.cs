using UnityEngine;

public class rotate : MonoBehaviour
{
    public float speed = 0.1f;

    void Update()
    {
        transform.Rotate(0f, 0f, 0.1f);
    }
}