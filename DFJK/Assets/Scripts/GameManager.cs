using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI;

public class GameManager : MonoBehaviour
{
    /*여기에 범용 코드 입력
    (ex. pool: 노트 생성 효율적으로 해주는 친구인데 NotesCreate.cs에서 사용해서 여기에 추가)
    사용 방법: GameManager.instance.pool.Get(1) <<<< pool에 있는 Get() 함수를 사용하겠다(다른 파일에서도 가능)
    */
    public static GameManager instance;
    public ObjectPoolManager pool;
    public NotesCreate makenoter;
    public static float notespeed = 11.4f;
    public static float offset = 0f;




    void Awake()
    {
        instance = this;


    }



    

}
  
