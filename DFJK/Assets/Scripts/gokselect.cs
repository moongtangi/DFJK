using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using TMPro;
using System.Xml.Linq;

public class gokselect : MonoBehaviour
{
    public GameObject con;
    public GameObject blockPrefab;
    public Vector3 startPosition;
    public GameObject selected;
    int i = 0;


    void Start()
    {

        string[] directories = Directory.GetDirectories(Application.dataPath + "/Resources/Patterns");

        foreach (string folder in directories)
        {

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

        selected = gameObject;
    }

}