using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanjungChang : MonoBehaviour
{
    public Image rankImage;
    public Sprite PerfectSprite; // Perfect
    public Sprite GreatSprite; // Great
    public Sprite BadSprite; // Bad
    public Sprite MissSprite; // Miss
    public double accuracy = 0;
    public int perNum = 0;
    public int greNum = 0;
    public int badNum = 0;
    public int misNum = 0;
    public int combo = 0;

    private Coroutine currentCoroutine;

    private void Start()
    {
        accuracy = 0;
        perNum = 0;
        greNum = 0;
        badNum = 0;
        misNum = 0;
        combo = 0;
        rankImage.enabled = false;
    }

    public void Perfect(GameObject wyvernp)
    {
        Debug.Log($"PERFΞCT where {wyvernp.GetComponent<Notes>().panjung}, {wyvernp.GetComponent<Notes>().line}");
        perNum++;
        combo++;
        GoodAccuracy();
        ShowRank(PerfectSprite);
    }
    public void Great(GameObject wyvernp)
    {
        Debug.Log($"GRΣAT where {wyvernp.GetComponent<Notes>().panjung}, line {wyvernp.GetComponent<Notes>().line}");
        greNum++;
        combo++;
        GoodAccuracy();
        ShowRank(GreatSprite);
    }
    public void Bad(GameObject wyvernp)
    {
        Debug.Log($"B∀D where {wyvernp.GetComponent<Notes>().panjung}, line {wyvernp.GetComponent<Notes>().line}");
        badNum++;
        GoodAccuracy();
        ShowRank(BadSprite);
    }
    public void Miss(GameObject wyvernp)
    {
        Debug.Log($"ΛΛISS where {wyvernp.GetComponent<Notes>().panjung}, line {wyvernp.GetComponent<Notes>().line}");
        misNum++;
        GoodAccuracy();
        ShowRank(MissSprite);
    }

    private void ShowRank(Sprite rankSprite)
    {
        if (currentCoroutine != null)
            StopCoroutine(currentCoroutine);

        rankImage.sprite = rankSprite;
        rankImage.enabled = true;

        currentCoroutine = StartCoroutine(HideRankAfterDelay(2f));
    }
    private IEnumerator HideRankAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        rankImage.enabled = false;
        currentCoroutine = null;
    }

    void GoodAccuracy()
    {
        accuracy = perNum + greNum * 0.75f + badNum * 0.2f;
        Debug.Log($"저ㅏㅇ확{accuracy} 콤보{combo}");
    }
}
