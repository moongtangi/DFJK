using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayInputManager : MonoBehaviour
{
    public List<GameObject> an0 = new List<GameObject>();
    public List<GameObject> an1 = new List<GameObject>();
    public List<GameObject> an2 = new List<GameObject>();
    public List<GameObject> an3 = new List<GameObject>();
    public PanjungChang PC;

    void Awake()
    {
        GameObject pan = GameObject.Find("ShinChangSup");
        PC = pan.GetComponent<PanjungChang>();
    }

    public void KnKey0(InputAction.CallbackContext context)
    {
        if (context.started)
            foreach (GameObject index in an0)
            {
                // 빨리 치면 +
                int nanahira = index.GetComponent<Notes>().panjung-NotesCreate.nowms;

                if (nanahira < 300 && !index.GetComponent<Notes>().owari)
                {
                    if (-50 < nanahira && nanahira < 50)
                        PC.Perfect(index);
                    else if (-200 < nanahira && nanahira < 200)
                        PC.Great(index);
                    else
                        PC.Bad(index);

                    //단노트 판정 성공: NoteOver 함수 실행
                    if (index.GetComponent<Notes>().endpanjung == 0)
                        index.GetComponent<Notes>().NoteOver(true);
                    //롱노트 판정 성공: longNoteProcessing = true로 바꿈->노트가 내려가는 함수 작동 X
                    else{
                        Debug.Log("롱노트 아르라");
                        index.GetComponent<Notes>().longNoteProcessing = true;}
                    break;
                }
            }

        if (context.canceled)
        {
            foreach (GameObject index in an0)
            {
                if (index.GetComponent<Notes>().longNoteProcessing)
                {
                    Debug.Log("롱노트 뗐음");
                    int sasakure = index.GetComponent<Notes>().endpanjung-NotesCreate.nowms;
                    
                    if (sasakure > 150)
                    {
                        Debug.Log(sasakure);
                        index.GetComponent<Notes>().owari = true;
                        index.GetComponent<Notes>().longNoteProcessing = false;
                    }
                }
            }
        }
    }

    public void KnKey1(InputAction.CallbackContext context)
    {
        if (context.started)
            foreach (GameObject index in an1)
            {
                int nanahira = index.GetComponent<Notes>().panjung-NotesCreate.nowms;

                if (nanahira < 300 && !index.GetComponent<Notes>().owari)
                {
                    if (-50 < nanahira && nanahira < 50)
                        PC.Perfect(index);
                    else if (-200 < nanahira && nanahira < 200)
                        PC.Great(index);
                    else
                        PC.Bad(index);

                    //단노트 판정 성공: NoteOver 함수 실행
                    if (index.GetComponent<Notes>().endpanjung == 0)
                        index.GetComponent<Notes>().NoteOver(true);
                    //롱노트 판정 성공: longNoteProcessing = true로 바꿈->노트가 내려가는 함수 작동 X
                    else{
                        Debug.Log("롱노트 아르라");
                        index.GetComponent<Notes>().longNoteProcessing = true;}
                    break;
                }
            }

        if (context.canceled)
        {
            foreach (GameObject index in an1)
            {
                if (index.GetComponent<Notes>().longNoteProcessing)
                {
                    int sasakure = index.GetComponent<Notes>().endpanjung-NotesCreate.nowms;
                    
                    if (sasakure > 150)
                    {
                        index.GetComponent<Notes>().owari = true;
                        index.GetComponent<Notes>().longNoteProcessing = false;
                    }
                }
            }
        }
    }

    public void KnKey2(InputAction.CallbackContext context)
    {
        if (context.started)
            foreach (GameObject index in an2)
            {
                int nanahira = index.GetComponent<Notes>().panjung-NotesCreate.nowms;

                if (nanahira < 300 && !index.GetComponent<Notes>().owari)
                {
                    if (-50 < nanahira && nanahira < 50)
                        PC.Perfect(index);
                    else if (-200 < nanahira && nanahira < 200)
                        PC.Great(index);
                    else
                        PC.Bad(index);

                    //단노트 판정 성공: NoteOver 함수 실행
                    if (index.GetComponent<Notes>().endpanjung == 0)
                        index.GetComponent<Notes>().NoteOver(true);
                    //롱노트 판정 성공: longNoteProcessing = true로 바꿈->노트가 내려가는 함수 작동 X
                    else{
                        Debug.Log("롱노트 아르라");
                        index.GetComponent<Notes>().longNoteProcessing = true;}
                    break;
                }
            }

        if (context.canceled)
        {
            foreach (GameObject index in an2)
            {
                if (index.GetComponent<Notes>().longNoteProcessing)
                {
                    int sasakure = index.GetComponent<Notes>().endpanjung-NotesCreate.nowms;
                    
                    if (sasakure > 150)
                    {
                        PC.Miss(index);
                        index.GetComponent<Notes>().owari = true;
                        index.GetComponent<Notes>().longNoteProcessing = false;
                    }
                }
            }
        }
    }

    public void KnKey3(InputAction.CallbackContext context)
    {
        if (context.started)
            foreach (GameObject index in an3)
            {
                int nanahira = index.GetComponent<Notes>().panjung-NotesCreate.nowms;

                if (nanahira < 300 && !index.GetComponent<Notes>().owari)
                {
                    if (-50 < nanahira && nanahira < 50)
                        PC.Perfect(index);
                    else if (-200 < nanahira && nanahira < 200)
                        PC.Great(index);
                    else
                        PC.Bad(index);

                    //단노트 판정 성공: NoteOver 함수 실행
                    if (index.GetComponent<Notes>().endpanjung == 0)
                        index.GetComponent<Notes>().NoteOver(true);
                    //롱노트 판정 성공: longNoteProcessing = true로 바꿈->노트가 내려가는 함수 작동 X
                    else{
                        Debug.Log("롱노트 아르라");
                        index.GetComponent<Notes>().longNoteProcessing = true;}
                    break;
                }
            }

        if (context.canceled)
        {
            foreach (GameObject index in an3)
            {
                if (index.GetComponent<Notes>().longNoteProcessing)
                {
                    int sasakure = index.GetComponent<Notes>().endpanjung-NotesCreate.nowms;
                    
                    if (sasakure > 150)
                    {
                        index.GetComponent<Notes>().owari = true;
                        index.GetComponent<Notes>().longNoteProcessing = false;
                    }
                }
            }
        }
    }
}