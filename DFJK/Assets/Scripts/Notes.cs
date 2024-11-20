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

    public bool owari = false;

    PlayInputManager PIM;

    void Awake()
    {
        owari = false;
        GetComponent<Renderer>().enabled = true;
        endpanjung = 0;
        GameObject mang = GameObject.Find("El_Fail");
        PIM = mang.GetComponent<PlayInputManager>();
    }
    public void SizeJojul()
    {
        //Debug.Log($"LONGnote Size changed into {(endpanjung-panjung)*GameManager.notespeed/250} / spoint = {panjung}");
        GetComponent<Renderer>().enabled = false;
        transform.localScale = new Vector3(1, (endpanjung-panjung)*GameManager.notespeed/250);
    }
    
    public void 태고의달인()
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
        if (!longNoteProcessing)// 단노트, 손을 놓은 롱노트의 경우
        {
            transform.position = new Vector3(notePosition[line], (-3 + (GameManager.notespeed)*(panjung - NotesCreate.nowms)/1000), 0);
            if (transform.position.y < -5)
            {
                if (!owari)
                    Debug.Log($"ΛΛISS where {panjung}, line {line}");
                owari = true;
                if (endpanjung == 0)
                    NoteOver(true);
                else
                {
                    transform.position = new Vector3(notePosition[line], -5, 0);
                    transform.localScale = new Vector3(1, (endpanjung-NotesCreate.nowms)*GameManager.notespeed/250+2);
                    if (transform.localScale.y <= 0)
                    {
                        NoteOver(true);
                    }
                }
            }
        }
        else // 처리중인 롱노트의 경우
        {
            transform.position = new Vector3(notePosition[line], -3, 0);
            transform.localScale = new Vector3(1, (endpanjung-NotesCreate.nowms)*GameManager.notespeed/250);
            if (transform.localScale.y <= 0)
            {
                Debug.Log($"PERFΞCT where {panjung}, line {line}");
                owari = true;
                NoteOver(true);
            }
        }   
    }

    public void NoteOver(bool kameila)
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
        if (kameila)
            NOPlus();
    }
    void NOPlus()
    {
        longNoteProcessing = false;
        gameObject.SetActive(false);
        owari = false;
    }
}
