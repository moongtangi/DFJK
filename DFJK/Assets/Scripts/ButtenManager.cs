using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class ButtenManager : MonoBehaviour
{
    // Start is called before the first frame update
    public void SampleScene()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void gokselectchang()
    {
        SceneManager.LoadScene("gokselectchang");
    }
    public void ScoreScene()
    {
        SceneManager.LoadScene("Score Scene");
    }
    public string chebo = null;
    public string BGM = null;
    public void finalselectgok()
    {
        NotesCreate.FilePath = chebo;
        OnPlayBGMmanager.Iamaudio = BGM;
    }

}
