using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    public RectTransform o1;
    public RectTransform o2;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 o1po = o1.position;
        Vector3 o2po = o2.position;
        Debug.Log(o1po.x - o2po.x); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
