using UnityEngine;
using UnityEngine.InputSystem;

public class Notes : MonoBehaviour
{
    public GameObject test;

    public int nowlinepa;
    void OnEnable()
    {
        test = GameObject.Find("Blovy");
        //nowlinepa = GameManager.instance.makenoter.nowline;
        nowlinepa = test.GetComponent<NotesCreate>().nowline;
        transform.position = new Vector3(test.GetComponent<NotesCreate>().notePosition[nowlinepa], 6.125f, 0);
    }

    void LateUpdate()
    {
        transform.Translate(Vector2.down * GameManager.notespeed * Time.deltaTime);
        if (transform.position.y < -3)
        {
            gameObject.SetActive(false);
        }
    }
}
