using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI;

public class Notespeedslider : MonoBehaviour
{

    public InputField nospenter;
    public UnityEngine.UI.Slider nosp;
    public InputField ofseenter;
    public UnityEngine.UI.Slider ofse;

    public GameObject menu;
    public enum Key { k0, k1, k2, k3 }; // 키 리스트 define 
    public static Dictionary<Key, KeyCode> keys = new Dictionary<Key, KeyCode>()
    {
        {Key.k0, KeyCode.D},
        {Key.k1, KeyCode.F},
        {Key.k2, KeyCode.J},
        {Key.k3, KeyCode.K}
    }; // keys라는 dictionary 생성과 동시에 각 키에 기본키 DFJK 삽입
    int ki = -1;
    public Text[] txt;  // 커스텀 키 만들때 뜨는 텍스트 정의
    bool isKeyAlreadyAssigned;
    public void Start()
    {
        for (int i = 0; i < txt.Length; i++)
        {
            if (txt[i].text != keys[(Key)i].ToString())
                txt[i].text = keys[(Key)i].ToString();
        }
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
                menu.SetActive(false);

            else
            {
                menu.SetActive(true);
                nosp.value = GameManager.notespeed * 10f;
                nospenter.text = GameManager.notespeed.ToString("F1");
                ofse.value = GameManager.offset * 10f;
                ofseenter.text = GameManager.offset.ToString("F1");
            }
        }
    }

    void Nospinput(string inp)
    {
        if (float.TryParse(inp, out float input) && ((float.Parse(inp))*10) >= nosp.minValue && ((float.Parse(inp))*10) <= nosp.maxValue)
        {
            GameManager.notespeed = Mathf.Round(input * 10) / 10f;

            nosp.value = Mathf.Round(input * 10);
        }
        else
        {
            nospenter.text = GameManager.notespeed.ToString("F1");
        }
    }

    void Ofseinput(string inp)
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

}

