using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolManager : MonoBehaviour
{
    public GameObject[] prefabs;
    List<GameObject>[] pools;

    void Awake()
    {
        pools = new List<GameObject>[prefabs.Length]; //프리펩 로딩 개수의 크기만큼 pool 크기 설정

        for (int index = 0; index < pools.Length; index++){
            pools[index] = new List<GameObject>();
        }
    }
    public GameObject Get(int index, int anchovy, int panju)
    {
        GameObject select = null;

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
        return select;
    }
}
