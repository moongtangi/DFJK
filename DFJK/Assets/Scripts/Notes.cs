using UnityEngine;
using UnityEngine.InputSystem;

public class Notes : MonoBehaviour
{
    public readonly float[] notePosition = { -1.5f, -0.5f, 0.5f, 1.5f };
    public int line = 1;
    void OnEnable()
    {
        transform.position = new Vector3(notePosition[line], 6.125f, 0);
    }

    void LateUpdate()
    {
        transform.Translate(Vector2.down * 11.4f * Time.deltaTime);
        if (transform.position.y < -3)
        {
            gameObject.SetActive(false);
        }
    }
}
