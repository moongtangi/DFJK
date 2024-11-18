using System.Collections.Generic;
using UnityEngine;
using System;
using Unity.VisualScripting;
using Unity.Mathematics;

public class ObjectPoolManager : MonoBehaviour
{
    public GameObject[] prefabs;
    List<GameObject>[] pools;
    int index = 0;

    void Awake()
    {
        pools = new List<GameObject>[prefabs.Length]; //프리펩 로딩 개수의 크기만큼 pool 크기 설정

        for (index = 0; index < pools.Length; index++){
            pools[index] = new List<GameObject>();
        }
    }
    public GameObject Get(int anchovy, int panju)//(index, anchovy, panju) = (노트의 색, 라인, 인풋지점)
    {
        GameObject select = null;
        index = (int)Math.Floor((double)Math.Abs(anchovy - 1.5)); // 0123에 1001로 대응
        
        foreach (GameObject item in pools[index]){
            if (!item.activeSelf){
                select = item;
                select.SetActive(true);
                break;
            }
        }

        if (!select){
            select = Instantiate(prefabs[index], transform);
            pools[index].Add(select);
        }

        select.GetComponent<Notes>().line = anchovy;
        select.GetComponent<Notes>().panjung = panju+ (int)(1000*9.125f/GameManager.notespeed);
        select.GetComponent<Notes>().태고의달인();
        return select;
    }

    public GameObject LongGet(int anchovy, int panju, int endpanju)
    {
        GameObject selectbase = null;
        index = (int)Math.Floor((double)Math.Abs(anchovy - 1.5)); // 0123에 1001으로 대응; 롱노트는 +2해서 사용
        // 롱노트
        foreach (GameObject item in pools[index]){
            if (item.transform.childCount==1 && !item.activeSelf){
                selectbase = item;
                selectbase.SetActive(true);
                break;
            }
        }

        if (!selectbase){
            selectbase = Instantiate(prefabs[index], transform);
            Instantiate(prefabs[index+2], selectbase.transform);
            pools[index].Add(selectbase);
        }
    
        selectbase.GetComponent<Notes>().line = anchovy;
        selectbase.GetComponent<Notes>().panjung = panju + (int)(1000*9.125f/GameManager.notespeed);
        selectbase.GetComponent<Notes>().endpanjung = endpanju + (int)(1000*9.125f/GameManager.notespeed);
        selectbase.GetComponent<Notes>().SizeJojul();
        return selectbase;
    }
}
