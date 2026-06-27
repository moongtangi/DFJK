using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class ScoreManager : MonoBehaviour
{
    public TMP_Text acu;
    public TMP_Text per;
    public TMP_Text gre;
    public TMP_Text bad;
    public TMP_Text mis;
    
    public double accuracy;

    public Sprite[] rankSprites;
    Sprite rank;

    void Start()
    {
        accuracy = Math.Round(PanjungChang.accuracy, 2);
        acu.text = accuracy.ToString() + "%";
        per.text = PanjungChang.perNum.ToString();
        gre.text = PanjungChang.greNum.ToString();
        bad.text = PanjungChang.badNum.ToString();
        mis.text = PanjungChang.misNum.ToString();

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
