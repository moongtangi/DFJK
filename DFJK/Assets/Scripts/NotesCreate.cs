using System.Collections;
using UnityEngine;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using System;
using Debug = UnityEngine.Debug;
using UnityEditor;
using UnityEngine.SceneManagement;

public class NotesCreate : MonoBehaviour
{

    // 소소한 변수
    int i = 0; // 패턴 한 줄씩 읽기용 for용 i
    private bool End = false; // 파일 읽기 종료 시
    string 파일다읽었는지아닌지판단하는변수;
    
    //패턴 관련
    List<string> pattern = new List<string>(); // pattern 저장용 List
    public int wit = 0; // 노트의 라인(0, 1, 2, 3)
    int spoint = 0, epoint = 0; // 노트의 시점, 종점(단놋은 spoint만)
    public ObjectPoolManager pool; // 노트 생성용 스크립트(pool) 불러오기
    public bool IamLongNote = false; // I am 롱노트예요
    
    //시간 관련
    public static int nowms = -1;
    public Stopwatch stopwatch = new Stopwatch(); // ms를 구현할 수 있는 정확한 stopwatch 생성
    public static string FilePath = @"Assets/Resources/Patterns/pattern1.txt";

    void Awake()
    {
        Debug.Log(FilePath);
        pattern = new List<string>(File.ReadAllLines(FilePath)); /* 패턴 파일 읽어옴 */
        i = pattern.LastIndexOf("[HitObjects]") + 1;
        Debug.Log(i);
        StartCoroutine(Placer()); /* IEnumerator Placer() 시작 */
        stopwatch.Start(); // ms 시작
    }

    void Update()
    {
        nowms = (int)stopwatch.ElapsedMilliseconds + GameManager.resums;
    }

    IEnumerator Placer()
    {
        try{파일다읽었는지아닌지판단하는변수 = pattern[i];}
        catch (ArgumentOutOfRangeException)
        {
            StopCoroutine("Placer");
            Invoke("gameEnd", 3);
        }

        string[] parts = pattern[i].Split(',');
        // wit: 노트의 라인 // spoint: 노트의 위치(혹은 롱노트의 시점) // epoint(롱노트): 롱노트의 종점

        if (parts[5] == "0:0:0:0:") // 단노트 형식: (숫자1),(숫자2),(숫자3),(숫자4),0,0:0:0:0:
        {
            wit = (int.Parse(parts[0]) - 64) / 128;
            spoint = int.Parse(parts[2]);
            IamLongNote = false;
        }
        else if (parts[5].Contains(":0:0:0:0:")) // 롱노트 형식: (숫자1),(숫자2),(숫자3),128,0,(숫자5):0:0:0:0:
        {
            wit = (int.Parse(parts[0]) - 64) / 128;
            spoint = int.Parse(parts[2]);
            epoint = int.Parse(parts[5].Split(':')[0]);
            IamLongNote = true;
        }

        while (spoint >= nowms)
        {
            yield return new WaitForFixedUpdate();
        }
        if (!IamLongNote) {
            pool.Get(wit, spoint); }
        else {
            pool.LongGet(wit, spoint, epoint); }

        if (!End)
        {
            i++;
            StartCoroutine(Placer());
        }
    }

    void gameEnd()
    {
        SceneManager.LoadScene("ScoreScene");
    }
}