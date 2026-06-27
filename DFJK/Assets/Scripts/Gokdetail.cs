using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using UnityEngine;

public class Gokdetail : MonoBehaviour
{
    public string myfolder;
    AudioSource audiosource;

    public List<string> DifficultyFile = new List<string>(new string[5]);
    public string imageFile;
    public string audioFile;
    public string BackGFile;

    void Start()
    {
        audioFile = "Patterns/" + myfolder + "/audio";
        audiosource = GetComponent<AudioSource>();
        audiosource.clip = Resources.Load<AudioClip>(audioFile);
        imageFile = "Patterns/" + myfolder + "/image";
        BackGFile = "Patterns/" + myfolder + "/BEGEH";

        TextAsset[] cheboFiles = Resources.LoadAll<TextAsset>("Patterns/" + myfolder);

        foreach (TextAsset chart in cheboFiles)
        {
            string difficulty = difficulty_check(chart.name);
            string file = "Patterns/" + myfolder + "/" + chart.name;

            switch (difficulty.ToLower())
            {
                case "easy":
                    DifficultyFile[0] = file;
                    break;
                case "normal":
                    DifficultyFile[1] = file;
                    break;
                case "hard":
                    DifficultyFile[2] = file;
                    break;
                case "insane":
                    DifficultyFile[3] = file;
                    break;
                case "another":
                    DifficultyFile[4] = file;
                    break;
            }
        }
        
    }
    
    string difficulty_check(string file)
    {
        int endIndex = file.LastIndexOf(']');
        int startIndex = file.LastIndexOf('[', endIndex); // ] 앞에서 가장 가까운 [ 찾기

        return file.Substring(startIndex + 1, endIndex - startIndex - 1);
    }
}
