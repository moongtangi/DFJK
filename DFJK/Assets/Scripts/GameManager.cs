using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;
using TMPro;    

public class GameManager : MonoBehaviour
{
    public NotesCreate Create;
    public static GameManager instance;
    public GameObject Pausemenu;
    public Text Countdown;

    public static float notespeed = 11.4f;
    public static float offset = 0f;

    public bool pause;
    public int pams = -4000;  //pause ms
    public static int resums = -4000, resums_dummy;  // resume ms
    private Stopwatch stopwatch = new Stopwatch();
    public bool resume;

    void Awake()
    {
        instance = this;
        resums = -4000; //초반 기본 오프셋같은 느낌
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!pause)
            {
                Pause();
            }
            else
            {
                DePause();
            }
        }
    }

    void OnApplicationFocus(bool hasFocus)
    {
        if (!hasFocus)
        {
            Pause();
        }
    }
    void Pause() //일시정지
    {
        if (pams < NotesCreate.nowms)  // 계속하기를 누른 뒤 바로 뒤에 esc눌러서 게임 돌리는거 방지
            pams = NotesCreate.nowms;
        resums = NotesCreate.nowms;
        resums_dummy = resums; 
        pause = true;
        Create.stopwatch.Stop();  //nowms의 증가를 멈추기
        Create.stopwatch.Reset();
        Pausemenu.SetActive(true);
    }
    void DePause() //일시정지 해제
    {
        pause = false;
        stopwatch.Start();  // 3초 카운트다운 시작
        Pausemenu.SetActive(false);
        resume = true;
        Countdown.gameObject.SetActive(true);
    }
    private void LateUpdate()
    {
        if (resume)
        {
            if (resums > (pams - (int)(1000 * 9.25f / notespeed)))  // 노트 위로 올리기
                resums = resums_dummy - (int)stopwatch.ElapsedMilliseconds*4;

            Countdown.text = (3- (int)(stopwatch.ElapsedMilliseconds / 1000)).ToString();  // 카운트다운에 숫자 띄우기

            if ((int)stopwatch.ElapsedMilliseconds >= 3000)  // 3초 지났을 때 실행할 것들
            {
                Create.stopwatch.Start();  // nowms 가동
                resume = false;
                stopwatch.Stop();
                stopwatch.Reset();
                Countdown.gameObject.SetActive(false);
            }
        }
    }
}
