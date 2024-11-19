using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HymnOfGoldenGlory : MonoBehaviour
{
    // 쪼그라지고 늘어나는 망이(렉걸릴시 삭제)
    public bool 쪼그라짐 = true;
    public float 망이_키=100;
    void Update()
    {
        if (망이_키==100)
            쪼그라짐 = true;
        if (망이_키==30)
            쪼그라짐 = false;
        
        if (쪼그라짐){
            transform.localScale -= new Vector3(0, 0.005f, 0);
            망이_키 -= 0.5f;}
        else{
            transform.localScale += new Vector3(0, 0.005f, 0);
            망이_키 += 0.5f;}
    }
}
