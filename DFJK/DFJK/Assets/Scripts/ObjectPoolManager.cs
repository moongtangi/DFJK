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
        } // pools = { [0(act), 0(act), 0(act)]<<, [ ] }
    }

    public GameObject Get(int index)
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

        return select;
    }
}
