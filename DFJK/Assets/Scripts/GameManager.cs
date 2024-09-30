using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    
    public static GameManager instance;
    public ObjectPoolManager pool;
    public static float notespeed = 11.4f;
    public static float offset = 0f;

    void Awake()
    {
        instance = this;
    }
}
