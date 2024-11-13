using System.Collections;
using UnityEngine;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using System;

public class NotesCreate : MonoBehaviour
{
    int bpm = 70;
    int i = 0;
    List<string> pattern = new List<string>();
    public int wit = 0;
    int spoint = 0, dura = 0, epoint = 0;
    public static int nowms = 0;
    public Stopwatch stopwatch = new Stopwatch(); // ms를 구현할 수 있는 정확한 stopwatch 생성
    private bool End = true;
    public ObjectPoolManager pool;

    void Start()
    {
        pattern = new List<string>(Resources.Load<TextAsset>("Patterns/pattern1").text.Split(new[] { "\r\n", "\n" }, System.StringSplitOptions.None)); /* 패턴 파일 읽어옴 */
        bpm = int.Parse(pattern[0][6..]);
        pattern.RemoveAt(0); /* BPM 읽어오고 pattern 리스트에서 삭제 */
        StartCoroutine(Placer()); /* IEnumerator Placer() 시작 */
        stopwatch.Start(); // ms 시작
    }

    void Update()
    {
        nowms = (int)stopwatch.ElapsedMilliseconds + GameManager.resums;
    }

    IEnumerator Placer()
    {
        if (pattern[i] == "")
            StopCoroutine("Placer");
        string[] parts = pattern[i].Split(',');
        // wit: 노트의 라인 // spoint: 노트의 위치(혹은 롱노트의 시점) // dura(롱노트): 롱노트의 길이 // epoint(롱노트): 롱노트의 종점

        if (parts[5] == "0:0:0:0:") // 단노트 형식: (숫자1),(숫자2),(숫자3),(숫자4),0,0:0:0:0:
        {
            wit = (int.Parse(parts[0]) - 64) / 128;
            spoint = int.Parse(parts[2]);
        }
        else if (parts[5].Contains(":0:0:0:0:")) // 롱노트 형식: (숫자1),(숫자2),(숫자3),(숫자4),0,(숫자5):0:0:0:0:
        {
            wit = (int.Parse(parts[0]) - 64) / 128;
            spoint = int.Parse(parts[2]);
            dura = int.Parse(parts[3]);
            epoint = int.Parse(parts[5].Split(':')[0]);
        }
        else { StopCoroutine("Placer"); End = false; } // 노트 형식이 아닌 입력이 들어왔을 때. 이후에 수정.

        while (spoint >= nowms)
        {
            yield return new WaitForFixedUpdate();
        }
        switch (wit)
        {
<<<<<<< Updated upstream
            case 0:
            case 3:
                pool.Get(0, wit, spoint);
                break;
            default:
                pool.Get(1, wit, spoint);
                break;
=======
            i++;
            if (i < pattern.Count && !string.IsNullOrWhiteSpace(pattern[i]))
                StartCoroutine(Placer());
>>>>>>> Stashed changes
        }

        i++;
        if (End)
            StartCoroutine(Placer());

        /*
        char gubunja = pattern[i][0];
        if (gubunja == '完')
            StopCoroutine(Placer());
        if (gubunja == '주')
            continue;
        nowline = int.Parse(pattern[i][1..]);

        if (gubunja == '@')
            yield return new WaitForSeconds((float) 240 / bpm / nowline);

        else{
            switch (nowline){
                case 0:
                case 2:
                case 3:
                case 5:
                    GameManager.instance.pool.Get(1);
                    break;
                default:
                    GameManager.instance.pool.Get(0);
                    break;
            }
            Console.WriteLine(nowline);
        }
        i++;
        */
    }
}