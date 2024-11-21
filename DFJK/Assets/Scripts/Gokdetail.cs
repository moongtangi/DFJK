using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using UnityEngine;
using UnityEngine.WSA;

public class Gokdetail : MonoBehaviour
{
    public string myfolder;
    AudioSource audiosource;

    public List<string> DifficultyFile = new List<string>(new string[5]);
    public string imageFile;
    public string audioFile;
    public string backGFile;

    void Start()
    {
        audioFile = $"{myfolder}/audio";
        audiosource = GetComponent<AudioSource>();
        audiosource.clip = Resources.Load<AudioClip>(audioFile);
        imageFile = $"{myfolder}/image";
        backGFile = $"{myfolder}/BEGEH";

        string resourcePath = Path.Combine(UnityEngine.Application.dataPath, "Resources", myfolder);
        if (Directory.Exists(resourcePath))
        {
            string[] cheboFiles = Directory.GetFiles(resourcePath, "*.osu");

            foreach (string file in cheboFiles)
            {
                string fileName = Path.GetFileNameWithoutExtension(file);

                string difficulty = difficulty_check(fileName);

                switch (difficulty.ToLower())
                {
                    case "easy":
                        DifficultyFile[0] = $"{myfolder}/{fileName}";
                        break;
                    case "normal":
                        DifficultyFile[1] = $"{myfolder}/{fileName}";
                        break;
                    case "hard":
                        DifficultyFile[2] = $"{myfolder}/{fileName}";
                        break;
                    case "insane":
                        DifficultyFile[3] = $"{myfolder}/{fileName}";
                        break;
                    case "another":
                        DifficultyFile[4] = $"{myfolder}/{fileName}";
                        break;
                    
                }
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
