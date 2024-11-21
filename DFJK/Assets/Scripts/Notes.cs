using System.Collections.Generic;
using UnityEditor;
using UnityEditor.MemoryProfiler;
using UnityEngine;

public class Notes : MonoBehaviour
{
    public readonly float[] notePosition = { -1.82f, -0.68f, 0.45f, 1.6f };
    public int line;
    public int panjung;
    public int endpanjung;
    public bool longNoteProcessing;

    public int panju;
    public int endpanju;

    public bool owari = false;

    PlayInputManager PIM;
    PanjungChang PC;

    void Awake()
    {
        longNoteProcessing = false;
        owari = false;
        GetComponent<Renderer>().enabled = true;
        endpanjung = 0;
        GameObject pan = GameObject.Find("ShinChangSup");
        GameObject mang = GameObject.Find("El_Fail");
        PIM = mang.GetComponent<PlayInputManager>();
        PC = pan.GetComponent<PanjungChang>();
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
            transform.position = new Vector3(notePosition[line], (-3 + (GameManager.notespeed)*(panjung - NotesCreate.nowms)/1000),
            ((endpanjung == 0) ? 0 : 0.4f)); // 롱노트면 단놋 하나 크기만큼 키워야함
            //if (transform.position.y < -5f){GetComponent<Renderer>().enabled = false;}

            if (panjung - NotesCreate.nowms < -250)
            {
                if (!owari)
                    PC.Miss(this.gameObject);
                owari = true;

                if (endpanjung == 0)
                    NoteOver(true);
                else
                {
                    transform.position = new Vector3(notePosition[line], -2.68f, 0);//아니 이거 고쳐야하는데 시간없네 뭔지알고싶으면 기어 한겹 벗겨서 봐봐
                    transform.localScale = new Vector3(1, (endpanjung-NotesCreate.nowms)*GameManager.notespeed/250);
                    if (transform.localScale.y <= 0)
                    {
                        NoteOver(true);
                    }
                }
            }
        }
        else // 처리중인 롱노트의 경우
        {
            transform.position = new Vector3(notePosition[line], -2.462f, 0);
            transform.localScale = new Vector3(1, (endpanjung-NotesCreate.nowms)*GameManager.notespeed/250-2);//-2빼면 (1, 0.25)기준 맞음
            if (transform.localScale.y <= 0)
            {
                PC.Perfect(this.gameObject);
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
        longNoteProcessing = false;
        gameObject.SetActive(false);
        owari = false;
    }
}
