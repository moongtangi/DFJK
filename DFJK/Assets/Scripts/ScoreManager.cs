using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TMP_Text acu;
    public TMP_Text per;
    public TMP_Text gre;
    public TMP_Text bad;
    public TMP_Text mis;

    public int perNum, greNum, badNum, misNum, combo;
    public double accuracy;

    public Sprite[] rankSprites;
    Sprite rank;

    void Start()
    {
        acu.text = accuracy.ToString();
        per.text = perNum.ToString();
        gre.text = greNum.ToString();
        bad.text = badNum.ToString();
        mis.text = misNum.ToString();

        accuracy = 97;

        if (accuracy == 100)
            rank = rankSprites[6];//퍼펙트이미지
        if (accuracy>=96)
            rank = rankSprites[0];
        else if (accuracy>=92)
            rank = rankSprites[1];
        else if (accuracy>=88)
            rank = rankSprites[2];
        else if (accuracy>=80)
            rank = rankSprites[3];
        else if (accuracy>=70)
            rank = rankSprites[4];
        else
            rank = rankSprites[5];
        Instantiate(rank, this.transform);
    }
}
