using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class PlayInputManager : MonoBehaviour
{
    public List<GameObject> an0 = new List<GameObject>();
    public List<GameObject> an1 = new List<GameObject>();
    public List<GameObject> an2 = new List<GameObject>();
    public List<GameObject> an3 = new List<GameObject>();

    private void OnKey0()
    {
        foreach (GameObject index in an0)
        {
            int nanahira = index.GetComponent<Notes>().panjung-NotesCreate.nowms;

            if (nanahira < 100)
            {
                if (-50 < nanahira && nanahira < 50)
                {
                    Debug.Log($"PERFΞCT where {index.GetComponent<Notes>().panjung}, line 0");
                }
                else if (nanahira > 50 || (-100 < nanahira && nanahira < -50))
                {
                    Debug.Log($"GRΣAT where {index.GetComponent<Notes>().panjung}, line 0");
                }
                else
                {
                    Debug.Log($"B∀D where {index.GetComponent<Notes>().panjung}, line 0");
                }

                //단노트 판정 성공: NoteOver 함수 실행
                if (index.GetComponent<Notes>().endpanjung == 0)
                    index.GetComponent<Notes>().NoteOver();
                //롱노트 판정 성공: longNoteProcessing = true로 바꿈->노트가 내려가는 함수 작동 X
                else{
                    Debug.Log("롱노트 아르라");
                    index.GetComponent<Notes>().longNoteProcessing = true;}
                break;
            }
        }
    }
    
    private void OnKey1()
    {
        foreach (GameObject index in an1)
        {
            int nanahira = index.GetComponent<Notes>().panjung-NotesCreate.nowms;

            if (nanahira < 100)
            {
                if (-50 < nanahira && nanahira < 50)
                {
                    Debug.Log($"PERFΞCT where {index.GetComponent<Notes>().panjung}, line 1");
                }
                else if (nanahira > 50 || (-100 < nanahira && nanahira < -50))
                {
                    Debug.Log($"GRΣAT where {index.GetComponent<Notes>().panjung}, line 1");
                }
                else
                {
                    Debug.Log($"B∀D where {index.GetComponent<Notes>().panjung}, line 1");
                }

                //단노트 판정 성공: NoteOver 함수 실행
                if (index.GetComponent<Notes>().endpanjung == 0)
                    index.GetComponent<Notes>().NoteOver();
                //롱노트 판정 성공: longNoteProcessing = true로 바꿈->노트가 내려가는 함수 작동 X
                else{
                    Debug.Log("롱노트 아르라");
                    index.GetComponent<Notes>().longNoteProcessing = true;}
                break;
            }
        }
    }

    private void OnKey2()
    {
        foreach (GameObject index in an2)
        {
            int nanahira = index.GetComponent<Notes>().panjung-NotesCreate.nowms;

            if (nanahira < 100)
            {
                if (-50 < nanahira && nanahira < 50)
                {
                    Debug.Log($"PERFΞCT where {index.GetComponent<Notes>().panjung}, line 2");
                }
                else if (nanahira > 50 || (-100 < nanahira && nanahira < -50))
                {
                    Debug.Log($"GRΣAT where {index.GetComponent<Notes>().panjung}, line 2");
                }
                else
                {
                    Debug.Log($"B∀D where {index.GetComponent<Notes>().panjung}, line 2");
                }

                //단노트 판정 성공: NoteOver 함수 실행
                if (index.GetComponent<Notes>().endpanjung == 0)
                    index.GetComponent<Notes>().NoteOver();
                //롱노트 판정 성공: longNoteProcessing = true로 바꿈->노트가 내려가는 함수 작동 X
                else{
                    Debug.Log("롱노트 아르라");
                    index.GetComponent<Notes>().longNoteProcessing = true;}
                break;
            }
        }
    }

    private void OnKey3()
    {
        foreach (GameObject index in an3)
        {
            int nanahira = index.GetComponent<Notes>().panjung-NotesCreate.nowms;

            if (nanahira < 100)
            {
                if (-50 < nanahira && nanahira < 50)
                {
                    Debug.Log($"PERFΞCT where {index.GetComponent<Notes>().panjung}, line 3");
                }
                else if (nanahira > 50 || (-100 < nanahira && nanahira < -50))
                {
                    Debug.Log($"GRΣAT where {index.GetComponent<Notes>().panjung}, line 3");
                }
                else
                {
                    Debug.Log($"B∀D where {index.GetComponent<Notes>().panjung}, line 3");
                }

                //단노트 판정 성공: NoteOver 함수 실행
                if (index.GetComponent<Notes>().endpanjung == 0)
                    index.GetComponent<Notes>().NoteOver();
                //롱노트 판정 성공: longNoteProcessing = true로 바꿈->노트가 내려가는 함수 작동 X
                else{
                    Debug.Log("롱노트 아르라");
                    index.GetComponent<Notes>().longNoteProcessing = true;}
                break;
            }
        }
    }
    
}
