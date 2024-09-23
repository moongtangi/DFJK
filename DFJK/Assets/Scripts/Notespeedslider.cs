using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI;

public class Notespeedslider : MonoBehaviour
{

    public InputField nospenter;
    public Slider nosp;
    public InputField ofseenter;
    public Slider ofse;

    public GameObject menu;
    public enum Key { k0, k1, k2, k3 }; // Ű ����Ʈ define 
    public static Dictionary<Key, KeyCode> keys = new Dictionary<Key, KeyCode>
    {
        { Key.k0, KeyCode.D },
        { Key.k1, KeyCode.F },
        { Key.k2, KeyCode.J },
        { Key.k3, KeyCode.K }
    };// keys��� dictionary ������ �� Ű�� �⺻Ű DFJK ����

    int ki = -1;
    public Text[] txt;  // Ŀ���� Ű ���鶧 �ߴ� �ؽ�Ʈ ����

    public void NoteSpeed()
    {
        GameManager.notespeed = (nosp.value / 10f);
        nospenter.text = GameManager.notespeed.ToString("F1");
    }
    public void Offset()
    {
        GameManager.offset = (ofse.value / 10f);
        ofseenter.text = GameManager.offset.ToString("F1");
    }


    private void OnGUI()
    {
        Event keyEvent = Event.current;

        if (keyEvent.isKey)
        {
            if (keyEvent.keyCode != keys[Key.k0] && keyEvent.keyCode != keys[Key.k1] && keyEvent.keyCode != keys[Key.k2] && keyEvent.keyCode != keys[Key.k3])
                keys[(Key)ki] = keyEvent.keyCode;
            // ���� �̹� �ִ� Ű�� �����ƴٸ� �н�
            ki = -1;

        }

    }

    public void ChangeKey(int num)
    {
        ki = num;
    }

    public void Update()
    {
        for (int i = 0; i < txt.Length; i++)
        {
            txt[i].text = keys[(Key)i].ToString();
        }

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

    public void Nospinput(string inp)
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

}

