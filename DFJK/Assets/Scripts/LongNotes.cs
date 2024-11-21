using UnityEditor.MemoryProfiler;
using UnityEngine;

public class LongNotes : MonoBehaviour
{
    void OnEnable()
    {
        transform.localPosition = new Vector3(0, 0.125f, 0);
    }

    void LateUpdate()
    {
        if (transform.position.y < -5.125)
        {
            gameObject.SetActive(false);
        }
    }
}
