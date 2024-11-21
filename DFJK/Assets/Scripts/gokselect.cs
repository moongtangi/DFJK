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

        TextAsset folderList = Resources.Load<TextAsset>("Patterns/folder_list");

        string[] directories = folderList.text.Split('\n');

        foreach (string folder in directories)
        {
            string folderName = folder.Trim();
            if (string.IsNullOrEmpty(folderName)) continue;

            GameObject newgoklist = Instantiate(blockPrefab, con.transform);
            newgoklist.transform.localPosition = (blockPrefab.transform.localPosition - new Vector3(0, 80 * i, 0));
            newgoklist.transform.localScale = blockPrefab.transform.localScale;
            newgoklist.name = Path.GetFileName(folderName);
            i++;


            TextMeshProUGUI buttonText = newgoklist.GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = folderName;

            newgoklist.GetComponent<Gokdetail>().myfolder = "Patterns/" + folderName;
            
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
            Difficultybutton[i].GetComponent<ButtenManager>().Image = LoadSpriteFromFile(gameObject.GetComponent<Gokdetail>().backGFile);
            Difficultybutton[i].GetComponent<ButtenManager>().BGM = gameObject.GetComponent<Gokdetail>().audioFile;
            Difficultybutton[i].GetComponent<ButtenManager>().chebo = gameObject.GetComponent<Gokdetail>().DifficultyFile[i];
            Debug.Log(gameObject.GetComponent<Gokdetail>().DifficultyFile[i]);
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
        Sprite sprite = Resources.Load<Sprite>(filePath);

        return sprite;
    }
}