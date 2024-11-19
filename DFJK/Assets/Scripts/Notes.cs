using System.Collections.Generic;
using UnityEditor;
using UnityEditor.MemoryProfiler;
using UnityEngine;

public class Notes : MonoBehaviour
{
    public readonly float[] notePosition = { -1.5f, -0.5f, 0.5f, 1.5f };
    public int line;
    public int panjung;
    public int endpanjung;
    public bool longNoteProcessing;

    PlayInputManager PIM;

    void Awake()
    {
        GetComponent<Renderer>().enabled = true;
        endpanjung = 0;
        GameObject mang = GameObject.Find("El_Fail");
        PIM = mang.GetComponent<PlayInputManager>();
    }
    public void SizeJojul()
    {
        Debug.Log($"LONGnote Size changed into {(endpanjung-panjung)*GameManager.notespeed/250} / spoint = {panjung}");
        GetComponent<Renderer>().enabled = false;
        transform.localScale = new Vector3(1, (endpanjung-panjung)*GameManager.notespeed/250);
    }
    
    public void 태고의달인()
    {
        Invoke("Anchi", (GameManager.notespeed)*(panjung - NotesCreate.nowms)/1000 - 200);
    }
    void Anchi()
    {  
        switch (line){
            case 0:
                PIM.an0.Add(this.gameObject);
                break;
            case 1:
                PIM.an1.Add(this.gameObject);
                break;
            case 2:
                PIM.an2.Add(this.gameObject);
                break;
            default:
                PIM.an3.Add(this.gameObject);
                break;
        }
    }

    void LateUpdate()
    {
        if (!longNoteProcessing)
        {
            transform.position = new Vector3(notePosition[line], (-3 + (GameManager.notespeed)*(panjung - NotesCreate.nowms)/1000), 0);
            if (panjung - NotesCreate.nowms < -200)
            {
                Debug.Log($"ΛΛISS where {panjung}");
                NoteOver();  
            }
        }
        else
        {
            transform.position = new Vector3(notePosition[line], -3, 0);
            transform.localScale = new Vector3(1, (endpanjung-NotesCreate.nowms)*GameManager.notespeed/250);
            if (transform.localScale.y <= 0)
            {
                Debug.Log($"ΛΛISS where {panjung}");
                NoteOver();
            }
        }   
    }

    public void NoteOver()
    {
        switch (line){
            case 0:
                PIM.an0.Remove(this.gameObject);
                break;
            case 1:
                PIM.an1.Remove(this.gameObject);
                break;
            case 2:
                PIM.an2.Remove(this.gameObject);
                break;
            default:
                PIM.an3.Remove(this.gameObject);
                break;
        }
        longNoteProcessing = false;
        gameObject.SetActive(false);
    }
}
