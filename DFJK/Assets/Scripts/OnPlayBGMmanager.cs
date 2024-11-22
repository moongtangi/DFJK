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
    public IEnumerator PlayMusic()
    {
        while (0.2 + (+NotesCreate.nowms - 1000 * 8.462f / GameManager.notespeed) / 1000f < 0)
        {
            yield return null; // 다음 프레임까지 대기
        }
        Debug.Log(0.2 + ( NotesCreate.nowms - 1000 * 8.462f / GameManager.notespeed) / 1000f);
        audiosource.time = 0.2f + (NotesCreate.nowms - 1000 * 8.462f / GameManager.notespeed) / 1000f;
        audiosource.Play();
    }
    public void PauseMusic()
    {
        audiosource.Stop();
    }


}
