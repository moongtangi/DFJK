using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.WSA;

public class Gokdetail : MonoBehaviour
{
    public string myfolder;
    AudioSource audiosource;

    public string easyFile;
    public string hardFile;
    public string intermediateFile;
    public string normalFile;
    public string insaneFile;
    public string imageFile;
    public bool exist_insane = false;

    void Start()
    {

        audiosource = GetComponent<AudioSource>();
        audiosource.clip = Resources.Load<AudioClip>("Patterns/" + Path.GetFileName(myfolder) + "/audio");
        imageFile = Path.Combine(myfolder, "image.png");

        string[] cheboFiles = Directory.GetFiles(myfolder, "*.osu");

        foreach (string file in cheboFiles)
        {
            string difficulty = difficulty_check(Path.GetFileName(file));

            switch (difficulty)
            {
                case "Easy":
                case "easy":
                    easyFile = file;
                    break;
                case "Intermediate":
                case "intermediate":
                    intermediateFile = file;
                    break;
                case "Normal":
                case "normal":
                    normalFile = file;
                    break;
                case "Hard":
                case "hard":
                    easyFile = file;
                    break;
                case "Insane":
                case "insane":
                    easyFile = file;
                    exist_insane = true;
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
