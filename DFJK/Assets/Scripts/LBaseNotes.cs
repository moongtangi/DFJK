using UnityEditor.MemoryProfiler;
using UnityEngine;
using UnityEngine.InputSystem;

public class LBaseNotes : MonoBehaviour
{
    public readonly float[] notePosition = { -1.5f, -0.5f, 0.5f, 1.5f };
    public int line;
    public int panjung;
    public int endpanjung;
    public bool IamJunbiOK;

    public void SizeJojul()
    {
        Debug.Log($"LONGnote Size changed into {(endpanjung-panjung)*GameManager.notespeed/1000} / spoint = {panjung}");
        transform.localScale = new Vector3(1, (endpanjung-panjung)*GameManager.notespeed/250);
        IamJunbiOK = true;
        
    }

    void LateUpdate()
    {
        transform.position = new Vector3(notePosition[line], (-3.125f + (GameManager.notespeed)*(panjung - NotesCreate.nowms)/1000), 0);
        if (transform.position.y < -5.125 && IamJunbiOK)
        {
            gameObject.SetActive(false);
            IamJunbiOK = false;
        }
    }
}
