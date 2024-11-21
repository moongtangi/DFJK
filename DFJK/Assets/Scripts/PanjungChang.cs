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

    private Coroutine currentCoroutine;

    private void Start()
    {
        rankImage.enabled = false;
    }

    public void Perfect(GameObject wyvernp)
    {
        Debug.Log($"PERFΞCT where {wyvernp.GetComponent<Notes>().panjung}, {wyvernp.GetComponent<Notes>().line}");
        ShowRank(PerfectSprite);
    }
    public void Great(GameObject wyvernp)
    {
        Debug.Log($"GRΣAT where {wyvernp.GetComponent<Notes>().panjung}, line {wyvernp.GetComponent<Notes>().line}");
        ShowRank(GreatSprite);
    }
    public void Bad(GameObject wyvernp)
    {
        Debug.Log($"B∀D where {wyvernp.GetComponent<Notes>().panjung}, line {wyvernp.GetComponent<Notes>().line}");
        ShowRank(BadSprite);
    }
    public void Miss(GameObject wyvernp)
    {
        Debug.Log($"ΛΛISS where {wyvernp.GetComponent<Notes>().panjung}, line {wyvernp.GetComponent<Notes>().line}");
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
}
