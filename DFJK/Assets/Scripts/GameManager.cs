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
        resums = -4000; //√ π› ±‚∫ª ø¿«¡º¬∞∞¿∫ ¥¿≥¶
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
    void Pause() //¿œΩ√¡§¡ˆ
    {
        if (pams < NotesCreate.nowms)  // ∞Ëº”«œ±‚∏¶ ¥©∏• µ⁄ πŸ∑Œ µ⁄ø° esc¥≠∑Øº≠ ∞‘¿” µπ∏Æ¥¬∞≈ πÊ¡ˆ
            pams = NotesCreate.nowms;
        resums = NotesCreate.nowms;
        resums_dummy = resums; 
        pause = true;
        Create.stopwatch.Stop();  //nowms¿« ¡ı∞°∏¶ ∏ÿ√ﬂ±‚
        Create.stopwatch.Reset();
        Pausemenu.SetActive(true);
    }
<<<<<<< Updated upstream
    void DePause() //¿œΩ√¡§¡ˆ «ÿ¡¶
=======
    public void DePause() //ÏùºÏãúÏ†ïÏßÄ Ìï¥Ï†ú
>>>>>>> Stashed changes
    {
        pause = false; 
        stopwatch.Start();  // 3√  ƒ´øÓ∆Æ¥ŸøÓ Ω√¿€
        Pausemenu.SetActive(false);
        resume = true;
        Countdown.gameObject.SetActive(true);

    }
    private void LateUpdate()
    {
        if (resume)
        {
            if (resums > (pams - (int)(1000 * 9.25f / notespeed)))  // ≥Î∆Æ ¿ß∑Œ ø√∏Æ±‚
                resums = resums_dummy - (int)stopwatch.ElapsedMilliseconds*4;

            Countdown.text = (3- (int)(stopwatch.ElapsedMilliseconds / 1000)).ToString();  // ƒ´øÓ∆Æ¥ŸøÓø° º˝¿⁄ ∂ÁøÏ±‚

            if ((int)stopwatch.ElapsedMilliseconds >= 3000)  // 3√  ¡ˆ≥µ¿ª ∂ß Ω««‡«“ ∞ÕµÈ
            {
                Create.stopwatch.Start();  // nowms ∞°µø
                resume = false;
                stopwatch.Stop();
                stopwatch.Reset();
                Countdown.gameObject.SetActive(false);
            }
        }
    }
}
