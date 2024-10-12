using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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

}
