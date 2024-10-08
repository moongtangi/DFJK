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
        resums = -4000; //�ʹ� �⺻ �����°��� ����
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
    void Pause() //�Ͻ�����
    {
        if (pams < NotesCreate.nowms)  // ����ϱ⸦ ���� �� �ٷ� �ڿ� esc������ ���� �����°� ����
            pams = NotesCreate.nowms;
        resums = NotesCreate.nowms;
        resums_dummy = resums; 
        pause = true;
        Create.stopwatch.Stop();  //nowms�� ������ ���߱�
        Create.stopwatch.Reset();
        Pausemenu.SetActive(true);
    }
    void DePause() //�Ͻ����� ����
    {
        pause = false; 
        stopwatch.Start();  // 3�� ī��Ʈ�ٿ� ����
        Pausemenu.SetActive(false);
        resume = true;
        Countdown.gameObject.SetActive(true);

    }
    private void LateUpdate()
    {
        if (resume)
        {
            if (resums > (pams - (int)(1000 * 9.25f / notespeed)))  // ��Ʈ ���� �ø���
                resums = resums_dummy - (int)stopwatch.ElapsedMilliseconds*4;

            Countdown.text = (3- (int)(stopwatch.ElapsedMilliseconds / 1000)).ToString();  // ī��Ʈ�ٿ ���� ����

            if ((int)stopwatch.ElapsedMilliseconds >= 3000)  // 3�� ������ �� ������ �͵�
            {
                Create.stopwatch.Start();  // nowms ����
                resume = false;
                stopwatch.Stop();
                stopwatch.Reset();
                Countdown.gameObject.SetActive(false);
            }
        }
    }
}
