using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnPlayBGMmanager : MonoBehaviour
{
    public static string Iamaudio;
    AudioSource audiosource ;
    // Start is called before the first frame update
    void Awake()
    {
        Debug.Log(Iamaudio);
        audiosource = GetComponent<AudioSource>();
        audiosource.clip = Resources.Load<AudioClip>(Iamaudio);
    }

    //public void PlayMusic(float startline)
    //{
    //    if (startline < 0)
    //        audiosource.time = 0;
    //    else
    //     audiosource.time = startline / 1000f;
    //    StartCoroutine(WaitPositive());
    //}

    public IEnumerator PlayMusic()
    {
        while (NotesCreate.nowms - 1000 * 6.125f / GameManager.notespeed < 0)
        {
            yield return null; // 다음 프레임까지 대기
        }
        Debug.Log(NotesCreate.nowms - 1000 * 6.125f / GameManager.notespeed / 1000f);
        audiosource.Play();
    }
    public void PauseMusic()
    {
        audiosource.Stop();
    }


}
