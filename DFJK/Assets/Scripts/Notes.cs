using UnityEditor.MemoryProfiler;
using UnityEngine;
using UnityEngine.InputSystem;

public class Notes : MonoBehaviour
{
    public readonly float[] notePosition = { -1.5f, -0.5f, 0.5f, 1.5f };
    public int line;
    public int panjung;

    void LateUpdate()
    {
        transform.position = new Vector3(notePosition[line], (-3 + (GameManager.notespeed)*(panjung - NotesCreate.nowms)/1000), 0);
        if (transform.position.y < -5.125)
        {
            gameObject.SetActive(false);
        }
    }
}
