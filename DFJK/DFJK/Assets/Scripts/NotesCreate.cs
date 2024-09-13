using System.Collections;
using UnityEngine;
using System.IO;
using System.Collections.Generic;
using System;

public class NotesCreate : MonoBehaviour
{
    int bpm = 70;
    public readonly float[] notePosition = { -2.5f, -1.5f, -0.5f, 0.5f, 1.5f, 2.5f };
    int i = 0;
    List<string> pattern = new List<string>();
    public int nowline;

    void Start()
    {
        pattern = new List<string>(File.ReadAllLines(@"Assets/Patterns/pattern1.txt")); /* 패턴 파일 읽어옴 */
        bpm = int.Parse(pattern[0][6..]);
        pattern.RemoveAt(0); /* BPM 읽어오고 pattern 리스트에서 삭제 */
        StartCoroutine(Placer()); /* IEnumerator Placer() 시작 */
    }

    IEnumerator Placer()
    {
        while (true)
        {
            char gubunja = pattern[i][0]; /* 패턴 파일의 모든 줄은 .3과 같이 구분자+내용 형태입니다. */
            if (gubunja == '完') /* 채보의 끝 */
                StopCoroutine(Placer());
            if (gubunja == '주') /* 채보 파일 내 주석 */
                continue;
            nowline = int.Parse(pattern[i][1..]);

            if (gubunja == '@') /* @r: r비트 지연 e.g. #16 = 16비트 */
                yield return new WaitForSeconds((float) 240 / bpm / nowline);

            else{ /* .n: n번째 줄(맨 왼쪽 줄은 0)에 노트 생성 e.g. .3 = 4번 줄에 노트 생성 */
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

                /*
                Instantiate((nowline == 0 || nowline == 2 || nowline == 3 || nowline == 5) ? NotePreFab0 : NotePreFab1, new Vector3(notePosition[nowline], 6.125f, 0), Quaternion.identity);
                */
            i++;
        }
    }
}

/*
    IEnumerator countTime(float delayTime)
    {
        Debug.Log("Time = " + Time.time);
        yield return new WaitForSeconds(delayTime);
        StartCoroutine( countTime, 1 );
    }
*/