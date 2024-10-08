using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public NotesCreate Create;
    public static GameManager instance;
    public static float notespeed = 11.4f;
    public static float offset = 0f;
    public bool pause;
    public int pams = -4000;
    public static int resums = -4000;
    private Stopwatch stopwatch = new Stopwatch();
    float resumetime;
    public GameObject Pausemenu;
    long test;

    void Awake()
    {
        instance = this;
        resums = -4000;
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
    void Pause()
    {
        if (pams <NotesCreate.nowms)
            pams = NotesCreate.nowms;
        resums = NotesCreate.nowms;
        pause = true;
        Create.stopwatch.Stop();
        Create.stopwatch.Reset();
        Pausemenu.SetActive(true);
        test = Create.stopwatch.ElapsedMilliseconds;
        UnityEngine.Debug.Log(NotesCreate.nowms + " " + test + " " + pams + " " + resums);
    }
    void DePause()
    {
        pause = false;
        stopwatch.Start();
        Pausemenu.SetActive(false);
        ResumeAfterDelay(3f);
        while (resums > (pams - 1000))
        {
            resums = pams - (int)stopwatch.ElapsedMilliseconds;
            //UnityEngine.Debug.Log(NotesCreate.nowms);
        }
        stopwatch.Stop();
        stopwatch.Reset();

    }
    IEnumerator ResumeAfterDelay(float delay)
    {
        yield return new WaitForSecondsRealtime(delay); // 실제 시간을 기준으로 3초 대기
        Create.stopwatch.Start();
    }
}
