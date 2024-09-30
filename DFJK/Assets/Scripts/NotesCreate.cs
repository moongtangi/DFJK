using System.Collections;
using UnityEngine;
using System.IO;
using System.Collections.Generic;
using System;

public class NotesCreate : MonoBehaviour
{
    int bpm = 70;
    int i = 0;
    List<string> pattern = new List<string>();
    public int wit=0;
    int nowms=0, spoint=0, dura=0, epoint=0;

    void Start()
    {
        pattern = new List<string>(File.ReadAllLines(@"Assets/Patterns/pattern1.txt")); /* 패턴 파일 읽어옴 */
        bpm = int.Parse(pattern[0][6..]);
        pattern.RemoveAt(0); /* BPM 읽어오고 pattern 리스트에서 삭제 */
        StartCoroutine(Placer()); /* IEnumerator Placer() 시작 */
    }

    void FixedUpdate() // 설정에서 Time뭐시깽이 설정 맞춰둠(0.01로)
    {
        nowms++;
    }

    IEnumerator Placer()
    {
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
        else{} // 노트 형식이 아닌 입력이 들어왔을 때. 이후에 수정.
        
        while (spoint >= nowms - 100) // 화면 위에서 노트 판정선까지 내려오는 시간(녹숫)을 배속별로 측정해서 100 대신 넣어놓기
        {
            yield return new WaitForFixedUpdate();
        }
        switch (wit){
            case 0:
            case 3:
                GameManager.instance.pool.Get(0, wit);
                break;
            default:
                GameManager.instance.pool.Get(1, wit);
                break;
        }
        
        i++;
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