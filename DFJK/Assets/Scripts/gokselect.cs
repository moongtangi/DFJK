using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using TMPro;
using System;
using System.Xml.Linq;
using UnityEditor.ShaderKeywordFilter;

public class gokselect : MonoBehaviour
{
    public GameObject con;
    public GameObject blockPrefab;
    public Vector3 startPosition;
    public GameObject selected;
    int i = 0;

    public GameObject infoPanelimage;
    public List<GameObject> Difficultybutton = new List<GameObject>();


    void Start()
    {

        string[] directories = Directory.GetDirectories(Application.dataPath + "/Resources/Patterns");

        foreach (string folder in directories)
        {
            //Debug.Log(folder);
            GameObject newgoklist = Instantiate(blockPrefab, con.transform);
            newgoklist.transform.localPosition = (blockPrefab.transform.localPosition - new Vector3(0, 80 * i, 0));
            newgoklist.transform.localScale = blockPrefab.transform.localScale;
            newgoklist.name = Path.GetFileName(folder);
            i++;


            TextMeshProUGUI buttonText = newgoklist.GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = Path.GetFileName(folder);

            newgoklist.GetComponent<Gokdetail>().myfolder = folder;

        }
        
        blockPrefab.SetActive(false);
        con.GetComponent<RectTransform>().sizeDelta = new Vector2(con.GetComponent<RectTransform>().sizeDelta.x, 80*i);
    }

    public void Select(GameObject gameObject)
    {
        if (selected != null)
        {
            selected.GetComponent<AudioSource>().Stop();
            selected.GetComponent<Button>().enabled = true;
            selected.GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f);
            selected.GetComponentInChildren<TextMeshProUGUI>().color = new Color(1.0f, 1.0f, 1.0f);
        }

        gameObject.GetComponent<Button>().enabled = false;
        gameObject.GetComponent<AudioSource>().Play();
        gameObject.GetComponent<Image>().color = new Color(1.0f, 1.0f, 0.0f);
        gameObject.GetComponentInChildren<TextMeshProUGUI>().color = new Color(0.0f, 0.0f, 0.0f);
        infoPanelimage.GetComponent<Image>().sprite = LoadSpriteFromFile(gameObject.GetComponent<Gokdetail>().imageFile);
        for (int i = 0; i<5; i++)
        {
            Difficultybutton[i].GetComponent<ButtenManager>().BGM = gameObject.GetComponent<Gokdetail>().audioFile;
            Difficultybutton[i].GetComponent<ButtenManager>().chebo = gameObject.GetComponent<Gokdetail>().DifficultyFile[i];
            Debug.Log(Difficultybutton[i].GetComponent<ButtenManager>().chebo);
            if (Difficultybutton[i].GetComponent<ButtenManager>().chebo == "")
            {
                Difficultybutton[i].transform.Find("Gradient").GetComponent<Image>().color = new Color(0f, 0f, 0f);
                Difficultybutton[i].GetComponent<Button>().enabled = false;
            }
            else if (Difficultybutton[i].GetComponent<Button>().enabled == false)
            {
                Difficultybutton[i].GetComponent<Button>().enabled = true;
                Difficultybutton[i].transform.Find("Gradient").GetComponent<Image>().color = new Color(1f, 1f, 1f);
            }
        }

        selected = gameObject;
    }

    private void Update()
    {
        if (selected != null && (float)Math.Round(GameManager.volume /100f, 5) != (float)Math.Round(selected.GetComponent<AudioSource>().volume, 5) )
        {
            Debug.Log($"변수/100 : {GameManager.volume/100f}, 실제값 : {selected.GetComponent<AudioSource>().volume}");
            selected.GetComponent<AudioSource>().volume = GameManager.volume / 100f;
        }
    }

    Sprite LoadSpriteFromFile(string filePath)
    {
        byte[] imageData = File.ReadAllBytes(filePath); // 파일 데이터 읽기
        Texture2D texture = new Texture2D(2, 2);

        if (texture.LoadImage(imageData)) // Texture2D로 변환
        {
            return Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
        }

        return null; // 변환 실패 시 null 반환
    }
}