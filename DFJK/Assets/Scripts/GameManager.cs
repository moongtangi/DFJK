using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    
    public static GameManager instance;
    public ObjectPoolManager pool;

    void Awake()
    {
        instance = this;
    }
}
