using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;
using static UnityEngine.Rendering.DebugUI;

public class Notespeedslider : MonoBehaviour
{

    public TMP_InputField nospenter;
    public UnityEngine.UI.Slider nosp;
    public TMP_InputField ofseenter;
    public UnityEngine.UI.Slider ofse;

    public TMP_InputField volenter;
    public UnityEngine.UI.Slider vosp;

    public InputActionAsset inputActions;

    public GameObject menu;
    public enum Key { Knkey0, Knkey1, Knkey2, Knkey3 }; // 키 리스트 define 
    public static Dictionary<Key, KeyCode> keys = new Dictionary<Key, KeyCode>()
    {
        {Key.Knkey0, KeyCode.D},
        {Key.Knkey1, KeyCode.F},
        {Key.Knkey2, KeyCode.J},
        {Key.Knkey3, KeyCode.K}
    }; // keys라는 dictionary 생성과 동시에 각 키에 기본키 DFJK 삽입
    int ki = -1;
    public TMP_Text[] txt;  // 커스텀 키 만들때 뜨는 텍스트 정의
    bool isKeyAlreadyAssigned;
    public void Start()
    {
        for (int i = 0; i < txt.Length; i++)
        {
            if (txt[i].text != keys[(Key)i].ToString())
                txt[i].text = keys[(Key)i].ToString();
        }
        nospenter.onEndEdit.AddListener(Nospinput);
        ofseenter.onEndEdit.AddListener(Ofseinput);
        volenter.onEndEdit.AddListener(Volumeinput);

        vosp.value = GameManager.volume;
        volenter.text = GameManager.volume.ToString("F1") + "%";
    }
    public void NoteSpeed()
    {
        GameManager.notespeed = (nosp.value / 10f);
        nospenter.text = GameManager.notespeed.ToString("F1"); //슬라이더 변경 값을 변수에 저장
    }
    public void Offset()
    {
        GameManager.offset = (ofse.value / 10f);

        ofseenter.text = GameManager.offset.ToString("F1"); //슬라이더 변경 값을 변수에 저장
    }
    public void Volume()
    {
        GameManager.volume = vosp.value;
        volenter.text = GameManager.volume.ToString("F1") + "%";
    }


    public void OnGUI()
    {
        Event keyEvent = Event.current;

        if (keyEvent.isKey && ki != -1)
        {
            bool isKeyAlreadyAssigned = keys.ContainsValue(keyEvent.keyCode);
            if (!isKeyAlreadyAssigned)
            {
                keys[(Key)ki] = keyEvent.keyCode;
                txt[ki].text = keys[(Key)ki].ToString();
                inputActions.FindActionMap("Player").FindAction(Enum.GetNames(typeof(Key))[ki]).ApplyBindingOverride(0, "<Keyboard>/" + keys[(Key)ki].ToString());
            }// 만약 이미 있는 키가 지정됐다면 패스
            ki = -1;
        }

    }

    public void ChangeKey(int num)
    {
        ki = num;
    }

    public void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (menu.activeSelf == true)
            {
                menu.SetActive(false);
                if (GetComponent<gokselect>().selected != null)
                {
                    GetComponent<gokselect>().selected.GetComponent<AudioSource>().UnPause();
                }
            }

            else
            {
                menu.SetActive(true);
                nosp.value = GameManager.notespeed * 10f;
                nospenter.text = GameManager.notespeed.ToString("F1");
                ofse.value = GameManager.offset * 10f;
                ofseenter.text = GameManager.offset.ToString("F1");
                if (GetComponent<gokselect>().selected != null)
                {
                    GetComponent<gokselect>().selected.GetComponent<AudioSource>().Pause();
                }
            }
        }
    }

    public void Nospinput(string inp)
    {
        if (float.TryParse(inp, out float input) && ((float.Parse(inp)) * 10) >= nosp.minValue && ((float.Parse(inp)) * 10) <= nosp.maxValue)
        {
            GameManager.notespeed = Mathf.Round(input * 10) / 10f;

            nosp.value = Mathf.Round(input * 10);
        }
        else
        {
            nospenter.text = GameManager.notespeed.ToString("F1");
        }
    }

    public void Ofseinput(string inp)
    {
        if (float.TryParse(inp, out float input) && ((float.Parse(inp)) * 10) >= ofse.minValue && ((float.Parse(inp)) * 10) <= ofse.maxValue)
        {
            GameManager.offset = Mathf.Round(input * 10) / 10f;

            ofse.value = Mathf.Round(input * 10);
        }
        else
        {
            ofseenter.text = GameManager.offset.ToString("F1");
        }
    }

    public void Volumeinput(string inp)
    {
        if (float.TryParse(inp, out float input) && ((float.Parse(inp))) >= ofse.minValue && ((float.Parse(inp))) <= ofse.maxValue)
        {
            GameManager.volume = input;

            vosp.value = input;
        }
        else
        {
            volenter.text = GameManager.volume.ToString("F1") + "%";
        }
    }

}

